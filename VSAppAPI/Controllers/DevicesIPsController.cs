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
    public class DevicesIPsController : BaseController
    {
        private readonly IDevicesIPService _devicesIPService;

        public DevicesIPsController(IDevicesIPService devicesIPService)
        {
            this._devicesIPService = devicesIPService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<DevicesIPModel>> PostDevice(DevicesIPModel devicesIPModel)
        {
            if(devicesIPModel != null)
            {
                var device = await _devicesIPService.AddAsync(devicesIPModel);
                return Ok(new ResponseModel(device));
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DevicesIPModel>> PutDevice(DevicesIPModel devicesIPModel)
        {
            if (devicesIPModel != null)
            {
                await _devicesIPService.UpdateAsync(devicesIPModel);
                return Ok(new ResponseModel(devicesIPModel));
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DevicesIPModel>> GetDevice(int id)
        {
            if (id != 0)
            {
                var device = await _devicesIPService.GetByIdAsync(id);
                if (device == null)
                {
                    return NotFound();
                }
                return Ok(new ResponseModel(device));
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DevicesIPModel>> DeleteDevice(int id)
        {
            if (id != 0)
            {
                var device = await _devicesIPService.GetByIdAsync(id);
                if (device == null)
                {
                    return NotFound();
                }
                await _devicesIPService.DeleteAsync(device);

                return Ok(new ResponseModel(device));
            }
            return BadRequest();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<DevicesIPModel>>> GetDevices()
        {
            var devices = await _devicesIPService.GetAllAsync();
            return Ok(new ResponseModel(devices));
        }
    }
}
