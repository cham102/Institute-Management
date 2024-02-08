using System.ComponentModel.DataAnnotations;

namespace ABCUniversityStaff.models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be a 10-digit numeric value.")]
        public string ContactNo { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string NIC { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public int AddUser { get; set; }
        public DateTime AddDate { get; set; }
        public string AddMach { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Session { get; set; }
        public int RecordId { get; set; }
        [Timestamp]
        public byte[] timestamp_column { get; set; }

        //2023/10/06--
        private string _status;

        public string Status
        {
            get => _status;
            set => _status = value ?? "reject";
        }
    }
}
