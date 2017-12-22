using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Common.Biz
{
   public class ReligionBiz
    {
        public static List<StaticListItem> GetReligion()
        {
            try
            {
                return CommonBiz.GetCombo("uspGetReligion");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetReligion(int religionId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("ReligionId", religionId);
                return CommonBiz.GetCombo("uspGetReligion", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
