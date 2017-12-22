using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using AMS.Common.Model;

namespace AMS.Model
{
    [Serializable()]
    public class PropertyPhoto : BaseModel
    {
       
        public int PropertyId { get; set; }

        public int PhotoId { get; set; }

        public string PhotoName { get; set; }

        public string PhotoUrl { get; set; }
        public int PropertyPhotoSerial { get; set; }
        public FileUpload FileUpload { get; set; }



    }
}
