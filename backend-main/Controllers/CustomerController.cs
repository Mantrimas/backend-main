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
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<CustomerDTO> GetAsync(Guid id)
        {
            var entity = await _customerService.GetAsync(id);
            return entity;
        }

        [HttpGet("byid/{id}")]
        public async Task<IEnumerable<CustomerDTO>> GetByCustomerAsync(Guid id)
        {
            var caseList = await _customerService.GetByIdAsync(id);
            return caseList;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var caseList = await _customerService.GetAllAsync();
            return caseList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] CustomerDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _customerService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _customerService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<CustomerDTO> EditAsync([FromBody] CustomerDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _customerService.EditAsync(model);
        }
    }
}
