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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        //Order Create Function--------------------------

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderDTO addOrderDTO)
        {
            var orderDomainModel = mapper.Map<Order>(addOrderDTO);
            orderDomainModel = await orderRepository.CreateAsync(orderDomainModel);

            if (orderDomainModel == null) {
                return BadRequest();
            }

            return Ok(mapper.Map<OrderDTO>(orderDomainModel));
        }


        //Order Get Function-----------------------------

        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery ,[FromQuery] string? sortBy, [FromQuery] bool isAscending=true, 
            [FromQuery] int pageNumber=1, [FromQuery] int pageSize=10)
        {
            var orderDomainModel = await orderRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            if (orderDomainModel == null)
            {

                return BadRequest();
            }

            return Ok(mapper.Map<List<OrderDTO>>(orderDomainModel));

        }

        [HttpGet]
        [Route("id")]

        public async Task<IActionResult> GetById(int id)
        {
            var orderDomainModel = await orderRepository.GetByIdAsync(id);

            if (orderDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OrderDTO>(orderDomainModel));
        }

        //Update Order Function----

        [HttpPut]
        [Route("id")]

        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDTO updateOrderDTO)
        {
            var orderDomainModel = mapper.Map<Order>(updateOrderDTO);

            orderDomainModel = await orderRepository.UpdateAsync(id, orderDomainModel);

            if(orderDomainModel == null)
            {
                return BadRequest();
            }

            return Ok(mapper.Map<OrderDTO>(orderDomainModel));
        }


        //Delete Order Function----
        [HttpDelete]
        [Route("id")]

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orderDomainModel = await orderRepository.DeleteAsync(id);

            if(orderDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
