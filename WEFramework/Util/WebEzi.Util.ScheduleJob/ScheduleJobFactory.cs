using Quartz;
using log4net;

namespace WebEzi.Util.ScheduleJob
{
    public class ScheduleJobFactory
    {
        #region Contruction

        private ScheduleJobFactory()
        {
        }

        private static readonly object padlock = new object();
        private static ScheduleJobFactory _scheduleJobFactory;

        public static ScheduleJobFactory GetInstance()
        {
            lock (padlock)
            {
                if (_scheduleJobFactory == null)
                {
                    _scheduleJobFactory = new ScheduleJobFactory();
                }

                return _scheduleJobFactory;
            }
        }

        #endregion

        #region Properties

        private IScheduler Scheduler { get; set; }

        private ILog Log { get; set; }

        #endregion

        #region Methods

        public void Init(ILog log)
        {
            lock (padlock)
            {
                if (this.Scheduler == null)
                {
                    this.Log = log;

                    this.Log.Info("Scheduler Init.");

                    this.Scheduler = new Quartz.Impl.StdSchedulerFactory().GetScheduler();
                }
            }
        }

        public void InsertJob(JobDetail job, CronTrigger trigger)
        {
            this.Log.Info("Insert Job "+ job.Name);

            Scheduler.AddJob(job, true);
            Scheduler.ScheduleJob(trigger);
        }

        public void Start()
        {
            if (Scheduler != null && !Scheduler.IsStarted)
            {
                this.Log.Info("Scheduler Start.");

                Scheduler.Start();
            }
        }

        public void Close()
        {
            if (Scheduler != null && Scheduler.IsStarted)
            {
                this.Log.Info("Scheduler End.");

                Scheduler.Shutdown();
            }
        }

        #endregion
    }
}
