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
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}")]
        public async Task<AccountDTO> GetAsync(Guid id)
        {
            var entity = await _accountService.GetAsync(id);
            return entity;
        }

        [HttpGet("bycustid/{id}")]
        public async Task<IEnumerable<AccountDTO>> GetByCustomerAsync(Guid id)
        {
            var caseList = await _accountService.GetByCustIdAsync(id);
            return caseList;
        }

        [HttpGet]
        public async Task<IEnumerable<AccountDTO>> GetAllAsync()
        {
            var caseList = await _accountService.GetAllAsync();
            return caseList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] AccountDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _accountService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _accountService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<AccountDTO> EditAsync([FromBody] AccountDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _accountService.EditAsync(model);
        }
    }
}
