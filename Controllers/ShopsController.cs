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


        //Create Shop Function

        [HttpPost]

        public async Task<IActionResult> CreateShop([FromBody] AddShopsDTO addShopsDTO)
        {
            var shopsDomainModel = mapper.Map<Shops>(addShopsDTO);

            shopsDomainModel = await shopsRepository.CreateShopAsync(shopsDomainModel);

            if (shopsDomainModel == null)
            {

                return BadRequest();
            }

            return Ok();
        }

        //Read Shop Function

        [HttpGet]

        public async Task<IActionResult> GetShop()
        {
            var shopsDomainModel = await shopsRepository.GetShopsAsync();

            if (shopsDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<ShopsDTO>>(shopsDomainModel));


        }
    }

}
