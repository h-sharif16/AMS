using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Model
{
    [Serializable()]
    public class PropertySecurityType : BaseModel
    {
        public int SecurityTypeId { get; set; }

        public string SecurityType { get; set; }

    }
}
