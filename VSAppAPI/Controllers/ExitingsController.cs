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
    public class ExitingsController : BaseController
    {
        private readonly IExitingService _exitingService;

        public ExitingsController(IExitingService exitingService)
        {
            this._exitingService = exitingService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ExitingModel>> PostEntering(ExitingModel exitingModel)
        {
            if (exitingModel != null)
            {
                var exiting = await _exitingService.AddAsync(exitingModel);
                return Ok(new ResponseModel(exiting));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExitingModel>> PutEntering(ExitingModel exitingModel)
        {
            if (exitingModel != null)
            {
                await _exitingService.UpdateAsync(exitingModel);
                return Ok(new ResponseModel(exitingModel));
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExitingModel>> GetEntering(int id)
        {
            if (id != 0)
            {
                var exiting = await _exitingService.GetByIdAsync(id);
                if (exiting == null)
                {
                    return NotFound();
                }
                return Ok(new ResponseModel(exiting));
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ExitingModel>> DeleteEntering(int id)
        {
            if (id != 0)
            {
                var exiting = await _exitingService.GetByIdAsync(id);
                if (exiting == null)
                {
                    return NotFound();
                }
                await _exitingService.DeleteAsync(exiting);

                return Ok(new ResponseModel(exiting));
            }
            return BadRequest();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ExitingModel>>> GetEnterings()
        {
            var exitings = await _exitingService.GetAllAsync();
            return Ok(new ResponseModel(exitings));
        }

    }
}
