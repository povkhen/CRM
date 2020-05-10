using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.Data.Interfaces;
using CRM.API.DTOs;
using CRM.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IClientRepository _repo;
        private readonly IMapper _mapper;
        public OrdersController(IClientRepository repo, IMapper mapper)
        {
           
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name="GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _repo.GetOrder(id);
            var orderToReturn = _mapper.Map<OrderForDetailedDto>(order);
            return Ok(orderToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _repo.GetAllOrders();
            var ordersToReturn = _mapper.Map<IEnumerable<OrderForListDto>>(orders);
            return Ok(ordersToReturn);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrder([FromForm] OrderForAddingDto orderForAddingDto)
        {
             if (await _repo.NumberExists(orderForAddingDto.Number))
                return BadRequest("Number already exists");

            var orderToCreate = _mapper.Map<Order>(orderForAddingDto);

            var createdOrder = await _repo.AddOrder(orderToCreate);

            var orderToReturn = _mapper.Map<OrderForDetailedDto>(createdOrder);

            return CreatedAtRoute("GetOrder", new {id = createdOrder.Id}, orderToReturn);
        }
        


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderForUpdateDto orderForUpdateDto)
        {
            
            var orderFromRepo = await _repo.Get(id);
    
            _mapper.Map(orderForUpdateDto, orderFromRepo);
            
            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating order {id} failed on save");   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id) 
        {
            var orders = await _repo.GetAllOrders();
            if( !orders.Any(p => p.Id == id))
                return Unauthorized();

            var orderFromRepo = await _repo.GetOrder(id);
            _repo.DeleteOrder(orderFromRepo);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the photo");
        }
    }
}