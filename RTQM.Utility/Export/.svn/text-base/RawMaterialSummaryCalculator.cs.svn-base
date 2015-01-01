using System;
using System.Data;
using System.Data.SqlClient;
using Lgsoft.RTQM.Application.RawMaterialQulityModule.DTOs;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 原材料汇总计算器。
    /// </summary>
    internal class RawMaterialSummaryCalculator : SummaryCalculatorBase<RawMaterialSummaryData>, IDisposable
    {
        private readonly SqlConnection _dbConnection;
        private readonly SqlDataReader _dataReader;
        private readonly DateRoundStrategy _roundStrategy;
        private bool _hasRow = true;

        /// <summary>
        /// 初始化原材料汇总计算器。
        /// </summary>
        /// <param name="dbConnection">数据库连接。</param>
        /// <param name="roundStrategy">汇总周期策略。</param>
        /// <param name="materialType">汇总的物料类型。</param>
        /// <param name="supplierId">汇总的供应商标识。</param>
        /// <param name="startDate">汇总的开始日期。</param>
        /// <param name="endDate">汇总的结束日期。</param>
        public RawMaterialSummaryCalculator(SqlConnection dbConnection, DateRoundStrategy roundStrategy,
                                            MaterialType? materialType = null, Guid? supplierId = null,
                                            DateTime? startDate = null, DateTime? endDate = null)
            : base(roundStrategy)
        {
            if (dbConnection == null)
                throw new ArgumentNullException("dbConnection");

            if (roundStrategy == null)
                throw new ArgumentNullException("roundStrategy");

            _dbConnection = dbConnection;
            _roundStrategy = roundStrategy;

            var sqlComm = new SqlCommand("select [po].[PODate] as [OrderDate], [ol].[Total], [ol].[QtyTotal], " +
                                         "[ol].[ConcessionCount], [ol].[RejectionCount], [ol].[ReworkCount], [ol].[ScrapCount] " +
                                         "from [lg_PurchaseOrderItems] as [ol] left join [lg_PurchaseOrders] as [po] " +
                                         "on [ol].[POId] = [po].[Id] where 1 = 1 ", _dbConnection);

            if (supplierId.HasValue)
            {
                sqlComm.CommandText += "and [ol].[SupplierId] = @p0 ";
                sqlComm.Parameters.Add("p0", SqlDbType.UniqueIdentifier).SqlValue = supplierId.Value;
            }

            if (startDate.HasValue)
            {
                sqlComm.CommandText += "and [po].[PODate] >= @p1 ";
                sqlComm.Parameters.Add("p1", SqlDbType.DateTime).SqlValue = startDate.Value;
            }

            if (endDate.HasValue)
            {
                sqlComm.CommandText += "and [po].[PODate] <= @p2 ";
                sqlComm.Parameters.Add("p2", SqlDbType.DateTime).SqlValue = endDate.Value;
            }

            if (materialType.HasValue)
            {
                sqlComm.CommandText += "and [ol].[MaterialType] = @p3 ";
                sqlComm.Parameters.Add("p3", SqlDbType.Int).Value = (int) materialType.Value;
            }

            sqlComm.CommandText += "order by [po].[PODate]";

            _dataReader = sqlComm.ExecuteReader();
        }

        #region 原材料详情查询方法

        /// <summary>
        /// 移动下一条原材料详细信息。
        /// </summary>
        /// <returns>还有详细信息返回 true，否则返回 false。</returns>
        protected bool NextRawMaterialDetail()
        {
            return _dataReader.Read();
        }

        /// <summary>
        /// 获取当前采购订单日期。
        /// </summary>
        /// <returns>返回采购订单日期。</returns>
        protected DateTime GetCurrentOrderDate()
        {
            return _dataReader.GetDateTime(0);
        }

        /// <summary>
        /// 获取当前来料总数。
        /// </summary>
        /// <returns>返回来料总数。</returns>
        protected int GetCurrentTotal()
        {
            return _dataReader.GetInt32(1);
        }

        /// <summary>
        /// 获取当前入库总数。
        /// </summary>
        /// <returns>返回入库总数。</returns>
        protected int GetCurrentQtyTotal()
        {
            return _dataReader.GetInt32(2);
        }

        /// <summary>
        /// 获取当前让步数量。
        /// </summary>
        /// <returns>返回让步数量。</returns>
        protected int GetCurrentConcessionCount()
        {
            return _dataReader.GetInt32(3);
        }

        /// <summary>
        /// 获取当前拒绝数量。
        /// </summary>
        /// <returns>返回拒绝数量。</returns>
        protected int GetCurrentRejectionCount()
        {
            return _dataReader.GetInt32(4);
        }

        /// <summary>
        /// 获取当前返工数量。
        /// </summary>
        /// <returns>返回返工数量。</returns>
        protected int GetCurrentReworkCount()
        {
            return _dataReader.GetInt32(5);
        }

        /// <summary>
        /// 获取当前报废数量。
        /// </summary>
        /// <returns>返回报废数量。</returns>
        protected int GetCurrentScrapCount()
        {
            return _dataReader.GetInt32(6);
        }

        #endregion

        #region Overrides of SummaryCalculatorBase<RawMaterialSummaryData>

        public override RawMaterialSummaryData GetNextRoundSummaryData()
        {
            if (!_hasRow)
                return null;

            if (!_roundStrategy.IsRoundInitialized())
            {
                _hasRow = NextRawMaterialDetail();

                if (_hasRow)
                {
                    _roundStrategy.SetRoundIdentificationDate(GetCurrentOrderDate());
                }
                else
                {
                    return null;
                }
            }
            else
            {
                _roundStrategy.SetRoundIdentificationDate(GetCurrentOrderDate());
            }

            var summaryData = new RawMaterialSummaryData {SummaryName = _roundStrategy.GetCurrentRoundName('.')};

            do
            {
                var orderDate = GetCurrentOrderDate();

                if (_roundStrategy.IsInCurrentDateRound(orderDate))
                {
                    summaryData.TotalSummary += GetCurrentTotal();
                    summaryData.QtyTotalSummary += GetCurrentQtyTotal();
                    summaryData.ConcessionCountSummary += GetCurrentConcessionCount();
                    summaryData.RejectionCountSummary += GetCurrentRejectionCount();
                    summaryData.ReworkCountSummary += GetCurrentReworkCount();
                    summaryData.ScrapCountSummary += GetCurrentScrapCount();
                }
                else
                {
                    break;
                }

                _hasRow = NextRawMaterialDetail();
            } while (_hasRow);

            return summaryData;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_dataReader != null && _dataReader.IsClosed == false)
            {
                _dataReader.Close();
                _dataReader.Dispose();
            }
        }

        #endregion
    }
}