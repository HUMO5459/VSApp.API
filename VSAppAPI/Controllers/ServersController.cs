using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VSApp.Business.Interfaces;
using VSApp.Business.Models;
using VSApp.Core.Entities;
using VSApp.Infrastructure.Data;

namespace VSApp.API.Controllers
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ServersController : BaseController
    {
        private readonly IServerService _serverService;

        public ServersController(IServerService serverService)
        {
            this._serverService = serverService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServerModel>> PostDevice(ServerModel devicesIPModel)
        {
            if(devicesIPModel != null)
            {
                var device = await _serverService.AddAsync(devicesIPModel);
                return Ok(device);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServerModel>> PutDevice(ServerModel devicesIPModel)
        {
            if (devicesIPModel != null)
            {
                await _serverService.UpdateAsync(devicesIPModel);
                return Ok(devicesIPModel);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServerModel>> GetDevice(int id)
        {
            if (id != 0)
            {
                var device = await _serverService.GetByIdAsync(id);
                if (device == null)
                {
                    return NotFound();
                }
                return Ok(device);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServerModel>> DeleteDevice(int id)
        {
            if (id != 0)
            {
                var device = await _serverService.GetByIdAsync(id);
                if (device == null)
                {
                    return NotFound();
                }
                await _serverService.DeleteAsync(device);

                return Ok(device);
            }
            return BadRequest();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ServerModel>>> GetDevices()
        {
            var devices = await _serverService.GetAllAsync();
            return Ok(devices);
        }
    }
}
