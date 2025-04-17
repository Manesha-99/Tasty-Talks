namespace Tasty_Talks_BackEnd.Model.Domian
{
    public class Shops
    {
        public int Id { get; set; }

        public int UsersId { get; set; }
        public string ShopName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string OpenTime { get; set; }

        public string CloseTime { get; set; }

        public bool Status { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        //Navigation Properties

        public Users Users { get; set; }
    }
}
