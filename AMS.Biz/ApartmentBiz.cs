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
    public class ApartmentBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, Apartment objApartment)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();

                switch (column)
                {
                    case "ApartmentId":
                        if (!Convert.IsDBNull(objDataReader["ApartmentId"]))
                        {
                            objApartment.ApartmentId = Convert.ToInt32(objDataReader["ApartmentId"].ToString());
                        }
                        break;
                    case "PropertyId":
                        if (!Convert.IsDBNull(objDataReader["PropertyId"]))
                        {
                            objApartment.PropertyId = Convert.ToInt32(objDataReader["PropertyId"].ToString());
                        }
                        break;
                    case "LandloadId":
                        if (!Convert.IsDBNull(objDataReader["LandloadId"]))
                        {
                            objApartment.LandloadId = objDataReader["LandloadId"].ToString();
                        }
                        break;
                    case "FloorNo":
                        if (!Convert.IsDBNull(objDataReader["FloorNo"]))
                        {
                            objApartment.FloorNo = Convert.ToInt32(objDataReader["FloorNo"].ToString());
                        }
                        break;
                    case "ApartmentSpace":
                        if (!Convert.IsDBNull(objDataReader["ApartmentSpace"]))
                        {
                            objApartment.ApartmentSpace = Convert.ToInt32(objDataReader["ApartmentSpace"].ToString());
                        }
                        break;
                    case "Beds":
                        if (!Convert.IsDBNull(objDataReader["Beds"]))
                        {
                            objApartment.Beds = Convert.ToInt32(objDataReader["Beds"].ToString());
                        }
                        break;
                    case "AttachBatch":
                        if (!Convert.IsDBNull(objDataReader["AttachBatch"]))
                        {
                            objApartment.AttachBatch = Convert.ToInt32(objDataReader["AttachBatch"].ToString());
                        }
                        break;
                    case "CommonBath":
                        if (!Convert.IsDBNull(objDataReader["CommonBath"]))
                        {
                            objApartment.CommonBath = Convert.ToInt32(objDataReader["CommonBath"].ToString());
                        }
                        break;
                     

                    case "DiningPosition":
                        if (!Convert.IsDBNull(objDataReader["DiningPosition"]))
                        {
                            objApartment.DiningPosition = objDataReader["DiningPosition"].ToString();
                        }
                        break;
                    case "StaffRoom":
                        if (!Convert.IsDBNull(objDataReader["StaffRoom"]))
                        {
                            objApartment.StaffRoom =Convert.ToInt32( objDataReader["StaffRoom"].ToString());
                        }
                        break;
                    case "StaffToilet":
                        if (!Convert.IsDBNull(objDataReader["StaffToilet"]))
                        {
                            objApartment.StaffToilet = Convert.ToInt32(objDataReader["StaffToilet"].ToString());
                        }
                        break;
                    case "Balconies":
                        if (!Convert.IsDBNull(objDataReader["Balconies"]))
                        {
                            objApartment.Balconies = Convert.ToInt32(objDataReader["Balconies"].ToString());
                        }
                        break;
                    case "FloorTypeId":
                        if (!Convert.IsDBNull(objDataReader["FloorTypeId"]))
                        {
                            objApartment.FloorTypeId = Convert.ToInt32(objDataReader["FloorTypeId"].ToString());
                        }
                        break;
                    case "Rent":
                        if (!Convert.IsDBNull(objDataReader["Rent"]))
                        {
                            objApartment.Rent = Convert.ToInt32(objDataReader["Rent"].ToString());
                        }
                        break;
                   
                    case "Advance":
                        if (!Convert.IsDBNull(objDataReader["Advance"]))
                        {
                            objApartment.Advance = Convert.ToInt32(objDataReader["Advance"].ToString());
                        }
                        break;

                    case "SecurityAmount":
                        if (!Convert.IsDBNull(objDataReader["SecurityAmount"]))
                        {
                            objApartment.SecurityAmount = Convert.ToInt32(objDataReader["SecurityAmount"].ToString());
                        }
                        break;
                    case "ServiceCharge":
                        if (!Convert.IsDBNull(objDataReader["ServiceCharge"]))
                        {
                            objApartment.ServiceCharge = Convert.ToInt32(objDataReader["ServiceCharge"].ToString());
                        }
                        break;
                    case "GasBill":
                        if (!Convert.IsDBNull(objDataReader["GasBill"]))
                        {
                            objApartment.GasBill = Convert.ToDecimal(objDataReader["GasBill"].ToString());
                        }
                        break;
                    case "CableTvBill":
                        if (!Convert.IsDBNull(objDataReader["CableTvBill"]))
                        {
                            objApartment.CableTvBill = Convert.ToDecimal(objDataReader["CableTvBill"].ToString());
                        }
                        break;
                    case "InternetBill":
                        if (!Convert.IsDBNull(objDataReader["InternetBill"]))
                        {
                            objApartment.InternetBill = Convert.ToDecimal(objDataReader["InternetBill"].ToString());
                        }
                        break;
                    case "VacancyStatusId":
                        if (!Convert.IsDBNull(objDataReader["VacancyStatusId"]))
                        {
                            objApartment.VacancyStatusId = Convert.ToInt32(objDataReader["VacancyStatusId"].ToString());
                        }
                        break;
                    case "Description":
                        if (!Convert.IsDBNull(objDataReader["Description"]))
                        {
                            objApartment.Description = objDataReader["Description"].ToString();
                        }
                        break;
                    case "Status":
                        if (!Convert.IsDBNull(objDataReader["Status"]))
                        {
                            objApartment.Status = Convert.ToBoolean(objDataReader["Status"]);
                        }
                        break;
                    case "EntryDate":
                        if (!Convert.IsDBNull(objDataReader["EntryDate"]))
                        {
                            objApartment.EntryDate = Convert.ToDateTime(objDataReader["EntryDate"]);
                        }
                        break;

                    case "EntryBy":
                        if (!Convert.IsDBNull(objDataReader["EntryBy"]))
                        {
                            objApartment.EntryBy = objDataReader["EntryBy"].ToString();
                        }
                        break;
                    case "UpdateDate":
                        if (!Convert.IsDBNull(objDataReader["UpdateDate"]))
                        {
                            objApartment.UpdateDate = Convert.ToDateTime(objDataReader["UpdateDate"]);
                        }
                        break;
                    case "UpdateBy":
                        if (!Convert.IsDBNull(objDataReader["UpdateBy"]))
                        {
                            objApartment.UpdateBy = objDataReader["UpdateBy"].ToString();
                        }
                        break;


                    default:
                        break;
                }
            }
            objApartment.IsNew = false;
            objApartment.IsDirty = true;
            objApartment.IsDelete = false;
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
        public static List<StaticListItem> GetApartmentDetailByPeopertyId(int propertyId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("PropertyId", propertyId);
                return CommonBiz.GetCombo("ams.uspGetApartmentDetailByPeopertyId", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public int SaveApartmentInfo(Apartment objApartment)
        {
            var noOfAffacted = 0;
            int apartmentId;
            PropertyFacilityType objFacilityType;
            PropertySecurityType objSecurityType;
            //string spName = "";
            //if (referenceType==EnumBiz.ReferanceType.New.ToString())
            //{
            //    spName = "AHL.prInsertApllicant";
            //}
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInOutParameter("ApartmentId", objApartment.ApartmentId, ParameterDirection.InputOutput, DbType.Int32, 16);

            objDbCommand.AddInParameter("PropertyId",       objApartment.PropertyId);
            objDbCommand.AddInParameter("ApartmentNoOrName", objApartment.ApartmentNoOrName); 
            objDbCommand.AddInParameter("LandloadId",       objApartment.LandloadId.Trim());
            objDbCommand.AddInParameter("FloorNo",          objApartment.FloorNo);
            objDbCommand.AddInParameter("ApartmentSpace",   objApartment.ApartmentSpace);
            objDbCommand.AddInParameter("Beds",             objApartment.Beds);
            objDbCommand.AddInParameter("AttachBatch",      objApartment.AttachBatch);
            objDbCommand.AddInParameter("CommonBath",       objApartment.CommonBath);
            objDbCommand.AddInParameter("DiningPosition",      objApartment.DiningPosition);
            objDbCommand.AddInParameter("StaffRoom",        objApartment.StaffRoom);
            objDbCommand.AddInParameter("StaffToilet",      objApartment.StaffToilet);
            objDbCommand.AddInParameter("Balconies",        objApartment.Balconies);
            objDbCommand.AddInParameter("FloorTypeId",       objApartment.FloorTypeId);
            objDbCommand.AddInParameter("Rent",              objApartment.Rent);
            objDbCommand.AddInParameter("Advance",           objApartment.Advance);
            objDbCommand.AddInParameter("SecurityAmount",    objApartment.SecurityAmount);
            objDbCommand.AddInParameter("ServiceCharge",     objApartment.ServiceCharge);
            objDbCommand.AddInParameter("GasBill",          objApartment.GasBill);
            objDbCommand.AddInParameter("CableTvBill",      objApartment.CableTvBill);
            objDbCommand.AddInParameter("InternetBill",      objApartment.InternetBill);
            objDbCommand.AddInParameter("Description",      objApartment.Description);
            objDbCommand.AddInParameter("VacancyStatusId",      objApartment.VacancyStatusId);
            


            try
            {
                noOfAffacted = objDataAccess.ExecuteNonQuery(objDbCommand, "ams.uspInsertApartmentDetailInfo", CommandType.StoredProcedure);
                apartmentId = Convert.ToInt32(objDbCommand.Parameters["@ApartmentId"].Value.ToString());




                //noOfAffacted += PropertyFacilityTypeBiz.SaveFacilities(objDataAccess, objDbCommand, objApartment.PropertyFacilityTypeList, propertyId);
                //noOfAffacted += PropertySecurityTypeBiz.SaveSecurities(objDataAccess, objDbCommand, objApartment.PropertySecurityTypeList, propertyId);

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