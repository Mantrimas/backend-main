using App.Data.Entities;
using App.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DTOs.Requests
{
    public class CaseEditRequest
    {
        public Guid Id { get; set; }

        public CaseStatus CaseStatus { get; set; }

        public string Decision { get; set; }
    }
}
