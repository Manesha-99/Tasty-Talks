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
    public class ShopsController : ControllerBase
    {
        private readonly IShopsRepository shopsRepository;
        private readonly IMapper mapper;

        public ShopsController(IShopsRepository shopsRepository, IMapper mapper)
        {
            this.shopsRepository = shopsRepository;
            this.mapper = mapper;
        }


        //Create Shop Function----------------------------------------

        [HttpPost]

        public async Task<IActionResult> CreateShop([FromBody] AddShopsDTO addShopsDTO)
        {
            var shopsDomainModel = mapper.Map<Shop>(addShopsDTO);

            shopsDomainModel = await shopsRepository.CreateShopAsync(shopsDomainModel);

            if (shopsDomainModel == null)
            {

                return BadRequest();
            }

            return Ok();
        }

        //Read Shop Function-----------------------------------------

        [HttpGet]

        public async Task<IActionResult> GetShop([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool isAscending=true, 
            [FromQuery] int pageNumber=1, [FromQuery] int pageSize=10)
        {
            var shopsDomainModel = await shopsRepository.GetShopsAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            if (shopsDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<ShopsDTO>>(shopsDomainModel));


        }

        [HttpGet]
        [Route("id")]

        public async Task<IActionResult> GetShopsById(int id)
        {
            var shopDomainModel = await shopsRepository.GetShopByIdAsync(id);

            if (shopDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ShopsDTO>(shopDomainModel));
        }

        //Update Shop function---------------------------------------

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateShop([FromQuery] int id , [FromBody] UpdateShopDTO updateShopDTO)
        {
            var shopDomainModel = mapper.Map<Shop>(updateShopDTO);

            shopDomainModel = await shopsRepository.UpdateShopAsync(id, shopDomainModel);

            if(shopDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ShopsDTO>(shopDomainModel));

        }


        //Delete Shop Function---------------------------------------

        [HttpDelete]
        [Route("id")]

        public async Task<IActionResult> DeleteShop([FromQuery] int id)
        {
            var shopDomainModel = await shopsRepository.DeleteShopAsync(id);

            if(shopDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }

}
