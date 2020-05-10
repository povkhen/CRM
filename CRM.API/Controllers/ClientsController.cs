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
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _repo;
        private readonly IMapper _mapper;
        public ClientsController(IClientRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _repo.GetAll();
            var clientsToReturn = _mapper.Map<IEnumerable<ClientForListDto>>(clients);
            return Ok(clientsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _repo.Get(id);
            var clientToReturn = _mapper.Map<ClientForDetailedDto>(client);
            return Ok(clientToReturn);
        }
        
        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetOrders(int id)
        {
            var orders = await _repo.GetAllOrders();
            var clientsOrders = orders.Where(i => i.OwnerId == id);
            var ordersToReturn = _mapper.Map<IEnumerable<OrderForListDto>>(clientsOrders);
            return Ok(ordersToReturn);
        }

         [HttpPost("{id}/addorder")]
        public async Task<IActionResult> AddOrder(int ownerId,
            [FromForm] OrderForAddingDto orderForAddingDto)
        {    
            var owners = await _repo.GetAll();        
            if(!owners.Any(i => i.Id == ownerId))
                return Unauthorized();
             
            var ownerFromRepo = await _repo.Get(ownerId);

            if (await _repo.NumberExists(orderForAddingDto.Number))
                return BadRequest("Number already exists");

            var orderToCreate = _mapper.Map<Order>(orderForAddingDto);

            ownerFromRepo.Orders.Add(orderToCreate);

            if(await _repo.SaveAll())
            {
                return CreatedAtRoute("GetPhoto", new {controller = "Clients" ,id = orderToCreate.Id},
                    orderToCreate);
            }
            return BadRequest("Could not add the photo");
        }
    }
}   