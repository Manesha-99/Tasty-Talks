using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasty_Talks_BackEnd.Model.Domian
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }


        [ForeignKey("Shop")]
        public int Shop_Id { get; set; }

        [ForeignKey("Food")]
        public int Food_Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Progress { get; set; }

        public DateTime CreatedAt { get; set; }

        //Navigation Properties
        
        public User User { get; set; } 
        public Shop Shop { get; set; }
        public Food Food { get; set; }
    }
}
