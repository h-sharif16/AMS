﻿using System;
using System.Data;
using System.Data.Common;
using System.Runtime.Remoting.Contexts;
using AMS.Common.Model;
using AMS.DAL;
using AMS.Model;

namespace AMS.Biz
{
    public class UserBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        private void BuildModel(DbDataReader objDataReader, UserDetail objUser)
        {
            var objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                var column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "UserID":
                        if (!Convert.IsDBNull(objDataReader["UserID"]))
                        {
                            objUser.UserID = objDataReader["UserID"].ToString();
                        }
                        break;
                    case "Email":
                        if (!Convert.IsDBNull(objDataReader["Email"]))
                        {
                            objUser.Email = objDataReader["Email"].ToString();
                        }
                        break;
                    case "Password":
                        if (!Convert.IsDBNull(objDataReader["Password"]))
                        {
                            objUser.Password = objDataReader["Password"].ToString();
                        }
                        break;
                    case "MobileNo":
                        if (!Convert.IsDBNull(objDataReader["MobileNo"]))
                        {
                            objUser.MobileNo = objDataReader["MobileNo"].ToString();
                        }
                        break;
                    case "FirstName":
                        if (!Convert.IsDBNull(objDataReader["FirstName"]))
                        {
                            objUser.FirstName = objDataReader["FirstName"].ToString();
                        }
                        break;

                    case "LastName":
                        if (!Convert.IsDBNull(objDataReader["LastName"]))
                        {
                            objUser.LastName = objDataReader["LastName"].ToString();
                        }
                        break;
                    case "MiddleName":
                        if (!Convert.IsDBNull(objDataReader["MiddleName"]))
                        {
                            objUser.MiddleName = objDataReader["MiddleName"].ToString();
                        }
                        break;
                    case "FullName":
                        if (!Convert.IsDBNull(objDataReader["FullName"]))
                        {
                            objUser.FullName = objDataReader["FullName"].ToString();
                        }
                        break;
                    case "RoleTypeID":
                        if (!Convert.IsDBNull(objDataReader["RoleTypeID"]))
                        {
                            objUser.RoleTypeID = Convert.ToChar(objDataReader["RoleTypeID"]);
                        }
                        break;
                    case "RoleName":
                        if (!Convert.IsDBNull(objDataReader["RoleName"]))
                        {
                            objUser.RoleName = objDataReader["RoleName"].ToString();
                        }
                        break;
                    case "NID":
                        if (!Convert.IsDBNull(objDataReader["NID"]))
                        {
                            objUser.NID = objDataReader["NID"].ToString();
                        }
                        break;
                    case "TIN":
                        if (!Convert.IsDBNull(objDataReader["TIN"]))
                        {
                            objUser.TIN = objDataReader["TIN"].ToString();
                        }
                        break;

                    case "ProfessionId":
                        if (!Convert.IsDBNull(objDataReader["ProfessionId"]))
                        {
                            objUser.ProfessionId =Convert.ToInt32(objDataReader["ProfessionId"]);
                        }
                        break;
                    case "OthersProfession":
                        if (!Convert.IsDBNull(objDataReader["OthersProfession"]))
                        {
                            objUser.OthersProfession = objDataReader["OthersProfession"].ToString();
                        }
                        break;

                    case "ReligionId":
                        if (!Convert.IsDBNull(objDataReader["ReligionId"]))
                        {
                            objUser.ReligionId = Convert.ToInt32(objDataReader["ReligionId"]);
                        }
                        break;
                    case "DateOfBirth":
                        if (!Convert.IsDBNull(objDataReader["DateOfBirth"]))
                        {
                            objUser.DateOfBirth = Convert.ToDateTime(objDataReader["DateOfBirth"]);
                        }
                        break;
                    case "IsShowAsCompanyName":
                        if (!Convert.IsDBNull(objDataReader["IsShowAsCompanyName"]))
                        {
                            objUser.IsShowAsCompanyName = Convert.ToBoolean(objDataReader["IsShowAsCompanyName"]);
                        }
                        break;
                    case "ProfileImageUrl":
                        if (!Convert.IsDBNull(objDataReader["ProfileImageUrl"]))
                        {
                            objUser.ProfileImageUrl = objDataReader["ProfileImageUrl"].ToString();
                        }
                        break;
                    case "Status":
                        if (!Convert.IsDBNull(objDataReader["Status"]))
                        {
                            objUser.Status = Convert.ToBoolean(objDataReader["Status"]);
                        }
                        break;
                    case "EntryDate":
                        if (!Convert.IsDBNull(objDataReader["EntryDate"]))
                        {
                            objUser.EntryDate = Convert.ToDateTime(objDataReader["EntryDate"]);
                        }
                        break;

                    case "EntryBy":
                        if (!Convert.IsDBNull(objDataReader["EntryBy"]))
                        {
                            objUser.EntryBy = objDataReader["EntryBy"].ToString();
                        }
                        break;
                    case "UpdateDate":
                        if (!Convert.IsDBNull(objDataReader["UpdateDate"]))
                        {
                            objUser.UpdateDate = Convert.ToDateTime(objDataReader["UpdateDate"]);
                        }
                        break;
                    case "UpdateBy":
                        if (!Convert.IsDBNull(objDataReader["UpdateBy"]))
                        {
                            objUser.UpdateBy = objDataReader["UpdateBy"].ToString();
                        }
                        break;


                    default:
                        break;
                }
            }
            objUser.IsNew = false;
            objUser.IsDirty = true;
            objUser.IsDelete = false;
        }

        public int Save(UserDetail objUser)
        {
            var noOfAffacted = 0;
            //string applicantCode;
            //string spName = "";
            //if (referenceType==EnumBiz.ReferanceType.New.ToString())
            //{
            //    spName = "AHL.prInsertApllicant";
            //}
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            //  objDbCommand.AddInOutParameter("ApplicantId", objApplicant.ApplicantId, ParameterDirection.InputOutput, DbType.Int32, 16);
            objDbCommand.AddInParameter("Email", objUser.Email);
            objDbCommand.AddInParameter("MobileNo", objUser.MobileNo);
            objDbCommand.AddInParameter("LastName", objUser.LastName);
            objDbCommand.AddInParameter("FirstName", objUser.FirstName);
            objDbCommand.AddInParameter("Password", objUser.Password);
            objDbCommand.AddInParameter("RoleTypeID", objUser.RoleTypeID);
            objDbCommand.AddInParameter("Status", objUser.Status);


            try
            {
                noOfAffacted =
                    (int) objDataAccess.ExecuteScalar(objDbCommand, "ams.uspInsertNewUser", CommandType.StoredProcedure);


                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return 1; //"Save Successful";
                }
                else if (noOfAffacted == -1)
                {
                    objDbCommand.Transaction.Rollback();
                    return 2; //"User already Exists!";
                }

                else
                {
                    objDbCommand.Transaction.Rollback();
                    return 0;//"Registration Failed";
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


        public int ResetPassword(UserDetail objUser)
        {
            var noOfAffacted = 0;
            //string applicantCode;
            //string spName = "";
            //if (referenceType==EnumBiz.ReferanceType.New.ToString())
            //{
            //    spName = "AHL.prInsertApllicant";
            //}
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            //  objDbCommand.AddInOutParameter("ApplicantId", objApplicant.ApplicantId, ParameterDirection.InputOutput, DbType.Int32, 16);
            objDbCommand.AddInParameter("Email", objUser.Email);
            objDbCommand.AddInParameter("MobileNo", objUser.MobileNo);
            
            objDbCommand.AddInParameter("Password", objUser.Password);
             


            try
            {
                 
             //objDataAccess.ExecuteScalar(objDbCommand, "ams.uspResetPassword", CommandType.StoredProcedure);


                if ((int)objDataAccess.ExecuteNonQuery(objDbCommand, "ams.uspResetPassword", CommandType.StoredProcedure) != 0)
                {
                    objDbCommand.Transaction.Commit();
                    return 1; //"Save Successful";
                }
                

                else
                {
                    objDbCommand.Transaction.Rollback();
                    return 0;//"Registration Failed";
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


        public UserDetail GetUserBasicInfo(User objUser)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            UserDetail objUserDtl = null;
            objDbCommand.AddInParameter("EmailAsUserID", objUser.Email);
            objDbCommand.AddInParameter("MobileNoAsUserID", objUser.MobileNo);
            objDbCommand.AddInParameter("Password", objUser.Password);

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "ams.uspGetAuthoriseUserBasicInfo",
                    CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    //DocumentBiz.GetApplicantDocuments(applicantId);
                    while (objDbDataReader.Read())
                    {
                        objUserDtl = new UserDetail();
                        BuildModel(objDbDataReader, objUserDtl);
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


            return objUserDtl;
        }

        public UserDetail uspGetUserBasicInfoByEmailOrMobileNo(User objUser)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            UserDetail objUserDtl = null;
            objDbCommand.AddInParameter("EmailAsUserID", objUser.Email);
            objDbCommand.AddInParameter("MobileNoAsUserID", objUser.MobileNo);
           

            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "ams.uspGetUserBasicInfoByEmailOrMobileNo",
                    CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    //DocumentBiz.GetApplicantDocuments(applicantId);
                    while (objDbDataReader.Read())
                    {
                        objUserDtl = new UserDetail();
                        BuildModel(objDbDataReader, objUserDtl);
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


            return objUserDtl;
        }
        public int ActiveUserByEmail(string email)
        {
            var noOfAffacted = 0;
            
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            //  objDbCommand.AddInOutParameter("ApplicantId", objApplicant.ApplicantId, ParameterDirection.InputOutput, DbType.Int32, 16);
            objDbCommand.AddInParameter("Email", email);
              


            try
            {
                noOfAffacted =
                     objDataAccess.ExecuteNonQuery(objDbCommand, "ams.uspActiveUserByEmail", CommandType.StoredProcedure);


                if (noOfAffacted != 0)
                {
                    objDbCommand.Transaction.Commit();
                    return 1; //"Save Successful";
                }
                
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return 0;//"Registration Failed";
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


        public bool IsUserVerified(string email)
        {
            bool isVerified;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            //  objDbCommand.AddInOutParameter("ApplicantId", objApplicant.ApplicantId, ParameterDirection.InputOutput, DbType.Int32, 16);
            objDbCommand.AddInParameter("Email", email);



            try
            {
                isVerified =
                    (bool) objDataAccess.ExecuteScalar(objDbCommand, "ams.uspIsUserVerified", CommandType.StoredProcedure);


                //if (noOfAffacted != 0)
                //{
                //    objDbCommand.Transaction.Commit();
                //    return 1; //"Save Successful";
                //}

                //else
                //{
                //    objDbCommand.Transaction.Rollback();
                //    return 0;//"Registration Failed";
                //}
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
            return isVerified;
        }

        public int SavePersonalGeneralInfo(UserDetail objUserDetail)
        {
            var noOfAffacted = 0;
            //string applicantCode;
            //string spName = "";
            //if (referenceType==EnumBiz.ReferanceType.New.ToString())
            //{
            //    spName = "AHL.prInsertApllicant";
            //}
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            //  objDbCommand.AddInOutParameter("ApplicantId", objApplicant.ApplicantId, ParameterDirection.InputOutput, DbType.Int32, 16);
            objDbCommand.AddInParameter("UserID", objUserDetail.UserID);
            objDbCommand.AddInParameter("Email",        objUserDetail.Email);
            objDbCommand.AddInParameter("LastName",         objUserDetail.LastName);
            objDbCommand.AddInParameter("FirstName",         objUserDetail.FirstName);
            objDbCommand.AddInParameter("MiddleName",         objUserDetail.MiddleName);
            objDbCommand.AddInParameter("NID",              objUserDetail.NID);
            objDbCommand.AddInParameter("TIN",              objUserDetail.TIN);
            objDbCommand.AddInParameter("ProfessionId",             objUserDetail.ProfessionId);
            objDbCommand.AddInParameter("ReligionId",       objUserDetail.ReligionId);
            objDbCommand.AddInParameter("OthersProfession",     objUserDetail.OthersProfession);
            objDbCommand.AddInParameter("DateOfBirth",          objUserDetail.DateOfBirth);
            objDbCommand.AddInParameter("ProfileImageUrl",      objUserDetail.ProfileImageUrl);





            try
            {
                noOfAffacted =
                    (int)objDataAccess.ExecuteScalar(objDbCommand, "ams.uspUpdatePersonalGeneralInformation", CommandType.StoredProcedure);


                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return 1; //"Save Successful";
                }
                else if (noOfAffacted == -1)
                {
                    objDbCommand.Transaction.Rollback();
                    return 2; //"User already Exists!";
                }

                else
                {
                    objDbCommand.Transaction.Rollback();
                    return 0;//"Registration Failed";
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
        public bool CheckAvailabitity(string SearchString, string TableName, string TableColumn)
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
            return isValueExists;
        }

        public UserDetail GetLandloardEmail(string landlordEmail)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            UserDetail objUserDtl = null;
            objDbCommand.AddInParameter("LandloardId", landlordEmail);
            


            try
            {
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "ams.uspGetLandloardEmail",
                    CommandType.StoredProcedure);
                if (objDbDataReader.HasRows)
                {
                    //DocumentBiz.GetApplicantDocuments(applicantId);
                    while (objDbDataReader.Read())
                    {
                        objUserDtl = new UserDetail();
                        BuildModel(objDbDataReader, objUserDtl);
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


            return objUserDtl;
        }
    }
}