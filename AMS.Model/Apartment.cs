using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Model
{
    [Serializable()]
    public class Apartment : Property
    {
        public int ApartmentId { get; set; }

         
        public string ApartmentNoOrName { get; set; }
        
     

        public int FloorNo { get; set; }

        public int ApartmentSpace { get; set; }

        public int? Beds { get; set; }

        public int? AttachBatch { get; set; }

        public int? CommonBath { get; set; }

        public string DiningPosition { get; set; }

        public int? StaffRoom { get; set; }

        public int? StaffToilet { get; set; }

        public int Balconies { get; set; }

        public int? FloorTypeId { get; set; }

        public int Rent { get; set; }

        public int? Advance { get; set; }

        public int? SecurityAmount { get; set; }

        public int? ServiceCharge { get; set; }

        public decimal? GasBill { get; set; }

        public decimal? CableTvBill { get; set; }

        public decimal? InternetBill { get; set; }

        public string Description { get; set; }

        public int VacancyStatusId { get; set; }
        public List<ApartmentPhotos> ApartmentPhotoses { get; set; }

    }

}
