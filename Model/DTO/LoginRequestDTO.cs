using System.ComponentModel.DataAnnotations;

namespace Tasty_Talks_BackEnd.Model.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
