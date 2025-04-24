using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasty_Talks_BackEnd.Model.Domian
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public string ShopName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string OpenTime { get; set; }

        public string CloseTime { get; set; }

        public bool Status { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        //Navigation Properties

        public User User { get; set; }

        // Collection navigation property
        public ICollection<Food> Food { get; set; }

        public ICollection<Order> Order { get; set; }

    }
}
