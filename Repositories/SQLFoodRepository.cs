using Microsoft.EntityFrameworkCore;
using Tasty_Talks_BackEnd.Data;
using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public class SQLFoodRepository:IFoodRepository
    {
        private readonly TastyTalksDbContext tastyTalksDbContext;

        public SQLFoodRepository(TastyTalksDbContext tastyTalksDbContext)
        {
            this.tastyTalksDbContext = tastyTalksDbContext;
        }


        //Create Food Function-----
        public async Task<Food> CreateFoodAsync(Food foods)
        {
            var food = await tastyTalksDbContext.Food.AddAsync(foods);

            await tastyTalksDbContext.SaveChangesAsync();

            return foods;

        }

        //Delete Food Function----
        public async Task<Food> DeleteFoodAsync(int id)
        {
            var food = await tastyTalksDbContext.Food.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null) 
            {
                return null;
            }

            tastyTalksDbContext.Food.Remove(food);
            await tastyTalksDbContext.SaveChangesAsync() ;

            return food;

        }

        //Read Food Function-----
        public async Task<List<Food>> GetAllFoodsAsync()
        {
            var foods = await tastyTalksDbContext.Food.ToListAsync();

            return foods;
        }

        public async Task<Food> GetFoodByIdAsync(int id)
        {
            var food = await tastyTalksDbContext.Food.FirstOrDefaultAsync(x=>x.Id==id);

            if (food == null) {
                return null;
            }

            return food;
        }


        //Update Foods Function----
        public async Task<Food> UpdateFoodAsync(int id, Food foods)
        {
            var existingFood = await tastyTalksDbContext.Food.FirstOrDefaultAsync(x=>x.Id==id);

            if (existingFood == null)
            {
                return null;
            }

            existingFood.FoodName = foods.FoodName;
            existingFood.Description = foods.Description;
            existingFood.Price = foods.Price;
            existingFood.ImageURL = foods.ImageURL;
            existingFood.Availability = foods.Availability;
            existingFood.Shop_Id = foods.Shop_Id;
            existingFood.FoodCategory_Id = foods.FoodCategory_Id;

            await tastyTalksDbContext.SaveChangesAsync();

            return existingFood;
        }
    }
}
