namespace AMS.Model
{
    public class UserDetail : User
    {
        public string UserDtlID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string FullName { get; set; }

        public string NID { get; set; }

        public string Address { get; set; }

        public int? DistrictID { get; set; }
    }
}