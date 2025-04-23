using Microsoft.EntityFrameworkCore;
using Tasty_Talks_BackEnd.Data;
using Tasty_Talks_BackEnd.Model.Domian;

namespace Tasty_Talks_BackEnd.Repositories
{
    public class SQLFoodCategoryRepository : IFoodCategoryRepository
    {
        private readonly TastyTalksDbContext tastyTalksDbContext;

        public SQLFoodCategoryRepository(TastyTalksDbContext tastyTalksDbContext)
        {
            this.tastyTalksDbContext = tastyTalksDbContext;
        }


        //Create FoodCategory Function----
        public async Task<FoodCategory> CreateAsync(FoodCategory foodCategory)
        {
            await tastyTalksDbContext.FoodCategories.AddAsync(foodCategory);
            await tastyTalksDbContext.SaveChangesAsync();

            return foodCategory;
        }

        //Delete FoodCategory Function----
        public async Task<FoodCategory> DeleteAsync(int id)
        {
            var food = await tastyTalksDbContext.FoodCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null) {

                return null;
            }

            tastyTalksDbContext.Remove(food);
            await tastyTalksDbContext.SaveChangesAsync() ;

            return food;
        }


        //Read All FoodCategory Function----

        public async Task<FoodCategory> GeByIdAsync(int id)
        {
            var food = await tastyTalksDbContext.FoodCategories.FirstOrDefaultAsync(x => x.Id == id);

            if(food == null)
            {
                return null;
            }

            return food;
        }

        
        public async Task<List<FoodCategory>> GetAllAsync()
        {
            var foods = await tastyTalksDbContext.FoodCategories.ToListAsync();

            if(foods == null)
            {
                return null;
            }

            return foods;
        }


        //Update FoodCategory Function----
        public async Task<FoodCategory> UpdateAsync(int id, FoodCategory foodCategory)
        {
            var existingFood = await tastyTalksDbContext.FoodCategories.FirstOrDefaultAsync(x=>x.Id==id);

            if (existingFood == null) {
                return null;
            }

            existingFood.Category = foodCategory.Category;
            existingFood.ImageURL = foodCategory.ImageURL;

            await tastyTalksDbContext.SaveChangesAsync();

            return existingFood;

        }
    }
}
