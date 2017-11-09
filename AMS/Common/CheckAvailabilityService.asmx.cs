using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using AMS.Common.Model;
using AMS.DAL;

namespace AMS.Common
{
    /// <summary>
    ///     Summary description for CheckAvailabilityService
    /// </summary>
    [WebService(Namespace = "http://pentasoftbd.com/Common/CheckAvailabilityService.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   
    [ScriptService]
    public class CheckAvailabilityService : WebService
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        [WebMethod]
        public void CheckAvailabitity(string SearchString, string TableName, string TableColumn)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            var isValueExists = false;
            var objCheckAvailable = new CheckAvailable();
            objDbCommand.AddInParameter("SearchString", SearchString);
            objDbCommand.AddInParameter("TableName", TableName);
            objDbCommand.AddInParameter("TableColumn", TableColumn);
            try
            {
                isValueExists =
                    Convert.ToBoolean(objDataAccess.ExecuteScalar(objDbCommand, "ams.uspGetIsAvailable",
                        CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
            objCheckAvailable.SearchString = SearchString;
            objCheckAvailable.ValueExists = isValueExists;
            var js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(objCheckAvailable));
        }

        //    DataTable objDataTable = objDataReader.GetSchemaTable();
        //{

        //private void BuildModel(DbDataReader objDataReader, CheckAvailable objCheckAvailable)
        //    foreach (DataRow dr in objDataTable.Rows)
        //    {
        //        String column = dr.ItemArray[0].ToString();
        //        switch (column)
        //        {
        //            case "SearchString":
        //                if (!Convert.IsDBNull(objDataReader["SearchString"]))
        //                {
        //                    objCheckAvailable.SearchString = objDataReader["SearchString"].ToString();
        //                }
        //                break;
        //            case "ValueExists":
        //                if (!Convert.IsDBNull(objDataReader["ValueExists"]))
        //                {
        //                    objCheckAvailable.ValueExists =Convert.ToBoolean(objDataReader["ValueExists"].ToString());
        //                }
        //                break;


        //            default:
        //                break;

        //        }
        //    }

        //}
    }
}