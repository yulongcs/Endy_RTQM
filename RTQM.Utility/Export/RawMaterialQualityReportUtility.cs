using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 原材料质量报告工具。
    /// </summary>
    public static class RawMaterialQualityReportUtility
    {
        /// <summary>
        /// 将原材料质量报告到 Excel 文件。
        /// </summary>
        /// <param name="materialType">要报告的物料类型。</param>
        /// <param name="controlLine">质量控制限。</param>
        /// <returns>返回 Excel 文件流。</returns>
        public static Stream RawMaterialQulityReportToExcel(MaterialType materialType, float controlLine)
        {
            var nowFinanceYearSummaryData = new TableDataCollector();
            var pastFinanceYearSummaryData = new TableDataCollector();

            using (
                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RTQMUnitOfWork"].ConnectionString))
            {
                conn.Open();

                var financeYearRound = DateRoundStrategy.CreateDateRoundStrategy(DateRoundTypes.FinanceYear);

                // 处理当前财年数据
                financeYearRound.SetRoundIdentificationDate(DateTime.Now);

                using (var nowFinanceYearSummaryCalculator = new RawMaterialSummaryCalculator(conn,
                                                                                   DateRoundStrategy.
                                                                                       CreateDateRoundStrategy(
                                                                                           DateRoundTypes.Month),
                                                                                   materialType, null,
                                                                                   financeYearRound.RoundStartDate,
                                                                                   financeYearRound.RoundEndDate))
                {
                    RawMaterialSummaryData summaryData;

                    while ((summaryData = nowFinanceYearSummaryCalculator.GetNextRoundSummaryData()) != null)
                    {
                        nowFinanceYearSummaryData.SetCellValue("Quantity tested", summaryData.SummaryName,
                                                               summaryData.TotalSummary);
                        nowFinanceYearSummaryData.SetCellValue("concession", summaryData.SummaryName,
                                                               summaryData.ConcessionCountSummary);
                        nowFinanceYearSummaryData.SetCellValue("rejection", summaryData.SummaryName,
                                                               summaryData.RejectionCountSummary);
                        nowFinanceYearSummaryData.SetCellValue("rework", summaryData.SummaryName,
                                                               summaryData.ReworkCountSummary);
                        nowFinanceYearSummaryData.SetCellValue("scrap", summaryData.SummaryName,
                                                               summaryData.ScrapCountSummary);
                        nowFinanceYearSummaryData.SetCellValue("Total Errors", summaryData.SummaryName,
                                                               summaryData.TotalSummary - summaryData.QtyTotalSummary);
                        nowFinanceYearSummaryData.SetCellValue("Q-Figure", summaryData.SummaryName,
                                                               (float)summaryData.QtyTotalSummary * 100 /
                                                               summaryData.TotalSummary);
                    }
                }
                // 处理以往5年财年数据
                financeYearRound.SetRoundIdentificationDate(
                    financeYearRound.RoundStartDate.AddYears(-5));

                for (var i = 0; i < 5; i++)
                {
                    using (var pastFinanceYearSummaryCalculator = new RawMaterialSummaryCalculator(conn,
                                                                                        DateRoundStrategy.
                                                                                            CreateDateRoundStrategy(
                                                                                                DateRoundTypes.
                                                                                                    FinanceYear),
                                                                                        materialType, null,
                                                                                        financeYearRound.
                                                                                            RoundStartDate,
                                                                                        financeYearRound.
                                                                                            RoundEndDate))
                    {
                        RawMaterialSummaryData summaryData;

                        summaryData = pastFinanceYearSummaryCalculator.GetNextRoundSummaryData();

                        if (summaryData != null)
                        {
                            pastFinanceYearSummaryData.SetCellValue("year data", summaryData.SummaryName,
                                                                    (float)summaryData.QtyTotalSummary * 100 /
                                                                    summaryData.TotalSummary);
                        }
                        else
                        {
                            pastFinanceYearSummaryData.SetCellValue("year data", financeYearRound.GetCurrentRoundName('.'),
                                                                    (float)0.0);
                        }

                        financeYearRound.NextRound();
                    }
                }
            }

            return ToExcel(nowFinanceYearSummaryData, pastFinanceYearSummaryData, materialType, controlLine);
        }

        /// <summary>
        /// 将表格数据输出到 Excel 文件。
        /// </summary>
        /// <param name="nowFinanceYearData">当前财年表格数据。</param>
        /// <param name="pastFinanceYearData">以往5年财年表格数据。</param>
        /// <param name="materialType">物料类型。</param>
        /// <param name="controlLine">质量控制限。</param>
        /// <returns>返回 Excel 文件流。</returns>
        private static Stream ToExcel(TableDataCollector nowFinanceYearData, TableDataCollector pastFinanceYearData,
                                      MaterialType materialType, float controlLine)
        {
            var templatefs =
                new FileStream(
                    HttpContext.Current.Server.MapPath("~/Template/raw materail incoming report template.xls"),
                    FileMode.Open, FileAccess.Read);
            var memtemplate = new MemoryStream();
            try
            {
                templatefs.CopyTo(memtemplate);
            }
            finally
            {
                templatefs.Close();
            }

            IWorkbook workbook = new HSSFWorkbook(memtemplate);
            var sheet = workbook.GetSheet("parts");

            workbook.SetSheetName(0, materialType == MaterialType.EPMaterial
                                         ? "EP's  parts incoming inspec"
                                         : "VI's  parts incoming inspec");
            sheet.GetRow(0).GetCell(10).SetCellValue(materialType == MaterialType.EPMaterial
                                                         ? "EP's parts (Incoming)"
                                                         : "VI's parts (Incoming)");
            sheet.GetRow(12).GetCell(12).SetCellValue(controlLine);
            sheet.GetRow(33).GetCell(18).SetCellValue(DateTime.Now.ToString("yyyy.MM.dd"));

            var financeYearRound = DateRoundStrategy.CreateDateRoundStrategy(DateRoundTypes.FinanceYear);
            financeYearRound.SetRoundIdentificationDate(DateTime.Now);
            var monthRound = DateRoundStrategy.CreateDateRoundStrategy(DateRoundTypes.Month);
            monthRound.SetRoundIdentificationDate(financeYearRound.RoundStartDate);

            for (var i = 0; i < 12; i++)
            {
                int intValue;
                float floatValue;
                
                nowFinanceYearData.GetCellValue("Quantity tested", monthRound.GetCurrentRoundName('.'), out intValue);
                sheet.GetRow(3).GetCell(6 + i).SetCellValue(intValue);

                nowFinanceYearData.GetCellValue("concession", monthRound.GetCurrentRoundName('.'), out intValue);
                sheet.GetRow(4).GetCell(6 + i).SetCellValue(intValue);

                nowFinanceYearData.GetCellValue("rework", monthRound.GetCurrentRoundName('.'), out intValue);
                sheet.GetRow(5).GetCell(6 + i).SetCellValue(intValue);

                nowFinanceYearData.GetCellValue("rejection", monthRound.GetCurrentRoundName('.'), out intValue);
                sheet.GetRow(6).GetCell(6 + i).SetCellValue(intValue);

                nowFinanceYearData.GetCellValue("scrap", monthRound.GetCurrentRoundName('.'), out intValue);
                sheet.GetRow(9).GetCell(6 + i).SetCellValue(intValue);

                nowFinanceYearData.GetCellValue("Total Errors", monthRound.GetCurrentRoundName('.'), out intValue);
                sheet.GetRow(10).GetCell(6 + i).SetCellValue(intValue);

                nowFinanceYearData.GetCellValue("Q-Figure", monthRound.GetCurrentRoundName('.'), out floatValue);
                sheet.GetRow(11).GetCell(6 + i).SetCellValue(floatValue);
                sheet.GetRow(38).GetCell(6 + i).SetCellValue(floatValue);
                sheet.GetRow(39).GetCell(6 + i).SetCellValue(controlLine);

                monthRound.NextRound();
            }

            financeYearRound.SetRoundIdentificationDate(financeYearRound.RoundStartDate.AddYears(-5));

            for (var i = 0; i < 5; i++)
            {
                float floatValue;

                pastFinanceYearData.GetCellValue("year data", financeYearRound.GetCurrentRoundName('.'), out floatValue);
                sheet.GetRow(36).GetCell(1 + i).SetCellValue(financeYearRound.RoundStartDate.ToString("yy") +
                                                             financeYearRound.RoundEndDate.ToString("yy"));
                sheet.GetRow(37).GetCell(1 + i).SetCellValue(floatValue);

                if (i == 4)
                {
                    sheet.GetRow(38).GetCell(1 + i).SetCellValue(floatValue);
                    sheet.GetRow(39).GetCell(1 + i).SetCellValue(controlLine);
                }

                financeYearRound.NextRound();
            }

            sheet.GetRow(2).GetCell(0).SetCellValue(string.Format("Fiscal year (FY){0}/{1}",
                                                                  financeYearRound.RoundStartDate.ToString("yyyy"),
                                                                  financeYearRound.RoundEndDate.ToString("yyyy")));

            sheet.GetRow(3).GetCell(18).CellFormula = "sum(G4:R4)";
            sheet.GetRow(4).GetCell(18).CellFormula = "sum(G5:R5)";
            sheet.GetRow(5).GetCell(18).CellFormula = "sum(G6:R6)";
            sheet.GetRow(6).GetCell(18).CellFormula = "sum(G7:R7)";
            sheet.GetRow(9).GetCell(18).CellFormula = "sum(G10:R10)";
            sheet.GetRow(10).GetCell(18).CellFormula = "sum(G11:R11)";
            sheet.GetRow(11).GetCell(18).CellFormula = "if(iserror(100-(s11/s4*100)),\"\",100-(s11/s4*100))";

            var memStream = new MemoryStream();
            workbook.Write(memStream);

            return memStream;
        }
    }
}