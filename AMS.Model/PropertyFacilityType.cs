using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Model
{
    [Serializable()]
    public class PropertyFacilityType : BaseModel
    {
        public int FacilityTypeId { get; set; }

        public string FacilityName { get; set; }
    }
}
