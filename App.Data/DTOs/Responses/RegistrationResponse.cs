using App.Configiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DTOs.Responses
{
    public class RegistrationResponse : AuthResult
    {
        public string UserName { get; set; }
    }
}
