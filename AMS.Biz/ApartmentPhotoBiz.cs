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
    public class ApartmentPhotoBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, ApartmentPhotos objApartmentPhotos)
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
                            objApartmentPhotos.PropertyId = Convert.ToInt32(objDataReader["PropertyId"].ToString());
                        }
                        break;
                    case "PhotoName":
                        if (!Convert.IsDBNull(objDataReader["PhotoName"]))
                        {
                            objApartmentPhotos.PhotoName = objDataReader["PhotoName"].ToString();
                        }
                        break;
                    case "LandloadId":
                        if (!Convert.IsDBNull(objDataReader["LandloadId"]))
                        {
                            objApartmentPhotos.LandloadId = objDataReader["LandloadId"].ToString();
                        }
                        break;

                    case "ApartmentPhotoSerial":
                        if (!Convert.IsDBNull(objDataReader["ApartmentPhotoSerial"]))
                        {
                            objApartmentPhotos.ApartmentPhotoSerial = Convert.ToInt32(objDataReader["ApartmentPhotoSerial"].ToString());
                        }
                        break;
                    case "PhotoUrl":
                        if (!Convert.IsDBNull(objDataReader["PhotoUrl"]))
                        {
                            objApartmentPhotos.PhotoUrl = objDataReader["PhotoUrl"].ToString();
                        }
                        break;


                    case "Status":
                        if (!Convert.IsDBNull(objDataReader["Status"]))
                        {
                            objApartmentPhotos.Status = Convert.ToBoolean(objDataReader["Status"]);
                        }
                        break;
                    case "EntryDate":
                        if (!Convert.IsDBNull(objDataReader["EntryDate"]))
                        {
                            objApartmentPhotos.EntryDate = Convert.ToDateTime(objDataReader["EntryDate"]);
                        }
                        break;

                    case "EntryBy":
                        if (!Convert.IsDBNull(objDataReader["EntryBy"]))
                        {
                            objApartmentPhotos.EntryBy = objDataReader["EntryBy"].ToString();
                        }
                        break;
                    case "UpdateDate":
                        if (!Convert.IsDBNull(objDataReader["UpdateDate"]))
                        {
                            objApartmentPhotos.UpdateDate = Convert.ToDateTime(objDataReader["UpdateDate"]);
                        }
                        break;
                    case "UpdateBy":
                        if (!Convert.IsDBNull(objDataReader["UpdateBy"]))
                        {
                            objApartmentPhotos.UpdateBy = objDataReader["UpdateBy"].ToString();
                        }
                        break;


                    default:
                        break;
                }
            }
            objApartmentPhotos.IsNew = false;
            objApartmentPhotos.IsDirty = true;
            objApartmentPhotos.IsDelete = false;
        }

        //public static List<StaticListItem> GetPropertyFacilityType()
        //{
        //    try
        //    {
        //        return CommonBiz.GetCheckBoxList("ams.uspGetPropertyFacilityType");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}
        //public static List<StaticListItem> GetPropertyFacilityType(int facilityId)
        //{
        //    try
        //    {
        //        Dictionary<string, object> p = new Dictionary<string, object>();
        //        p.Add("FacilityId", facilityId);
        //        return CommonBiz.GetCheckBoxList("ams.uspGetPropertyFacilityType", p);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}
        public static int SaveFacilities(IDataAccess objDataAccess, DbCommand objDCommand, List<PropertyFacilityType> objfacilityList, int propertyId)
        {
            int noOfAffacted = 0;
            foreach (PropertyFacilityType objFacilityType in objfacilityList)
            {


                noOfAffacted += SaveFacilities(objDataAccess, objDCommand, objFacilityType, propertyId);
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

        public int SaveApartmentPhotos(List<ApartmentPhotos> objApartmentPhotoList)
        {
            int noOfAffacted = 0;
            try
            {
                foreach (ApartmentPhotos objApartmentPhoto in objApartmentPhotoList)
                {


                    objDataAccess = DataAccess.NewDataAccess();
                    objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);


                    objDbCommand.AddInParameter("PropertyId", objApartmentPhoto.PropertyId);
                    objDbCommand.AddInParameter("ApartmentId", objApartmentPhoto.ApartmentId);
                    objDbCommand.AddInParameter("LandloadId", objApartmentPhoto.LandloadId.Trim());
                    objDbCommand.AddInParameter("PhotoName", objApartmentPhoto.PhotoName);
                    objDbCommand.AddInParameter("PhotoUrl", objApartmentPhoto.PhotoUrl);

                    noOfAffacted = noOfAffacted + objDataAccess.ExecuteNonQuery(objDbCommand, "ams.uspInsertApartmentPhoto", CommandType.StoredProcedure);


                    if (noOfAffacted > 0)
                    {
                        objDbCommand.Transaction.Commit();
                        
                    }
                    else
                    {
                        objDbCommand.Transaction.Rollback();
                        return noOfAffacted;
                    }
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
            return noOfAffacted;
        }

        public static object GetUserWisePropertyList(string landloadId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("LandloadId", landloadId);
                return CommonBiz.GetCombo("ams.uspGetUserWisePropertyList", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}