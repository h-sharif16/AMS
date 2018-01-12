using System;

namespace AMS.Model
{
    [Serializable()]
    public class UserDetail : User
    {
        public int UserDtlID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string NID { get; set; }

        public string TIN { get; set; }

        public string CompanyName { get; set; }

        public bool? IsShowAsCompanyName { get; set; }

        public int? ProfessionId { get; set; }

        public string OthersProfession { get; set; }

        public int? ReligionId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfileImageUrl { get; set; }

    }
}