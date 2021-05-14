using App.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entities
{
    public class Case
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid UserId { get; set; }

        public string CaseNumber { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public ActivityFlag ActivityFlag { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public CaseStatus CaseStatus { get; set; }

        public string Decision { get; set; }


        public virtual ICollection<CaseComment> CaseComments { get; set; }
        public User User { get; set; } 
        public Customer Customer { get; set; }
    }
}
