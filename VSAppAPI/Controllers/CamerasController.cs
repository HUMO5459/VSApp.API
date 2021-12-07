using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSApp.Business.Interfaces.Base;
using VSApp.Business.Models;
using VSApp.Business.Models.CameraModels;

namespace VSApp.API.Controllers
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CamerasController : BaseController
    {
        private readonly ICameraService _cameraService;

        public CamerasController(ICameraService cameraService)
        {
            this._cameraService = cameraService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CameraModel>> PostCamera(CameraModel model)
        {
            if(model != null)
            {
                var camera = await _cameraService.AddAsync(model);
                return Ok(camera);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CameraModel>> PutCamera(CameraModel model)
        {
            if(model != null)
            {
                await _cameraService.UpdateAsync(model);
                return Ok(true);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CameraModel>> GetCamera(int id)
        {
            if(id != 0)
            {
                var camera = await _cameraService.GetByIdAsync(id);
                if(camera == null)
                {
                    return NotFound();
                }
                return Ok(camera);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CameraModel>> DeleteCamera(int id)
        {
            if(id != 0)
            {
                var camera = await _cameraService.GetByIdAsync(id);
                if (camera == null)
                {
                    return NotFound();
                }
                await _cameraService.DeleteAsync(camera);
                return Ok(true);
            }
            return BadRequest();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<CameraModel>>> GetCameras()
        {
            var cameras = await _cameraService.GetAllAsync();
            return Ok(cameras);
        }

    }
}
