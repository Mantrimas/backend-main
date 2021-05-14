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
    public class TransactionController : ApiController
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public async Task<TransactionDTO> GetAsync(Guid id)
        {
            var entity = await _transactionService.GetAsync(id);
            return entity;
        }

        [HttpGet("bycustid/{id}")]
        public async Task<IEnumerable<TransactionDTO>> GetByCustomerAsync(Guid id)
        {
            var caseList = await _transactionService.GetByCustomerIdAsync(id);
            return caseList;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionDTO>> GetAllAsync()
        {
            var caseList = await _transactionService.GetAllAsync();
            return caseList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] TransactionDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _transactionService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _transactionService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<TransactionDTO> EditAsync([FromBody] TransactionDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _transactionService.EditAsync(model);
        }
    }
}
