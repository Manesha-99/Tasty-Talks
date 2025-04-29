using System.ComponentModel.DataAnnotations;

namespace Tasty_Talks_BackEnd.Model.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string [] Roles { get; set; }
    }
}
