using System;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class CaseComment
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public Guid CaseId { get; set; }

        public string Comment { get; set; }

        public DateTimeOffset CreatedAt { get; set; }


        public User User { get; set; }

        public Case Case { get; set; }
    }
}
