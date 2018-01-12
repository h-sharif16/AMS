using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Model
{
    [Serializable()]
    public class VisitRequest:BaseModel
    {
        public int VisitReqId { get; set; }

        public string LandlordId { get; set; }

        public int PropertyId { get; set; }

        public int ApartmentId { get; set; }

        public string ClientName { get; set; }

        public string ClientEmail { get; set; }

        public string ClientMobileNo { get; set; }

        public string MessageToLandlord { get; set; }
        public string MessageToClient { get; set; }
    public bool? IsAccepted { get; set; }

       public DateTime? RequestDate { get; set; }

        public DateTime? ResponseDate { get; set; }
    }
}
