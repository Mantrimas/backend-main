using App.Data.Entities;
using System;

namespace App.Data.DTOs
{
    public static class AccountExtension
    {
        public static AccountDTO ToModel(this Account entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new AccountDTO
            {
                Id = entity.Id,
                CustomerId = (Guid)entity.CustomerId,
                AccountNumber = entity.AccountNumber
            };
        }
    }


    public class AccountDTO
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }


        public string AccountNumber { get; set; }
    }
}
