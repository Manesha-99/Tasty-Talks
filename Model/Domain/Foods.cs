using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasty_Talks_BackEnd.Model.Domian
{
    public class Foods
    {
        [Key]
        public int Id { get; set; }

        public string FoodName { get; set; }

        public string Description { get; set; }

        [ForeignKey("Shops")]
        public int shop_Id { get; set; }

        [ForeignKey("FoodCategories")]
        public int foodCategory_Id { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public bool Availability { get; set; }

        //Navigation Properties

        public Shops Shops { get; set; }
        public FoodCategory FoodCategories { get; set; }

        // Collection navigation property
        

    }
}
