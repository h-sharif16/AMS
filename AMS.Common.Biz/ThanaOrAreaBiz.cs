using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Common.Biz
{
   public class ThanaOrAreaBiz
    {

        public static List<StaticListItem> GetThanaOrArea()
        {
            try
            {
                return CommonBiz.GetCombo("uspGetThanaOrArea");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetThanaOrArea(int cityOrDistrictId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("CityOrDistrictId", cityOrDistrictId);
                return CommonBiz.GetCombo("uspGetThanaOrArea", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        //public static List<StaticListItem> GetStateDivision(int countryId,int divisionId)
        //{
        //    try
        //    {
        //        Dictionary<string, object> p = new Dictionary<string, object>();
        //        p.Add("CountryID", countryId);
        //        p.Add("StateDivisionId", divisionId);
        //        return CommonBiz.GetCombo("uspGetStateOrDivision", p);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
