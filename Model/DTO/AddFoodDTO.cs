using System.ComponentModel.DataAnnotations.Schema;

namespace Tasty_Talks_BackEnd.Model.DTO
{
    public class AddFoodDTO
    {
        public string FoodName { get; set; }

        public string Description { get; set; }

        public int shop_Id { get; set; }

        public int foodCategory_Id { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public bool Availability { get; set; }
    }
}
