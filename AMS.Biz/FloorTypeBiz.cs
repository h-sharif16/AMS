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
    public class FloorTypeBiz
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;

        

        public static List<StaticListItem> GetFloorType()
        {
            try
            {
                return CommonBiz.GetCombo("ams.uspGetFloorType");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetFloorType(int floorTypeId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("FloorTypeId", floorTypeId);
                return CommonBiz.GetCombo("ams.uspGetFloorType", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
    }
}