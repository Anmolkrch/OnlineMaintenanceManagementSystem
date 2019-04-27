using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Quiz.Core.EntityModel;
using Quiz.ViewModel;
using QuizModel.ViewModel;
using System.Data.Entity;
using Quiz.Model.Master;
using System.Net.Mail;
using System.Text;

namespace Quiz.Service.Master
{
    public class MasterService : IMasterService
    {

        #region Public_Methods
        
        public bool SendAccountCreatationEmail(string subject, string mailBody, UserViewModel userData, long logId = 0)
        {
            try
            {
                // Log in notificatoin table
                NotificationViewModel notification = new NotificationViewModel();
                MasterService masterService = new MasterService();
                if (subject == "Service Request Generated")
                {
                    notification.MailType = 1;// First time user create
                }
                else
                {
                    notification.MailType = 1;// First time user create
                }
                notification.To = userData.Email;
                notification.Subject = subject;
                notification.Body = mailBody.ToString();
                notification.Status = 1;
                notification.ActionById = Convert.ToInt64(userData.Id);
                notification.SendCount = 1;
                notification.CreatedBy = logId;
                notification.CreationDate = DateTime.UtcNow;
               // masterService.SaveNotifications(notification);
                notification = null;
                EmailSendUsingSmtpClient(AppConfig.Host, AppConfig.FromUserName, AppConfig.FromPassword, subject, mailBody.ToString(), AppConfig.FromEmail, userData.Email, int.Parse(AppConfig.Port), false, true);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
        public void EmailSendUsingSmtpClient(string sMTPClientName, string fromUserName, string fromPassword, string subject, string emailBody,
            string fromEmailaddress, string toEmailaddress, int port, bool IsBodyHtml, bool EnableSsl)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(sMTPClientName);
                smtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                System.Net.NetworkCredential(fromUserName, fromPassword);
                smtpClient.Credentials = basicAuthenticationInfo;
                smtpClient.Port = port;
                smtpClient.Host = sMTPClientName;
                MailAddress from = new MailAddress(fromEmailaddress);
                MailAddress to = new MailAddress(toEmailaddress);
                MailMessage mailMessage = new MailMessage(from, to);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Body = emailBody;
                smtpClient.EnableSsl = EnableSsl;
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
