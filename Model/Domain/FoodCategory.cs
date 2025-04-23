namespace Tasty_Talks_BackEnd.Model.Domian
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }

        public string ImageURL { get; set; }


        // Collection navigation property
        public ICollection<Foods> Foods { get; set; }
        
    }
}
