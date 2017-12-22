using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Common.Biz
{
   public class StateDivisionBiz
    {

        public static List<StaticListItem> GetStateDivision()
        {
            try
            {
                return CommonBiz.GetCombo("uspGetStateOrDivision");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetStateDivision(int countryId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("CountryID", countryId);
                return CommonBiz.GetCombo("uspGetStateOrDivision", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static List<StaticListItem> GetStateDivision(int countryId,int divisionId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("CountryID", countryId);
                p.Add("StateDivisionId", divisionId);
                return CommonBiz.GetCombo("uspGetStateOrDivision", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
