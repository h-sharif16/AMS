using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Model
{
    [Serializable()]
    public class Property:BaseModel
    {
        public int PropertyId { get; set; }

        public string PropertyName { get; set; }
        public int PropertyTypeId { get; set; }
        public string LandloadId { get; set; }

        public DateTime? BuiltYear { get; set; }

        public int CountryID { get; set; }

        public int DivisionId { get; set; }

        public int DistrictId { get; set; }

        public int? UpazilaId { get; set; }

        public string HoldingNo { get; set; }

        public string RoadNo { get; set; }

        public string SectorOrBlock { get; set; }

        public int? TotalSpace { get; set; }

        public int NoOfFloors { get; set; }

        public bool IsParkingAvailable { get; set; }
        public int? TotalParkingSpace { get; set; }
        public List<PropertyPhoto> PropertyPhotoList { get; set; }
        public List<PropertyFacilityType> PropertyFacilityTypeList { get; set; }
        public List<PropertySecurityType> PropertySecurityTypeList { get; set; }
        public List<Apartment> ApartmentList { get; set; }

    }

}
