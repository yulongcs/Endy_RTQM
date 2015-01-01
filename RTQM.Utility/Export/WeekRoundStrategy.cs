using System;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 以周为周期的策略。
    /// </summary>
    class WeekRoundStrategy : DateRoundStrategy
    {
        #region Overrides of DateRoundStrategy

        public override DateTime NormalizedRoundStartDate(DateTime identificationDate)
        {
            return identificationDate.Subtract(TimeSpan.FromDays((int) identificationDate.DayOfWeek));
        }

        public override DateTime NormalizedRoundEndDate(DateTime identificationDate)
        {
            return identificationDate.Add(TimeSpan.FromDays(6 - (int) identificationDate.DayOfWeek));
        }

        public override void NextRound()
        {
            if (!IsRoundInitialized())
                throw new InvalidOperationException("日期周期还未使用标识日期进行周期范围设置。");

            SetRoundIdentificationDate(RoundEndDate.AddDays(1));
        }

        #endregion
    }
}
