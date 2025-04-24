using System.ComponentModel.DataAnnotations.Schema;

namespace Tasty_Talks_BackEnd.Model.DTO
{
    public class AddOrderDTO
    {
        public int User_Id { get; set; }

        public int Shop_Id { get; set; }

        public int Food_Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Progress { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
