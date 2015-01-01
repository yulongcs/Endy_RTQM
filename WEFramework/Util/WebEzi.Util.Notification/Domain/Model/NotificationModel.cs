using System;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Model;
using WebEzi.Core.Exception.Domain;

namespace WebEzi.Util.Notification.Domain.Model
{
    public abstract class NotificationModel : AggregateRootModelBase
    {
        #region Contruction

        protected NotificationModel(WEKey key)
            : base(key)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// To
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Ready Send Time
        /// </summary>
        public WEDateTime ReadySendTime { get; set; }

        /// <summary>
        /// Actual Send Time
        /// </summary>
        public WEDateTime ActualSendTime { get; internal set; }

        /// <summary>
        /// Failed Message
        /// </summary>
        public string FailedMessage { get; internal set; }

        /// <summary>
        /// Date Created
        /// </summary>
        public WEDateTime DateCreated { get; internal set; }

        /// <summary>
        /// Status
        /// </summary>
        public NotificationStatusConst Status { get; internal set; }

        #endregion

        #region Behaviours

        public void SentSuccessful()
        {
            this.ActualSendTime = DateTime.Now;
            this.Status = NotificationStatusConst.Sent;
        }

        public void SentFailed(string failedMessage)
        {
            this.ActualSendTime = DateTime.Now;
            this.FailedMessage = failedMessage;

            this.Status = NotificationStatusConst.Failed;
        }

        #endregion

        #region Check Model

        /// <summary>
        /// Check model
        /// </summary>
        protected override void CheckModel()
        {
            if(string.IsNullOrEmpty(this.To))
            {
                throw new ModelException("To Required.");
            }

            if (string.IsNullOrEmpty(this.Subject))
            {
                throw new ModelException("Subject Required.");
            }

            if(this.ReadySendTime.IsNull())
            {
                throw new ModelException("Ready Time Required.");
            }

            if(this.Status != NotificationStatusConst.Awaiting)
            {
                if(this.ActualSendTime.IsNull())
                {
                    throw new ModelException("Actual Time Required.");
                }
            }

            if(this.Status == NotificationStatusConst.Failed)
            {
                if (string.IsNullOrEmpty(this.FailedMessage))
                {
                    throw new ModelException("Failed Message Required.");
                }
            }
        }

        #endregion
    }
}
