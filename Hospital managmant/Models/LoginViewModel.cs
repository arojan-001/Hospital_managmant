namespace Hospital_management.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        public int LoginID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int Type { get; set; }
    }
}
