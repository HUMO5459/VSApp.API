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
    public class EnteringsController : BaseController
    {
        private readonly IEnteringService _enteringService;

        public EnteringsController(IEnteringService enteringService)
        {
            this._enteringService = enteringService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<EnteringModel>> PostEntering(EnteringModel enteringModel)
        {
            if (enteringModel != null)
            {
                var entering = await _enteringService.AddAsync(enteringModel);
                return Ok(new ResponseModel(entering));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnteringModel>> PutEntering(EnteringModel enteringModel)
        {
            if (enteringModel != null)
            {
                await _enteringService.UpdateAsync(enteringModel);
                return Ok(new ResponseModel(enteringModel));
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnteringModel>> GetEntering(int id)
        {
            if (id != 0)
            {
                var entering = await _enteringService.GetByIdAsync(id);
                if (entering == null)
                {
                    return NotFound();
                }
                return Ok(new ResponseModel(entering));
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EnteringModel>> DeleteEntering(int id)
        {
            if (id != 0)
            {
                var entering = await _enteringService.GetByIdAsync(id);
                if (entering == null)
                {
                    return NotFound();
                }
                await _enteringService.DeleteAsync(entering);

                return Ok(new ResponseModel(entering));
            }
            return BadRequest();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<EnteringModel>>> GetEnterings()
        {
            var enterings = await _enteringService.GetAllAsync();
            return Ok(new ResponseModel(enterings));
        }

    }
}
