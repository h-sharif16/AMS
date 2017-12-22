using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Common.Biz
{
   public class CountryBiz
    {

        public static List<StaticListItem> GetCountry()
        {
            try
            {
                return CommonBiz.GetCombo("uspGetCountry");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetCountry(int countryId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("CountryID", countryId);
                return CommonBiz.GetCombo("uspGetCountry", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
