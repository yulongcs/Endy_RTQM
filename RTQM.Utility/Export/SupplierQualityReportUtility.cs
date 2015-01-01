using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Lgsoft.RTQM.Application.BaseInfoModule.Services;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 供应商质量报告工具。
    /// </summary>
    public static class SupplierQualityReportUtility
    {
        /// <summary>
        /// 将供应商质量报告到 Excel 文件。
        /// </summary>
        /// <param name="startDate">查询的开始日期。</param>
        /// <param name="endDate">查询的结束日期。</param>
        /// <param name="supplierNames">要报告的供应商名称列表。</param>
        /// <param name="materialType">要报告的物料类型。</param>
        /// <param name="roundType">报告采用的报告周期。</param>
        /// <returns>返回 Excel 文件流。</returns>
        public static Stream SupplierQualityReportToExcel(DateTime startDate, DateTime endDate, string[] supplierNames,
                                                          MaterialType materialType, DateRoundTypes roundType)
        {
            var supplierAppService =
                Container.Current.Resolve(typeof (ISupplierAppService), null) as ISupplierAppService;
            
            if (supplierAppService == null)
                throw new InvalidOperationException("无法获取供应商应用服务。");

            // 将供应商名称转换为供应商标识
            var supplierNameIds = (from supplierName in supplierNames
                                   select supplierAppService.GetSupplier(supplierName)
                                   into supplier
                                   where supplier != null
                                   select new {supplier.SupplierName, SupplierId = supplier.Id}).ToList();

            var tableData = new TableDataCollector();

            tableData.AddLineNames((from supplierNameId in supplierNameIds
                                    select supplierNameId.SupplierName).ToArray());

            var dateRound = DateRoundStrategy.CreateDateRoundStrategy(roundType);
            var roundNames = new List<string>();

            dateRound.SetRoundIdentificationDate(startDate);
            dateRound.SetRoundIdentificationDate(dateRound.RoundStartDate.AddDays(-1));
            do
            {
                dateRound.NextRound();
                roundNames.Add(dateRound.GetCurrentRoundName('.'));
            } while (!dateRound.IsInCurrentDateRound(endDate));

            tableData.AddColumnNames(roundNames.ToArray());

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RTQMUnitOfWork"].ConnectionString))
            {
                conn.Open();

                foreach (var supplierNameId in supplierNameIds)
                {
                    using (var summaryCalculator = new RawMaterialSummaryCalculator(conn,
                                                                             DateRoundStrategy.CreateDateRoundStrategy(
                                                                                 roundType), materialType,
                                                                             supplierNameId.SupplierId, startDate,
                                                                             endDate))
                    {
                        RawMaterialSummaryData summaryData;

                        while ((summaryData = summaryCalculator.GetNextRoundSummaryData()) != null)
                        {
                            tableData.SetCellValue(supplierNameId.SupplierName, summaryData.SummaryName,
                                                   (float) summaryData.QtyTotalSummary*100/summaryData.TotalSummary);
                        }
                    }
                }
            }

            return ToExcel(tableData, materialType);
        }

        /// <summary>
        /// 将表格数据输出到 Excel 文件。
        /// </summary>
        /// <param name="tableData">表格数据。</param>
        /// <param name="materialType">物料类型。</param>
        /// <returns>返回 Excel 文件流。</returns>
        private static Stream ToExcel(TableDataCollector tableData, MaterialType materialType)
        {
            IWorkbook workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet(materialType.ToString());

            var rowIndex = 0;
            var rowColumnIndex = 0;

            // 创建列表名称
            var nameRow = sheet.CreateRow(rowIndex++);

            nameRow.CreateCell(rowColumnIndex++).SetCellValue("Supplier's name");

            foreach (var columnName in tableData.GetColumnNames().OrderBy(s => s))
            {
                nameRow.CreateCell(rowColumnIndex++).SetCellValue(columnName);
            }

            // 创建供应商行
            foreach (var lineName in tableData.GetLineNames())
            {
                var supplierRow = sheet.CreateRow(rowIndex++);
                rowColumnIndex = 0;

                supplierRow.CreateCell(rowColumnIndex++).SetCellValue(lineName);

                foreach (var columnName in tableData.GetColumnNames().OrderBy(s => s))
                {
                    float value;
                    if (tableData.GetCellValue(lineName, columnName, out value))
                    {
                        supplierRow.CreateCell(rowColumnIndex++).SetCellValue(value);
                    }
                    else
                    {
                        rowColumnIndex++;
                    }
                }
            }

            var memStream = new MemoryStream();
            workbook.Write(memStream);

            return memStream;
        }
    }
}