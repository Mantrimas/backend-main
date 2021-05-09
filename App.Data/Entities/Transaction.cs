using App.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public double Amount { get; set; }

        public string Details { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public TransactionType TransactionType { get; set; }


        public Account Account { get; set; }
    }
}
