namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 汇总计算器基类。
    /// </summary>
    /// <typeparam name="TSummaryData">汇总数据类型。</typeparam>
    abstract class SummaryCalculatorBase<TSummaryData>
        where TSummaryData : class
    {
        /// <summary>
        /// 使用日期周期策略初始化汇总计算器。
        /// </summary>
        /// <param name="roundStrategy">日期周期策略。</param>
        protected SummaryCalculatorBase(DateRoundStrategy roundStrategy)
        {
            RoundStrategy = roundStrategy;
        }

        /// <summary>
        /// 汇总计算器的日期周期策略。
        /// </summary>
        protected DateRoundStrategy RoundStrategy { get; private set; }

        /// <summary>
        /// 获取下一汇总周期的汇总数据。
        /// </summary>
        /// <returns>返回下一汇总周期的汇总数据，如果没有更多数据可供汇总则返回 null。</returns>
        public abstract TSummaryData GetNextRoundSummaryData();
    }
}
