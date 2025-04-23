using System.Diagnostics.Contracts;
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
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository foodRepository;
        private readonly IMapper mapper;

        public FoodController(IFoodRepository foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }

        //Create Food Function-----
        [HttpPost]
        public async Task<IActionResult> CreateFood([FromBody] AddFoodDTO addFoodDTO)
        {
            var foodDomainModel = mapper.Map<Foods>(addFoodDTO);

            foodDomainModel = await foodRepository.CreateFoodAsync(foodDomainModel);

            if (foodDomainModel == null) {

                return BadRequest();
            }

            return Ok(foodDomainModel);
        }


        //Read Food Function-----

        [HttpGet]
        public async Task<IActionResult> GetAllFood()
        {
            var foodDomainModel = await foodRepository.GetAllFoodsAsync();

            if (foodDomainModel == null) { 
            
                return BadRequest();
            }

            return Ok(mapper.Map<List<FoodDTO>>(foodDomainModel));
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var foodDomainModel = await foodRepository.GetFoodByIdAsync(id);

            if (foodDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<FoodDTO>(foodDomainModel));
        }


        //Food Update Function-----

        [HttpPut]
        [Route("id")]

        public async Task<IActionResult> FoodUpdate(int id, [FromBody] UpdateFoodDTO updateFoodDTO)
        {
            var foodDomainModel = mapper.Map<Foods>(updateFoodDTO);

            foodDomainModel = await foodRepository.UpdateFoodAsync(id, foodDomainModel);

            if (foodDomainModel == null) {

                return NotFound();
            }

            return Ok(mapper.Map<FoodDTO>(foodDomainModel));
        }


        //Food Delete Function-----

        [HttpDelete]
        [Route("id")]

        public async Task<IActionResult> DeleteFood(int id)
        {
            var foodDomainModel = await foodRepository.DeleteFoodAsync(id);

            if (foodDomainModel == null) { 
            
                return NotFound();
            }

            return Ok();
        }
    }
}
