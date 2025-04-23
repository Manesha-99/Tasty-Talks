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
        public async Task<Foods> CreateFoodAsync(Foods foods)
        {
            var food = await tastyTalksDbContext.Foods.AddAsync(foods);

            await tastyTalksDbContext.SaveChangesAsync();

            return foods;

        }

        //Delete Food Function----
        public async Task<Foods> DeleteFoodAsync(int id)
        {
            var food = await tastyTalksDbContext.Foods.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null) 
            {
                return null;
            }

            tastyTalksDbContext.Foods.Remove(food);
            await tastyTalksDbContext.SaveChangesAsync() ;

            return food;

        }

        //Read Food Function-----
        public async Task<List<Foods>> GetAllFoodsAsync()
        {
            var foods = await tastyTalksDbContext.Foods.ToListAsync();

            return foods;
        }

        public async Task<Foods> GetFoodByIdAsync(int id)
        {
            var food = await tastyTalksDbContext.Foods.FirstOrDefaultAsync(x=>x.Id==id);

            if (food == null) {
                return null;
            }

            return food;
        }


        //Update Foods Function----
        public async Task<Foods> UpdateFoodAsync(int id, Foods foods)
        {
            var existingFood = await tastyTalksDbContext.Foods.FirstOrDefaultAsync(x=>x.Id==id);

            if (existingFood == null)
            {
                return null;
            }

            existingFood.FoodName = foods.FoodName;
            existingFood.Description = foods.Description;
            existingFood.Price = foods.Price;
            existingFood.ImageURL = foods.ImageURL;
            existingFood.Availability = foods.Availability;
            existingFood.shop_Id = foods.shop_Id;
            existingFood.foodCategory_Id = foods.foodCategory_Id;

            await tastyTalksDbContext.SaveChangesAsync();

            return existingFood;
        }
    }
}
