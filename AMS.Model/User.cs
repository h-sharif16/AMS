using AMS.Common.Model;

namespace AMS.Model
{
    public class User : BaseModel
    {
        public string UserID { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public string Password { get; set; }

        public char RoleTypeID { get; set; }
        public string RoleName { get; set; }
    }
}