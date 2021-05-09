using App.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Main.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        public static BaseModel IdResponse(Guid id)
        {
            return new BaseModel
            {
                Id = id
            };
        }

    }
}
