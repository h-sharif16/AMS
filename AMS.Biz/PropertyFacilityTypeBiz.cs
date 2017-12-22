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
    public class PropertyFacilityTypeBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, PropertyFacilityType objFacilityType)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "FacilityTypeId":
                        if (!Convert.IsDBNull(objDataReader["FacilityTypeId"]))
                        {
                            objFacilityType.FacilityTypeId =Convert.ToInt32( objDataReader["FacilityTypeId"].ToString());
                        }
                        break;
                    case "FacilityName":
                        if (!Convert.IsDBNull(objDataReader["FacilityName"]))
                        {
                            objFacilityType.FacilityName = objDataReader["FacilityName"].ToString();
                        }
                        break;
                     
                    case "Status":
                        if (!Convert.IsDBNull(objDataReader["Status"]))
                        {
                            objFacilityType.Status = Convert.ToBoolean(objDataReader["Status"]);
                        }
                        break;
                    case "EntryDate":
                        if (!Convert.IsDBNull(objDataReader["EntryDate"]))
                        {
                            objFacilityType.EntryDate = Convert.ToDateTime(objDataReader["EntryDate"]);
                        }
                        break;

                    case "EntryBy":
                        if (!Convert.IsDBNull(objDataReader["EntryBy"]))
                        {
                            objFacilityType.EntryBy = objDataReader["EntryBy"].ToString();
                        }
                        break;
                    case "UpdateDate":
                        if (!Convert.IsDBNull(objDataReader["UpdateDate"]))
                        {
                            objFacilityType.UpdateDate = Convert.ToDateTime(objDataReader["UpdateDate"]);
                        }
                        break;
                    case "UpdateBy":
                        if (!Convert.IsDBNull(objDataReader["UpdateBy"]))
                        {
                            objFacilityType.UpdateBy = objDataReader["UpdateBy"].ToString();
                        }
                        break;


                    default:
                        break;
                }
            }
            objFacilityType.IsNew = false;
            objFacilityType.IsDirty = true;
            objFacilityType.IsDelete = false;
        }

        public static List<StaticListItem> GetPropertyFacilityType()
        {
            try
            {
                return CommonBiz.GetCheckBoxList("ams.uspGetPropertyFacilityType");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetPropertyFacilityType(int facilityId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("FacilityId", facilityId);
                return CommonBiz.GetCheckBoxList("ams.uspGetPropertyFacilityType", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static int SaveFacilities(IDataAccess objDataAccess, DbCommand objDCommand, List<PropertyFacilityType> objfacilityList,  int propertyId)
        {
            int noOfAffacted = 0;
            foreach (PropertyFacilityType objFacilityType in objfacilityList)
            {
                 

                noOfAffacted += SaveFacilities(objDataAccess, objDCommand, objFacilityType,propertyId);
            }
            return noOfAffacted;
        }
        private static int SaveFacilities(IDataAccess objDataAccess, DbCommand objDCommand, PropertyFacilityType objFacility, int propertyId)
        {
            objDCommand.Parameters.Clear();
            objDCommand.AddInParameter("FacilityTypeId", objFacility.FacilityTypeId);
            objDCommand.AddInParameter("PropertyId", propertyId);
             
            return objDataAccess.ExecuteNonQuery(objDCommand, "ams.uspInsertPropertyWiseFacility", CommandType.StoredProcedure);
        }
    }
}