using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Data.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public CustomerType CustomerType { get; set; }


        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Case> Cases { get; set; }

    }
}
