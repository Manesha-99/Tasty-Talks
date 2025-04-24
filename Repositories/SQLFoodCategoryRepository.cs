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


        //Create FoodCategory Function--------------------------------------------------
        public async Task<FoodCategory> CreateAsync(FoodCategory foodCategory)
        {
            await tastyTalksDbContext.FoodCategory.AddAsync(foodCategory);
            await tastyTalksDbContext.SaveChangesAsync();

            return foodCategory;
        }


        //Delete FoodCategory Function-------------------------------------------------
        public async Task<FoodCategory> DeleteAsync(int id)
        {
            var food = await tastyTalksDbContext.FoodCategory.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null) {

                return null;
            }

            tastyTalksDbContext.Remove(food);
            await tastyTalksDbContext.SaveChangesAsync() ;

            return food;
        }


        //Read All FoodCategory Function-------------------------------------------------

        public async Task<FoodCategory> GeByIdAsync(int id)
        {
            var food = await tastyTalksDbContext.FoodCategory.FirstOrDefaultAsync(x => x.Id == id);

            if(food == null)
            {
                return null;
            }

            return food;
        }

        
        public async Task<List<FoodCategory>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 10)
        {
            var foods = tastyTalksDbContext.FoodCategory.AsQueryable();

            //Filtering----

            if(string.IsNullOrWhiteSpace(filterQuery)==false && string.IsNullOrWhiteSpace(filterOn) == false)
            {
                if(filterOn.Equals("Category", StringComparison.OrdinalIgnoreCase))
                {
                    foods = foods.Where(x => x.Category.Contains(filterQuery));
                }
            }

            //Sorting----

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Category", StringComparison.OrdinalIgnoreCase))
                {

                    foods = isAscending ? foods.OrderBy(x => x.Category) : foods.OrderByDescending(x => x.Category);
                }
            }

            //Pagination----

            var skipResults = (pageNumber - 1) * pageSize;

            return await foods.Skip(skipResults).Take(pageSize).ToListAsync();
        }


        //Update FoodCategory Function---------------------------------------------------
        public async Task<FoodCategory> UpdateAsync(int id, FoodCategory foodCategory)
        {
            var existingFood = await tastyTalksDbContext.FoodCategory.FirstOrDefaultAsync(x=>x.Id==id);

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
