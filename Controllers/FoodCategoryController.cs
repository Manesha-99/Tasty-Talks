using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasty_Talks_BackEnd.Model.Domian;
using Tasty_Talks_BackEnd.Model.DTO;
using Tasty_Talks_BackEnd.Repositories;

namespace Tasty_Talks_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryRepository foodCategory;
        private readonly IMapper mapper;

        public FoodCategoryController(IFoodCategoryRepository foodCategory, IMapper mapper)
        {
            this.foodCategory = foodCategory;
            this.mapper = mapper;
        }

        //Create Food Category Function-----------------------------------------------

        [HttpPost]

        public async Task<IActionResult> CreateFoodCategory([FromBody] AddFoodCategoryDTO addFoodCategoryDTO)
        {
            var foodCategoryDomainModel = mapper.Map<FoodCategory>(addFoodCategoryDTO);

            foodCategoryDomainModel = await foodCategory.CreateAsync(foodCategoryDomainModel);

            if (foodCategoryDomainModel == null) {

                return BadRequest();
            }

            return Ok(mapper.Map<FoodCategoryDTO>(foodCategoryDomainModel));
        }


        //Read Food Category Function-------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> GetFoodCategoty([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool isAscending=true,
            [FromQuery] int pageNumber=1, [FromQuery] int pageSize=10)
        {
            var foodCategoryDomainModel = await foodCategory.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            if (foodCategoryDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<List<FoodCategoryDTO>>(foodCategoryDomainModel));
        }


        [HttpGet]
        [Route("id")]

        public async Task<IActionResult>GetFoodCategoryById(int id)
        {
            var foodDomainModel = await foodCategory.GeByIdAsync(id);

            if(foodDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FoodCategoryDTO>(foodDomainModel));
        }


        //Update Food Category--------------------------------------------------------

        [HttpPut]
        [Route("id")]

        public async Task<IActionResult> UpdateFoodAsync(int id, [FromBody] UpdateFoodCategoryDTO updateFoodCategoryDTO)
        {
            var foodDomainModel = mapper.Map<FoodCategory>(updateFoodCategoryDTO);
            foodDomainModel = await foodCategory.UpdateAsync(id, foodDomainModel);

            if (updateFoodCategoryDTO == null) {
                return BadRequest();
            }

            return Ok(mapper.Map<FoodCategoryDTO>(foodDomainModel));
        }


        //Delete FoodCategory--------------------------------------------------------

        [HttpDelete]
        [Route("id")]

        public async Task<IActionResult> DeleteFoodCategory(int id)
        {
            var foodDomainModel = await foodCategory.DeleteAsync(id);

            if (foodDomainModel == null) { 
            
                return NotFound();
            }

            return Ok();
        }
    }
}
