using System;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 日期周期策略。
    /// </summary>
    internal abstract class DateRoundStrategy
    {
        /// <summary>
        /// 初始化日期周期策略。
        /// </summary>
        protected DateRoundStrategy()
        {
            RoundStartDate = DateTime.MinValue;
            RoundEndDate = DateTime.MaxValue;
        }

        /// <summary>
        /// 使用标识日期设置日期周期。
        /// </summary>
        /// <param name="identificationDate">标识日期。</param>
        /// <remarks>
        /// 标识日期指日期周期中的任何一个日期，例如：
        /// 1、定义为2012年1月的周期，可以使用这个月内的任何一个日期作为标识日期；
        /// 2、定义为2012年第2周的周期，可以使用2012年1月8日至2012年1月14日范围内的任何一个日期作为标识日期。
        /// </remarks>
        public void SetRoundIdentificationDate(DateTime identificationDate)
        {
            RoundStartDate = NormalizedRoundStartDate(identificationDate);
            RoundEndDate = NormalizedRoundEndDate(identificationDate);
        }

        /// <summary>
        /// 周期的开始日期。
        /// </summary>
        public DateTime RoundStartDate { get; private set; }

        /// <summary>
        /// 周期的结束日期。
        /// </summary>
        public DateTime RoundEndDate { get; private set; }

        /// <summary>
        /// 日期周期是否已经初始化。
        /// </summary>
        /// <returns>已经初始化返回 true，否则返回 false。</returns>
        /// <remarks>首次使用 SetRoundIdentificationDate 方法将初始化日期周期。</remarks>
        public bool IsRoundInitialized()
        {
            return RoundStartDate != DateTime.MinValue && RoundEndDate != DateTime.MaxValue;
        }

        /// <summary>
        /// 指定日期是否在当前日期周期之内。
        /// </summary>
        /// <param name="dateTime">指定日期。</param>
        /// <returns>指定日期在当前日期周期之内返回 true，否则返回 false。</returns>
        public virtual bool IsInCurrentDateRound(DateTime dateTime)
        {
            if (!IsRoundInitialized())
                throw new InvalidOperationException("日期周期还未使用标识日期进行周期范围设置。");

            return dateTime.Date >= RoundStartDate.Date && dateTime.Date <= RoundEndDate.Date;
        }

        /// <summary>
        /// 根据标识日期返回特定日期周期的规范化周期开始日期。
        /// </summary>
        /// <param name="identificationDate">标识日期。</param>
        /// <returns>返回规范化的周期开始日期。</returns>
        public abstract DateTime NormalizedRoundStartDate(DateTime identificationDate);

        /// <summary>
        /// 根据标识日期返回特定日期周期的规范化周期结束日期。
        /// </summary>
        /// <param name="identificationDate">标识日期。</param>
        /// <returns>返回规范化的周期结束日期。</returns>
        public abstract DateTime NormalizedRoundEndDate(DateTime identificationDate);

        /// <summary>
        /// 将当前日期周期向后移动一个周期。
        /// </summary>
        public abstract void NextRound();

        /// <summary>
        /// 获取当前日期周期的名称。
        /// </summary>
        /// <returns>返回当前日期周期的名称。</returns>
        public virtual string GetCurrentRoundName(char separator)
        {
            if (!IsRoundInitialized())
                throw new InvalidOperationException("日期周期还未使用标识日期进行周期范围设置。");

            return RoundStartDate.Year.ToString("0000") + separator + RoundStartDate.Month.ToString("00") + separator +
                   RoundStartDate.Day.ToString("00") + " ~ " + RoundEndDate.Year.ToString("0000") + separator +
                   RoundEndDate.Month.ToString("00") + separator + RoundEndDate.Day.ToString("00");
        }

        /// <summary>
        /// 创建指定日期周期类型的日期周期策略。
        /// </summary>
        /// <param name="dateRoundType">日期周期类型。</param>
        /// <returns>返回日期周期策略。</returns>
        public static DateRoundStrategy CreateDateRoundStrategy(DateRoundTypes dateRoundType)
        {
            switch (dateRoundType)
            {
                case DateRoundTypes.Day:
                    return new DayRoundStrategy();
                case DateRoundTypes.Week:
                    return new WeekRoundStrategy();
                case DateRoundTypes.Month:
                    return new MonthRoundStrategy();
                case DateRoundTypes.FinanceYear:
                    return new FinanceYearRoundStrategy();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}