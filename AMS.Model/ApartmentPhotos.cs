using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Common.Model;

namespace AMS.Model
{
   public class ApartmentPhotos:BaseModel
    {
        public int ApartmentPhotoId { get; set; }

        public int ApartmentId { get; set; }

        public int PropertyId { get; set; }

        public string LandloadId { get; set; }

        public string PhotoName { get; set; }
        public int ApartmentPhotoSerial { get; set; }
        public string PhotoUrl { get; set; }
    }
}
