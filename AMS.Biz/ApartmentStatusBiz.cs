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
    public class ApartmentStatusBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        

        public static List<StaticListItem> GetApartmentVacanyStatus()
        {
            try
            {
                return CommonBiz.GetCombo("amsSys.uspApartmentVacanyStatus");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetApartmentVacanyStatus(int apartmentStatusId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("ApartmentStatusId", apartmentStatusId);
                return CommonBiz.GetCombo("amsSys.uspApartmentVacanyStatus", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
    }
}