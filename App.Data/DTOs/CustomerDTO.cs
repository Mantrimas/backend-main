using App.Data.Entities;
using App.Data.Enums;
using System;


namespace App.Data.DTOs
{
    public static class CustomerExtension
    {
        public static CustomerDTO ToModel(this Customer entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CustomerDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address,
                Citizenship = entity.Citizenship,
                NationalId = entity.NationalId,
                BirthDate = entity.BirthDate,
                CustomerType = entity.CustomerType
            };
        }
    }


    public class CustomerDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Citizenship { get; set; }

        public string NationalId { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public CustomerType CustomerType { get; set; }
    }
}
