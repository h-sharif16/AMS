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
    public class PropertyBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, Property objProperty)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();

                switch (column)
                {
                    case "PropertyId":
                        if (!Convert.IsDBNull(objDataReader["PropertyId"]))
                        {
                            objProperty.PropertyId = Convert.ToInt32(objDataReader["PropertyId"].ToString());
                        }
                        break;
                    case "PropertyName":
                        if (!Convert.IsDBNull(objDataReader["PropertyName"]))
                        {
                            objProperty.PropertyName = objDataReader["PropertyName"].ToString();
                        }
                        break;
                    case "PropertyTypeId":
                        if (!Convert.IsDBNull(objDataReader["PropertyTypeId"]))
                        {
                            objProperty.PropertyTypeId = Convert.ToInt32(objDataReader["PropertyTypeId"].ToString());
                        }
                        break; 
                    case "LandloadId":
                        if (!Convert.IsDBNull(objDataReader["LandloadId"]))
                        {
                            objProperty.LandloadId = objDataReader["LandloadId"].ToString();
                        }
                        break;
                    case "BuiltYear":
                        if (!Convert.IsDBNull(objDataReader["BuiltYear"]))
                        {
                            objProperty.BuiltYear = Convert.ToDateTime(objDataReader["BuiltYear"].ToString());
                        }
                        break;
                    case "CountryID":
                        if (!Convert.IsDBNull(objDataReader["CountryID"]))
                        {
                            objProperty.CountryID = Convert.ToInt32(objDataReader["CountryID"].ToString());
                        }
                        break;
                    case "DivisionId":
                        if (!Convert.IsDBNull(objDataReader["DivisionId"]))
                        {
                            objProperty.DivisionId = Convert.ToInt32(objDataReader["DivisionId"].ToString());
                        }
                        break;
                    case "DistrictId":
                        if (!Convert.IsDBNull(objDataReader["DistrictId"]))
                        {
                            objProperty.DistrictId = Convert.ToInt32(objDataReader["DistrictId"].ToString());
                        }
                        break;
                    case "UpazilaId":
                        if (!Convert.IsDBNull(objDataReader["UpazilaId"]))
                        {
                            objProperty.CountryID = Convert.ToInt32(objDataReader["UpazilaId"].ToString());
                        }
                        break;
                     

                    case "HoldingNo":
                        if (!Convert.IsDBNull(objDataReader["HoldingNo"]))
                        {
                            objProperty.HoldingNo = objDataReader["HoldingNo"].ToString();
                        }
                        break;
                    case "RoadNo":
                        if (!Convert.IsDBNull(objDataReader["RoadNo"]))
                        {
                            objProperty.RoadNo = objDataReader["RoadNo"].ToString();
                        }
                        break;
                    case "SectorOrBlock":
                        if (!Convert.IsDBNull(objDataReader["SectorOrBlock"]))
                        {
                            objProperty.SectorOrBlock = objDataReader["SectorOrBlock"].ToString();
                        }
                        break;
                    case "TotalSpace":
                        if (!Convert.IsDBNull(objDataReader["TotalSpace"]))
                        {
                            objProperty.TotalSpace = Convert.ToInt32(objDataReader["TotalSpace"].ToString());
                        }
                        break;
                    case "NoOfFloors":
                        if (!Convert.IsDBNull(objDataReader["NoOfFloors"]))
                        {
                            objProperty.NoOfFloors = Convert.ToInt32(objDataReader["NoOfFloors"].ToString());
                        }
                        break;
                    case "IsParkingAvailable":
                        if (!Convert.IsDBNull(objDataReader["IsParkingAvailable"]))
                        {
                            objProperty.IsParkingAvailable = Convert.ToBoolean(objDataReader["IsParkingAvailable"].ToString());
                        }
                        break;
                    case "TotalParkingSpace":
                        if (!Convert.IsDBNull(objDataReader["TotalParkingSpace"]))
                        {
                            objProperty.TotalSpace = Convert.ToInt32(objDataReader["TotalParkingSpace"].ToString());
                        }
                        break;

                    case "Status":
                        if (!Convert.IsDBNull(objDataReader["Status"]))
                        {
                            objProperty.Status = Convert.ToBoolean(objDataReader["Status"]);
                        }
                        break;
                    case "EntryDate":
                        if (!Convert.IsDBNull(objDataReader["EntryDate"]))
                        {
                            objProperty.EntryDate = Convert.ToDateTime(objDataReader["EntryDate"]);
                        }
                        break;

                    case "EntryBy":
                        if (!Convert.IsDBNull(objDataReader["EntryBy"]))
                        {
                            objProperty.EntryBy = objDataReader["EntryBy"].ToString();
                        }
                        break;
                    case "UpdateDate":
                        if (!Convert.IsDBNull(objDataReader["UpdateDate"]))
                        {
                            objProperty.UpdateDate = Convert.ToDateTime(objDataReader["UpdateDate"]);
                        }
                        break;
                    case "UpdateBy":
                        if (!Convert.IsDBNull(objDataReader["UpdateBy"]))
                        {
                            objProperty.UpdateBy = objDataReader["UpdateBy"].ToString();
                        }
                        break;


                    default:
                        break;
                }
            }
            objProperty.IsNew = false;
            objProperty.IsDirty = true;
            objProperty.IsDelete = false;
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

        public int SavePropertyInfo(Property objProperty)
        {
            var noOfAffacted = 0;
            int propertyId;
            PropertyFacilityType objFacilityType;
            PropertySecurityType objSecurityType;
            //string spName = "";
            //if (referenceType==EnumBiz.ReferanceType.New.ToString())
            //{
            //    spName = "AHL.prInsertApllicant";
            //}
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
             objDbCommand.AddInOutParameter("PropertyId", objProperty.PropertyId, ParameterDirection.InputOutput, DbType.Int32, 16);
            objDbCommand.AddInParameter("PropertyName", objProperty.PropertyName.Trim());
            objDbCommand.AddInParameter("PropertyTypeId", objProperty.PropertyTypeId);
            objDbCommand.AddInParameter("LandloadId", objProperty.LandloadId.Trim());
            objDbCommand.AddInParameter("BuiltYear", objProperty.BuiltYear);
            objDbCommand.AddInParameter("CountryID", objProperty.CountryID);
            objDbCommand.AddInParameter("DivisionId", objProperty.DivisionId);
            objDbCommand.AddInParameter("DistrictId", objProperty.DistrictId);
            objDbCommand.AddInParameter("UpazilaId", objProperty.UpazilaId);
            objDbCommand.AddInParameter("HoldingNo", objProperty.HoldingNo);
            objDbCommand.AddInParameter("RoadNo", objProperty.RoadNo.Trim());
            objDbCommand.AddInParameter("SectorOrBlock", objProperty.SectorOrBlock.Trim());
            objDbCommand.AddInParameter("TotalSpace", objProperty.TotalSpace);
            objDbCommand.AddInParameter("NoOfFloors", objProperty.NoOfFloors);
            objDbCommand.AddInParameter("IsParkingAvailable", objProperty.IsParkingAvailable);
            if (objProperty.IsParkingAvailable)
            {
                objDbCommand.AddInParameter("TotalParkingSpace", objProperty.TotalParkingSpace);

            }



            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "ams.uspInsertPropertyDetailInfo", CommandType.StoredProcedure);
                propertyId = Convert.ToInt32(objDbCommand.Parameters["PropertyId"].Value.ToString());




                noOfAffacted += PropertyFacilityTypeBiz.SaveFacilities(objDataAccess, objDbCommand, objProperty.PropertyFacilityTypeList, propertyId);
                noOfAffacted += PropertySecurityTypeBiz.SaveSecurities(objDataAccess, objDbCommand, objProperty.PropertySecurityTypeList, propertyId);

                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return noOfAffacted;
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return noOfAffacted;
                }
            }
            catch (Exception ex)
            {
                objDbCommand.Transaction.Rollback();
                throw new Exception("Database Error Occured", ex);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
        }

        public static object GetUserWisePropertyList(string landloadId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("LandloadId",  landloadId);
                return CommonBiz.GetCombo("ams.uspGetUserWisePropertyList", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}