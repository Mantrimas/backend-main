using App.Data.DTOs;
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
    public class CaseCommentController : ApiController
    {
        private readonly ICaseCommentService _caseCommentService;

        public CaseCommentController(ICaseCommentService caseCommentService)
        {
            _caseCommentService = caseCommentService;
        }

        [HttpGet("{id}")]
        public async Task<CaseCommentDTO> GetAsync(Guid id)
        {
            var entity = await _caseCommentService.GetAsync(id);
            return entity;
        }

        [HttpGet("bycaseid/{id}")]
        public async Task<IEnumerable<CaseCommentDTO>> GetByCustomerAsync(Guid id)
        {
            var caseList = await _caseCommentService.GetByCaseIdAsync(id);
            return caseList;
        }

        [HttpGet]
        public async Task<IEnumerable<CaseCommentDTO>> GetAllAsync()
        {
            var caseList = await _caseCommentService.GetAllAsync();
            return caseList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] CaseCommentDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _caseCommentService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _caseCommentService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<CaseCommentDTO> EditAsync([FromBody] CaseCommentDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _caseCommentService.EditAsync(model);
        }
    }
}
