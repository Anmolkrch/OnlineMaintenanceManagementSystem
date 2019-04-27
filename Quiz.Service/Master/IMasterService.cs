using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Quiz.Service.Master
{
    public interface IMasterService
    {

        bool SendAccountCreatationEmail(string subject, string mailBody, UserViewModel userData, long logId = 0);
        void EmailSendUsingSmtpClient(string sMTPClientName, string fromUserName, string fromPassword, string subject,
            string emailBody, string fromEmailaddress, string toEmailaddress, int port, bool IsBodyHtml, bool EnableSsl);

    }
}
