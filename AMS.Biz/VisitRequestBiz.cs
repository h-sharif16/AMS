using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.DAL;
using AMS.Model;

namespace AMS.Biz
{
    public class VisitRequestBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private void BuildModel(DbDataReader objDataReader, VisitRequest objVisitRequest)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();

                switch (column)
                {
                    case "VisitReqId":
                        if (!Convert.IsDBNull(objDataReader["VisitReqId"]))
                        {
                            objVisitRequest.VisitReqId = Convert.ToInt32(objDataReader["VisitReqId"].ToString());
                        }
                        break;
                    case "PropertyId":
                        if (!Convert.IsDBNull(objDataReader["PropertyId"]))
                        {
                            objVisitRequest.PropertyId = Convert.ToInt32(objDataReader["PropertyId"].ToString());
                        }
                        break;

                    case "LandlordId":
                        if (!Convert.IsDBNull(objDataReader["LandlordId"]))
                        {
                            objVisitRequest.LandlordId = objDataReader["LandlordId"].ToString();
                        }
                        break;

                    case "ApartmentId":
                        if (!Convert.IsDBNull(objDataReader["ApartmentId"]))
                        {
                            objVisitRequest.ApartmentId = Convert.ToInt32(objDataReader["ApartmentId"].ToString());
                        }
                        break;
                    case "ClientName":
                        if (!Convert.IsDBNull(objDataReader["ClientName"]))
                        {
                            objVisitRequest.ClientName = objDataReader["ClientName"].ToString();
                        }
                        break;
                    case "ClientEmail":
                        if (!Convert.IsDBNull(objDataReader["ClientEmail"]))
                        {
                            objVisitRequest.ClientEmail = objDataReader["ClientEmail"].ToString();
                        }
                        break;


                    case "ClientMobileNo":
                        if (!Convert.IsDBNull(objDataReader["ClientMobileNo"]))
                        {
                            objVisitRequest.ClientMobileNo = objDataReader["ClientMobileNo"].ToString();
                        }
                        break;
                    case "MessageToLandlord":
                        if (!Convert.IsDBNull(objDataReader["MessageToLandlord"]))
                        {
                            objVisitRequest.MessageToLandlord = objDataReader["MessageToLandlord"].ToString();
                        }
                        break;
                    case "MessageToClient":
                        if (!Convert.IsDBNull(objDataReader["MessageToClient"]))
                        {
                            objVisitRequest.MessageToClient = objDataReader["MessageToClient"].ToString();
                        }
                        break;

                    case "RequestDate":
                        if (!Convert.IsDBNull(objDataReader["RequestDate"]))
                        {
                            objVisitRequest.RequestDate = Convert.ToDateTime(objDataReader["RequestDate"]);
                        }
                        break;
                    case "ResponseDate":
                        if (!Convert.IsDBNull(objDataReader["ResponseDate"]))
                        {
                            objVisitRequest.ResponseDate = Convert.ToDateTime(objDataReader["ResponseDate"]);
                        }
                        break;

                    case "EntryDate":
                        if (!Convert.IsDBNull(objDataReader["EntryDate"]))
                        {
                            objVisitRequest.EntryDate = Convert.ToDateTime(objDataReader["EntryDate"]);
                        }
                        break;

                    case "EntryBy":
                        if (!Convert.IsDBNull(objDataReader["EntryBy"]))
                        {
                            objVisitRequest.EntryBy = objDataReader["EntryBy"].ToString();
                        }
                        break;
                    case "UpdateDate":
                        if (!Convert.IsDBNull(objDataReader["UpdateDate"]))
                        {
                            objVisitRequest.UpdateDate = Convert.ToDateTime(objDataReader["UpdateDate"]);
                        }
                        break;
                    case "UpdateBy":
                        if (!Convert.IsDBNull(objDataReader["UpdateBy"]))
                        {
                            objVisitRequest.UpdateBy = objDataReader["UpdateBy"].ToString();
                        }
                        break;


                    default:
                        break;
                }
            }
            objVisitRequest.IsNew = false;
            objVisitRequest.IsDirty = true;
            objVisitRequest.IsDelete = false;
        }

        public int SaveVisitRequest(VisitRequest _objVisitRequest, out int VisitReqId)
        {
            var noOfAffacted = 0;
           
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInOutParameter("VisitReqId", _objVisitRequest.VisitReqId, ParameterDirection.InputOutput, DbType.Int32, 16);
            objDbCommand.AddInParameter("LandlordId", _objVisitRequest.LandlordId);
            objDbCommand.AddInParameter("PropertyId", _objVisitRequest.PropertyId);
            objDbCommand.AddInParameter("ApartmentId", _objVisitRequest.ApartmentId);
            objDbCommand.AddInParameter("ClientName", _objVisitRequest.ClientName);
            objDbCommand.AddInParameter("ClientEmail", _objVisitRequest.ClientEmail);
            objDbCommand.AddInParameter("ClientMobileNo", _objVisitRequest.ClientMobileNo);
            objDbCommand.AddInParameter("MessageToLandlord", _objVisitRequest.MessageToLandlord);
            objDbCommand.AddInParameter("RequestDate", _objVisitRequest.RequestDate);



            try
            {
                noOfAffacted =
                    objDataAccess.ExecuteNonQuery(objDbCommand, "ams.uspInsertVisitRequest", CommandType.StoredProcedure);
                VisitReqId = Convert.ToInt32(objDbCommand.Parameters["VisitReqId"].Value.ToString());

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



        public bool GetIsAlreadyRequestedForVisit(VisitRequest objVisitRequest)
        {

            bool IsAlreadyRequested;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            //  objDbCommand.AddInOutParameter("ApplicantId", objApplicant.ApplicantId, ParameterDirection.InputOutput, DbType.Int32, 16);

            objDbCommand.AddInParameter("LandlordId", objVisitRequest.LandlordId);
            objDbCommand.AddInParameter("PropertyId", objVisitRequest.PropertyId);
            objDbCommand.AddInParameter("ApartmentId", objVisitRequest.ApartmentId);

            objDbCommand.AddInParameter("ClientEmail", objVisitRequest.ClientEmail);
            objDbCommand.AddInParameter("ClientMobileNo", objVisitRequest.ClientMobileNo);

            try
            {
                IsAlreadyRequested =
                    (bool)objDataAccess.ExecuteScalar(objDbCommand, "ams.uspIsAlreadyRequestedForVisit", CommandType.StoredProcedure);
 
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
            return IsAlreadyRequested;
        }


        public VisitRequest GetVisitRequestDetail(int visitReqId, string landlordId)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            VisitRequest objVisitRequest = null;
            objDbCommand.AddInParameter("VisitReqId", visitReqId);
            objDbCommand.AddInParameter("LandlordId", landlordId);



            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "ams.uspGetVisitRequestDetail",
                    CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    //DocumentBiz.GetApplicantDocuments(applicantId);
                    while (objDbDataReader.Read())
                    {
                        objVisitRequest = new VisitRequest();
                        BuildModel(objDbDataReader, objVisitRequest);
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


            return objVisitRequest;

        }

        public int UpdateResposeOnVisitRequest(VisitRequest _objVisitRequest)
        {
            var noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("VisitReqId", _objVisitRequest.VisitReqId);
            objDbCommand.AddInParameter("LandlordId", _objVisitRequest.LandlordId);
            objDbCommand.AddInParameter("PropertyId", _objVisitRequest.PropertyId);
            objDbCommand.AddInParameter("ApartmentId", _objVisitRequest.ApartmentId);
            objDbCommand.AddInParameter("IsAccepted", _objVisitRequest.IsAccepted);
           
            objDbCommand.AddInParameter("MessageToClient", _objVisitRequest.MessageToClient);
            objDbCommand.AddInParameter("ResponseDate", _objVisitRequest.ResponseDate);



            try
            {
                noOfAffacted =
                    objDataAccess.ExecuteNonQuery(objDbCommand, "ams.uspUpdateResposeOnVisitRequest", CommandType.StoredProcedure);
               

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
    }
}
