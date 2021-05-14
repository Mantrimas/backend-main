using App.Data.DTOs;
using App.Data.DTOs.Requests;
using App.Data.Models;
using App.Main.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Main.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CaseController : ApiController
    {
        private readonly ICaseService _caseService;

        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpGet("{id}")]
        public async Task<CaseDTO> GetAsync(Guid id)
        {
            var entity = await _caseService.GetAsync(id);
            return entity;
        }

        [HttpGet("bycust/{id}")]
        public async Task<IEnumerable<CaseDTO>> GetByCustomerAsync(Guid id)
        {
            var caseList = await _caseService.GetByCustomerIdAsync(id);
            return caseList;
        }

        [HttpGet("byuser/{id}")]
        public async Task<IEnumerable<CaseDTO>> GetByUserAsync(Guid id)
        {
            var caseList = await _caseService.GetByUserIdAsync(id);
            return caseList;
        }

        [HttpGet]
        public async Task<IEnumerable<CaseDTO>> GetAllAsync()
        {
            var caseList = await _caseService.GetAllAsync();
            return caseList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] CaseDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _caseService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _caseService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<CaseDTO> EditAsync([FromBody] CaseEditRequest model)
        {
            //if (!TryValidateModel(model))
            //{
            //    throw new Exception("400");
            //}

            return await _caseService.EditAsync(model);
        }
    }
}
