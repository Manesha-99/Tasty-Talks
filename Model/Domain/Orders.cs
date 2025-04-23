//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Tasty_Talks_BackEnd.Model.Domian
//{
//    public class Orders
//    {
//        [Key]
//        public int Id { get; set; }

//        [ForeignKey("Users")]
//        public int User_Id { get; set; }

//        [ForeignKey("Shops")]
//        public int Shop_Id { get; set; }

//        [ForeignKey("Foods")]
//        public int Food_Id { get; set; }

//        public int Quantity { get; set; }

//        public double Price { get; set; }

//        public DateTime CreatedAt { get; set; }

//        //Navigation Properties

//        public Users Users { get; set; }
//        public Shops Shops { get; set; }
//        public Foods Foods { get; set; }
//    }
//}
