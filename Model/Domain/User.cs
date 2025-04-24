using System.ComponentModel.DataAnnotations;

namespace Tasty_Talks_BackEnd.Model.Domian
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        // Collection navigation property

        public ICollection<Shop> Shop { get; set; }
        public ICollection<Order> Order { get; set; }
       
    }
}
