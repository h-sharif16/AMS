using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Common.Biz
{
   public class ProfessionBiz
    {

        public static List<StaticListItem> GetProfession()
        {
            try
            {
                return CommonBiz.GetCombo("uspGetProfession");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetProfession(int professionId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("ProfessionId", professionId);
                return CommonBiz.GetCombo("uspGetProfession", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
