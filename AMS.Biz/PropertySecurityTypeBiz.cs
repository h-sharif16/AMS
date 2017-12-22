using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using AMS.Common.Biz;
using AMS.Common.Model;
using AMS.DAL;
 
using AMS.Model;

namespace AMS.Biz
{
    public class PropertySecurityTypeBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, PropertySecurityType objSecurityType)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "SecurityTypeId":
                        if (!Convert.IsDBNull(objDataReader["SecurityTypeId"]))
                        {
                            objSecurityType.SecurityTypeId = Convert.ToInt32( objDataReader["SecurityTypeId"].ToString());
                        }
                        break;
                    case "SecurityType":
                        if (!Convert.IsDBNull(objDataReader["SecurityType"]))
                        {
                            objSecurityType.SecurityType = objDataReader["SecurityType"].ToString();
                        }
                        break;
                     
 
                    case "Status":
                        if (!Convert.IsDBNull(objDataReader["Status"]))
                        {
                            objSecurityType.Status = Convert.ToBoolean(objDataReader["Status"]);
                        }
                        break;
                    case "EntryDate":
                        if (!Convert.IsDBNull(objDataReader["EntryDate"]))
                        {
                            objSecurityType.EntryDate = Convert.ToDateTime(objDataReader["EntryDate"]);
                        }
                        break;

                    case "EntryBy":
                        if (!Convert.IsDBNull(objDataReader["EntryBy"]))
                        {
                            objSecurityType.EntryBy = objDataReader["EntryBy"].ToString();
                        }
                        break;
                    case "UpdateDate":
                        if (!Convert.IsDBNull(objDataReader["UpdateDate"]))
                        {
                            objSecurityType.UpdateDate = Convert.ToDateTime(objDataReader["UpdateDate"]);
                        }
                        break;
                    case "UpdateBy":
                        if (!Convert.IsDBNull(objDataReader["UpdateBy"]))
                        {
                            objSecurityType.UpdateBy = objDataReader["UpdateBy"].ToString();
                        }
                        break;


                    default:
                        break;
                }
            }
            objSecurityType.IsNew = false;
            objSecurityType.IsDirty = true;
            objSecurityType.IsDelete = false;
        }

        public static List<StaticListItem> GetPropertySecurityType()
        {
            try
            {
                return CommonBiz.GetCheckBoxList("ams.uspGetPropertySecurityType");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetPropertySecurityType(int securityTypeId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("SecurityTypeId", securityTypeId);
                return CommonBiz.GetCheckBoxList("ams.uspGetPropertySecurityType", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static int SaveSecurities(IDataAccess objDataAccess, DbCommand objDCommand, List<PropertySecurityType> objSecurityList, int propertyId)
        {
            int noOfAffacted = 0;
            foreach (PropertySecurityType objSecurityType in objSecurityList)
            {


                noOfAffacted += SaveSecurities(objDataAccess, objDCommand, objSecurityType, propertyId);
            }
            return noOfAffacted;
        }
        private static int SaveSecurities(IDataAccess objDataAccess, DbCommand objDCommand, PropertySecurityType objSecurity, int propertyId)
        {
            objDCommand.Parameters.Clear();
            objDCommand.AddInParameter("SecurityTypeId", objSecurity.SecurityTypeId);
            objDCommand.AddInParameter("PropertyId", propertyId);

            return objDataAccess.ExecuteNonQuery(objDCommand, "ams.uspInsertPropertyWiseSecurity", CommandType.StoredProcedure);
        }
    }
}