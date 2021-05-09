using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        public string AccountNumber { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }

        public Customer Customer { get; set; }

    }
}
