using App.Data.Entities;
using App.Data.Enums;
using System;

namespace App.Data.DTOs
{
    public static class TransactionExtension
    {
        public static TransactionDTO ToModel(this Transaction entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TransactionDTO
            {
                Id = entity.Id,
                AccountId = entity.AccountId,
                CustomerId = entity.CustomerId,
                Date = entity.Date,
                Amount = entity.Amount,
                Details = entity.Details,
                TransactionType = entity.TransactionType
            };
        }
    }


    public class TransactionDTO
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public Guid CustomerId { get; set; }

        public DateTimeOffset Date { get; set; }

        public double Amount { get; set; }

        public string Details { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
