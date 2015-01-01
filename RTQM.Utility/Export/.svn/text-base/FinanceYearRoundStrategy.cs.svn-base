using System;

namespace Lgsoft.RTQM.Utility.Export
{
    /// <summary>
    /// 以财年为周期的策略。
    /// </summary>
    class FinanceYearRoundStrategy : DateRoundStrategy
    {
        #region Overrides of DateRoundStrategy

        public override DateTime NormalizedRoundStartDate(DateTime identificationDate)
        {
            return identificationDate.Month < 10
                       ? new DateTime(identificationDate.Year - 1, 10, 1)
                       : new DateTime(identificationDate.Year, 10, 1);
        }

        public override DateTime NormalizedRoundEndDate(DateTime identificationDate)
        {
            return identificationDate.Month < 10
                       ? new DateTime(identificationDate.Year, 9, 30)
                       : new DateTime(identificationDate.Year + 1, 9, 30);
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

            return RoundStartDate.Year.ToString("0000") + separator + RoundStartDate.Month.ToString("00") + " ~ " +
                   RoundEndDate.Year.ToString("0000") + separator + RoundEndDate.Month.ToString("00");
        }

        #endregion
    }
}
