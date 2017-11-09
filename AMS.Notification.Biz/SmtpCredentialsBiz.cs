using System;
using System.Data;
using System.Data.Common;
using AMS.DAL;
using AMS.Notification.Model;

namespace AMS.Notification.Biz
{
    public class SmtpCredentialsBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, SmtpCredentials objSmtpCredential)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "MailServer":
                        if (!Convert.IsDBNull(objDataReader["MailServer"]))
                        {
                            objSmtpCredential.MailServer = objDataReader["MailServer"].ToString();
                        }
                        break;
                    case "PortNumber":
                        if (!Convert.IsDBNull(objDataReader["PortNumber"]))
                        {
                            objSmtpCredential.PortNumber = Convert.ToInt32(objDataReader["PortNumber"].ToString());
                        }
                        break;


                    default:
                        break;
                }
            }
            objSmtpCredential.IsNew = false;
            objSmtpCredential.IsDirty = true;
            objSmtpCredential.IsDelete = false;
        }

        public SmtpCredentials GetSmtpCredentials()
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            SmtpCredentials objSmtpC = null;


            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "ams.uspGetSmtpCredentials",
                    CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    //DocumentBiz.GetApplicantDocuments(applicantId);
                    while (objDbDataReader.Read())
                    {
                        objSmtpC = new SmtpCredentials();
                        BuildModel(objDbDataReader, objSmtpC);
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


            return objSmtpC;
        }
    }
}