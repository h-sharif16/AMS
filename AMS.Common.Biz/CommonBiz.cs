using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using AMS.Common.Model;
using AMS.DAL;

namespace AMS.Common.Biz
{
    public class CommonBiz
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumeric(object Expression)
        {
            double retNum;

            var isNum = double.TryParse(Convert.ToString(Expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo,
                out retNum);
            return isNum;
        }

        public static string GetSwcSH1(string value)
        {
            var algorithm = SHA1.Create();
            var data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            var sh1 = "";
            for (var i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
        }

        /// <summary>
        /// This method helps to fill the dropdown with specific stored procedure.
        /// </summary>
        /// <param name="spName">Provide stored procedure name</param>
        /// <returns></returns>
        public static List<StaticListItem> GetCombo(string spName)
        {
            List<StaticListItem> objStaticListItemLst = new List<StaticListItem>();
            IDataAccess objDataAccess = DataAccess.NewDataAccess();
            DbCommand objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, spName, CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        StaticListItem objStaticListItem = new StaticListItem();
                        objStaticListItem.DataValue = objDbDataReader[0].ToString();
                        objStaticListItem.DataText = objDbDataReader[1].ToString();
                        objStaticListItemLst.Add(objStaticListItem);
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

            objStaticListItemLst.Insert(0, new StaticListItem("", "--Select Option--"));
            return objStaticListItemLst;
        }
     

        /// <summary>
        /// This method helps to fill the dropdown with specific stored procedure and default value.
        /// </summary>
        /// <param name="spName">Provide stored procedure name</param>
        /// <param name="defaultValue">Provide default value</param>
        /// <returns></returns>
        public static List<StaticListItem> GetCombo(string spName, string defaultValue)
        {
            List<StaticListItem> objStaticListItemLst = new List<StaticListItem>();
            IDataAccess objDataAccess = DataAccess.NewDataAccess();
            DbCommand objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, spName, CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        StaticListItem objStaticListItem = new StaticListItem();
                        objStaticListItem.DataValue = objDbDataReader[0].ToString();
                        objStaticListItem.DataText = objDbDataReader[1].ToString();
                        objStaticListItemLst.Add(objStaticListItem);
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

            objStaticListItemLst.Insert(0, new StaticListItem("", defaultValue));
            return objStaticListItemLst;
        }

        /// <summary>
        ///  This method helps to fill the dropdown with specific stored procedure and paramter list with value.
        /// </summary>
        /// <param name="spName">Provide stored procedure name</param>
        /// <param name="parameterList">Provide parameter name with value</param>
        /// <returns></returns>
        public static List<StaticListItem> GetCombo(string spName, Dictionary<string, object> parameterList)
        {
            List<StaticListItem> objStaticListItemLst = new List<StaticListItem>();
            IDataAccess objDataAccess = DataAccess.NewDataAccess();
            DbCommand objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            if (parameterList.Count > 0)
            {
                foreach (KeyValuePair<string, object> pair in parameterList)
                {
                    objDbCommand.AddInParameter(pair.Key, pair.Value);
                }
            }
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, spName, CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        StaticListItem objStaticListItem = new StaticListItem();
                        objStaticListItem.DataValue = objDbDataReader[0].ToString();
                        objStaticListItem.DataText = objDbDataReader[1].ToString();
                        objStaticListItemLst.Add(objStaticListItem);
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

            objStaticListItemLst.Insert(0, new StaticListItem("", "--Select Option--"));
            return objStaticListItemLst;
        }

        public static List<StaticListItem> GetCombo(string spName, string defaultValue, Dictionary<string, object> parameterList)
        {
            List<StaticListItem> objStaticListItemLst = new List<StaticListItem>();
            IDataAccess objDataAccess = DataAccess.NewDataAccess();
            DbCommand objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            if (parameterList.Count > 0)
            {
                foreach (KeyValuePair<string, object> pair in parameterList)
                {
                    objDbCommand.AddInParameter(pair.Key, pair.Value);
                }
            }
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, spName, CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        StaticListItem objStaticListItem = new StaticListItem();
                        objStaticListItem.DataValue = objDbDataReader[0].ToString();
                        objStaticListItem.DataText = objDbDataReader[1].ToString();
                        objStaticListItemLst.Add(objStaticListItem);
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

            objStaticListItemLst.Insert(0, new StaticListItem("", defaultValue));
            return objStaticListItemLst;
        }

        public static List<StaticListItem> GetCheckBoxList(string spName)
        {
            List<StaticListItem> objStaticListItemLst = new List<StaticListItem>();
            IDataAccess objDataAccess = DataAccess.NewDataAccess();
            DbCommand objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, spName, CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        StaticListItem objStaticListItem = new StaticListItem();
                        objStaticListItem.DataValue = objDbDataReader[0].ToString();
                        objStaticListItem.DataText = objDbDataReader[1].ToString();
                        objStaticListItemLst.Add(objStaticListItem);
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

         
            return objStaticListItemLst;
        }
        public static List<StaticListItem> GetCheckBoxList(string spName, Dictionary<string, object> parameterList)
        {
            List<StaticListItem> objStaticListItemLst = new List<StaticListItem>();
            IDataAccess objDataAccess = DataAccess.NewDataAccess();
            DbCommand objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            if (parameterList.Count > 0)
            {
                foreach (KeyValuePair<string, object> pair in parameterList)
                {
                    objDbCommand.AddInParameter(pair.Key, pair.Value);
                }
            }
            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, spName, CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        StaticListItem objStaticListItem = new StaticListItem();
                        objStaticListItem.DataValue = objDbDataReader[0].ToString();
                        objStaticListItem.DataText = objDbDataReader[1].ToString();
                        objStaticListItemLst.Add(objStaticListItem);
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

            
            return objStaticListItemLst;
        }
    }
}