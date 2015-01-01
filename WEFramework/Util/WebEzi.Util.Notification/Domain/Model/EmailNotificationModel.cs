using WebEzi.Base.DefinedData;
using WebEzi.Core.Exception.Domain;

namespace WebEzi.Util.Notification.Domain.Model
{
    public class EmailNotificationModel : NotificationModel
    {
        #region Contruction

        public EmailNotificationModel(WEKey key)
            : base(key)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// From
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Attachment file path
        /// </summary>
        private WEList<WEAttachment> _attachments;
        public WEList<WEAttachment> Attachments
        {
            get { return _attachments ?? (_attachments = new WEList<WEAttachment>()); }
            set { _attachments = value; }
        }

        #endregion

        #region Check Model

        /// <summary>
        /// Check model
        /// </summary>
        protected override void CheckModel()
        {
            base.CheckModel();

            if (string.IsNullOrEmpty(this.From))
            {
                throw new ModelException("From Required.");
            }
        }

        #endregion
    }
}
