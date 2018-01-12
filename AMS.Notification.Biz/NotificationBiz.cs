using System;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Net.Mail;
using AMS.DAL;
using AMS.Notification.Model;

namespace AMS.Notification.Biz
{
    public class NotificationBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, NotificationMessages objNotifMsg)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "NotificationTypeID":
                        if (!Convert.IsDBNull(objDataReader["NotificationTypeID"]))
                        {
                            objNotifMsg.NotificationTypeID =
                                Convert.ToInt32(objDataReader["NotificationTypeID"].ToString());
                        }
                        break;
                    case "NotificationType":
                        if (!Convert.IsDBNull(objDataReader["NotificationType"]))
                        {
                            objNotifMsg.NotificationType = objDataReader["NotificationType"].ToString();
                        }
                        break;
                    case "ClassificationID":
                        if (!Convert.IsDBNull(objDataReader["ClassificationID"]))
                        {
                            objNotifMsg.ClassificationID = Convert.ToInt32(objDataReader["ClassificationID"].ToString());
                        }
                        break;
                    case "ClassificationName":
                        if (!Convert.IsDBNull(objDataReader["ClassificationName"]))
                        {
                            objNotifMsg.ClassificationName = objDataReader["ClassificationName"].ToString();
                        }
                        break;
                    case "NotificationMsgID":
                        if (!Convert.IsDBNull(objDataReader["NotificationMsgID"]))
                        {
                            objNotifMsg.NotificationMsgID =
                                Convert.ToInt32(objDataReader["NotificationMsgID"].ToString());
                        }
                        break;

                    case "Subject":
                        if (!Convert.IsDBNull(objDataReader["Subject"]))
                        {
                            objNotifMsg.Subject = objDataReader["Subject"].ToString();
                        }
                        break;
                    case "FromAddress":
                        if (!Convert.IsDBNull(objDataReader["FromAddress"]))
                        {
                            objNotifMsg.FromAddress = objDataReader["FromAddress"].ToString();
                        }
                        break;
                    case "FromAddressPssword":
                        if (!Convert.IsDBNull(objDataReader["FromAddressPssword"]))
                        {
                            objNotifMsg.FromAddressPssword = objDataReader["FromAddressPssword"].ToString();
                        }
                        break;
                    case "MessagesBody":
                        if (!Convert.IsDBNull(objDataReader["MessagesBody"]))
                        {
                            objNotifMsg.MessagesBody = objDataReader["MessagesBody"].ToString();
                        }
                        break;

                    case "Status":
                        if (!Convert.IsDBNull(objDataReader["Status"]))
                        {
                            objNotifMsg.Status = Convert.ToBoolean(objDataReader["Status"]);
                        }
                        break;


                    default:
                        break;
                }
            }
            objNotifMsg.IsNew = false;
            objNotifMsg.IsDirty = true;
            objNotifMsg.IsDelete = false;
        }


        public void SendEmail(NotificationMessages objMessages, string toAdress)
        {
            SmtpCredentialsBiz objSmtpCredentialsBiz = new SmtpCredentialsBiz();
            var objEmailDetail = GetEmailDetail(objMessages);
            var objSmtpCredentials = objSmtpCredentialsBiz.GetSmtpCredentials();
            var mailMessage = new MailMessage(objEmailDetail.FromAddress, toAdress)
            {
                Subject = objEmailDetail.Subject,
                IsBodyHtml = true,
                Body = objEmailDetail.MessagesBody
              
            };
            var smtpClient = new SmtpClient(objSmtpCredentials.MailServer, objSmtpCredentials.PortNumber)
            {
                Credentials = new NetworkCredential
                {
                    UserName = objEmailDetail.FromAddress,
                    Password = objEmailDetail.FromAddressPssword
                },
                EnableSsl = false
            };
            smtpClient.Send(mailMessage);
        }

        public void SendEmail(NotificationMessages objMessages, string toAdress,string messageBody)
        {
            SmtpCredentialsBiz objSmtpCredentialsBiz = new SmtpCredentialsBiz();
            var objEmailDetail = GetEmailDetail(objMessages);
            var objSmtpCredentials = objSmtpCredentialsBiz.GetSmtpCredentials();
            var mailMessage = new MailMessage(objEmailDetail.FromAddress, toAdress)
            {
                Subject = objEmailDetail.Subject,
                IsBodyHtml = true,
                Body = messageBody

            };
            var smtpClient = new SmtpClient(objSmtpCredentials.MailServer, objSmtpCredentials.PortNumber)
            {
                Credentials = new NetworkCredential
                {
                    UserName = objEmailDetail.FromAddress,
                    Password = objEmailDetail.FromAddressPssword
                },
                EnableSsl = false
            };
            smtpClient.Send(mailMessage);
        }
        public void SendEmail(NotificationMessages objMessages, string fromAdress, string toAdress, string messageBody)
        {
            SmtpCredentialsBiz objSmtpCredentialsBiz = new SmtpCredentialsBiz();
            var objEmailDetail = GetEmailDetail(objMessages);
            var objSmtpCredentials = objSmtpCredentialsBiz.GetSmtpCredentials();
            var mailMessage = new MailMessage(fromAdress, toAdress)
            {
                Subject = objEmailDetail.Subject,
                IsBodyHtml = true,
                Body = messageBody

            };
            var smtpClient = new SmtpClient(objSmtpCredentials.MailServer, objSmtpCredentials.PortNumber)
            {
                Credentials = new NetworkCredential
                {
                    UserName = objEmailDetail.FromAddress,
                    Password = objEmailDetail.FromAddressPssword
                },
                EnableSsl = false
            };
            smtpClient.Send(mailMessage);
        }
        private NotificationMessages GetEmailDetail(NotificationMessages objMessages)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            NotificationMessages objNotifMessages = null;
            objDbCommand.AddInParameter("NotificationTypeID", objMessages.NotificationTypeID);
            objDbCommand.AddInParameter("ClassificationID", objMessages.ClassificationID);
             

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "ams.uspGetEmailDetail",
                    CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    //DocumentBiz.GetApplicantDocuments(applicantId);
                    while (objDbDataReader.Read())
                    {
                        objNotifMessages = new NotificationMessages();
                        BuildModel(objDbDataReader, objNotifMessages);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }


            return objNotifMessages;
        }
    }
}