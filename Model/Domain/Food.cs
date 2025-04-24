using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasty_Talks_BackEnd.Model.Domian
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        public string FoodName { get; set; }

        public string Description { get; set; }

        [ForeignKey("Shop")]
        public int Shop_Id { get; set; }

        [ForeignKey("FoodCategory")]
        public int FoodCategory_Id { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public bool Availability { get; set; }

        //Navigation Properties

        public Shop Shop { get; set; }
        public FoodCategory FoodCategory { get; set; }

        // Collection navigation property

        public ICollection<Order> Order { get; set; }


    }
}
