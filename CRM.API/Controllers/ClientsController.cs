using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.Data.Interfaces;
using CRM.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Authorize]
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
    }
}