using App.Data.Entities;
using App.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DTOs
{
    public static class CaseExtension
    {
        public static CaseDTO ToModel(this Case entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CaseDTO
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                UserId = entity.UserId,
                CaseNumber = entity.CaseNumber,
                CreatedAt = entity.CreatedAt,
                ActivityFlag = entity.ActivityFlag,
                Description = entity.Description
            };
        }
    }


    public class CaseDTO
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid UserId { get; set; }

        public string CaseNumber { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public ActivityFlag ActivityFlag { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
