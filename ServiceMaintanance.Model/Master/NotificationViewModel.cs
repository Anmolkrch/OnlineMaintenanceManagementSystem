using System;

namespace ServiceMaintanance.Model.Master
{
    public class NotificationViewModel
    {
        public long Id { get; set; }
        public int MailType { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Status { get; set; }
        public Nullable<long> ActionById { get; set; }
        public Nullable<int> SendCount { get; set; }
        public string ErrorMessage { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string CreatedByUser { get; set; }
    }
}
