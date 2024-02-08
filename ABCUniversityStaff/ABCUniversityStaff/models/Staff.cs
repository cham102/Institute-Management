using System.ComponentModel.DataAnnotations;

namespace ABCUniversityStaff.models
{
    public class Staff
    {
            
        public int ID { get; set; }
        public string StaffUserName { get; set; }
        public string StaffPassword { get; set; }
        public string StaffLastName { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffDesignation { get; set; }

    }
}
