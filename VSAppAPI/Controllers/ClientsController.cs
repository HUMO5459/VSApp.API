using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSApp.Business.Interfaces;
using VSApp.Business.Models;

namespace VSApp.API.Controllers
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClientsController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ClientModel>> PostClient(ClientModel clientModel)
        {
            if(clientModel != null)
            {
                var client = await _clientService.AddAsync(clientModel);
                return Ok(new ResponseModel(client));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModel>> PutClient(ClientModel clientModel)
        {
            if(clientModel != null)
            {
                await _clientService.UpdateAsync(clientModel);
                return Ok(new ResponseModel(clientModel));
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClient(int id)
        {
            if(id != 0)
            {
                var client = await _clientService.GetByIdAsync(id);
                if(client == null)
                {
                    return NotFound();
                }
                return Ok(new ResponseModel(client));
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientModel>> DeleteClient(int id)
        {
            if (id != 0)
            {
                var client = await _clientService.GetByIdAsync(id);
                if (client == null)
                {
                    return NotFound();
                }
                await _clientService.DeleteAsync(client);

                return Ok(new ResponseModel(client));
            }
            return BadRequest();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ClientModel>>> GetClients()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }
    }
}
