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

        public Guid AccountId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTimeOffset Date { get; set; }

        public double Amount { get; set; }

        public string Details { get; set; }

        public string Accoun

        [Column(TypeName = "nvarchar(24)")]
        public TransactionType TransactionType { get; set; }


        public Account Account { get; set; }
        public Customer Customer { get; set; }
    }
}
