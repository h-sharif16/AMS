using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;


namespace AMS.Model
{
    [Serializable()]
    public class ApartmentForAdvartisement: Apartment
    {
       public string ApartmentStatus { get; set; }
        public string PropertyTypeName { get; set; }
        public string PhotoName { get; set; }
        public string PhotoUrl { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        


        public int ApartmentPhotoId { get; set; }
        public string FloorType { get; set; }
    }
}
