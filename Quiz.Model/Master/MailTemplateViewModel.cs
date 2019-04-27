using System;

namespace Quiz.Model.Master
{
    public class MailTemplateViewModel
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public string Subject { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Body { get; set; }
        public string BaseURL { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
