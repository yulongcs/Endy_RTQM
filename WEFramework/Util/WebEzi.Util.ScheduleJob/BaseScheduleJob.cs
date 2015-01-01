using Quartz;

namespace WebEzi.Util.ScheduleJob
{
    public abstract class BaseScheduleJob : IJob
    {
        public abstract void Execute(JobExecutionContext context);
    }
}
