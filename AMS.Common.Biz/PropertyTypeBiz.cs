using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Common.Biz
{
   public class PropertyTypeBiz
    {

        public static List<StaticListItem> GetPropertyType()
        {
            try
            {
                return CommonBiz.GetCombo("ams.uspGetPropertyType");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<StaticListItem> GetPropertyType(int propertyTypeId)
        {
            try
            {
                Dictionary<string, object> p = new Dictionary<string, object>();
                p.Add("propertyTypeId", propertyTypeId);
                return CommonBiz.GetCombo("ams.uspGetPropertyType", p);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
