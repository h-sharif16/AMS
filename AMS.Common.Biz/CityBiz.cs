using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Common.Biz
{
   public class CityBiz
    {

        public static List<StaticListItem> GetCity()
        {
            try
            {
                return CommonBiz.GetCombo("uspGetCityOrDistrict");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetCity(int stateDivisionId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("StateDivisionId", stateDivisionId);
                return CommonBiz.GetCombo("uspGetCityOrDistrict", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
       
        public static List<StaticListItem> GetCity(int countryId,int stateDivisionId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("CountryID", countryId);
                p.Add("StateDivisionId", stateDivisionId);
                return CommonBiz.GetCombo("uspGetCityOrDistrict", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
