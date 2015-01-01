using System;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 以月为周期的策略。
    /// </summary>
    class MonthRoundStrategy : DateRoundStrategy
    {
        #region Overrides of DateRoundStrategy

        public override DateTime NormalizedRoundStartDate(DateTime identificationDate)
        {
            return new DateTime(identificationDate.Year, identificationDate.Month, 1);
        }

        public override DateTime NormalizedRoundEndDate(DateTime identificationDate)
        {
            return new DateTime(identificationDate.Year, identificationDate.Month,
                                DateTime.DaysInMonth(identificationDate.Year, identificationDate.Month));
        }

        public override void NextRound()
        {
            if (!IsRoundInitialized())
                throw new InvalidOperationException("日期周期还未使用标识日期进行周期范围设置。");

            SetRoundIdentificationDate(RoundEndDate.AddDays(1));
        }

        public override string GetCurrentRoundName(char separator)
        {
            if (!IsRoundInitialized())
                throw new InvalidOperationException("日期周期还未使用标识日期进行周期范围设置。");

            return RoundStartDate.Year.ToString("0000") + separator + RoundStartDate.Month.ToString("00");
        }

        #endregion
    }
}
