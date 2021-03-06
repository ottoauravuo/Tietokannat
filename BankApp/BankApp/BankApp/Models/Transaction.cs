﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public partial class Transaction
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Column("IBAN")]
        [StringLength(20)]
        public string Iban { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }

        [ForeignKey(nameof(Iban))]
        [InverseProperty(nameof(Account.Transaction))]
        public virtual Account IbanNavigation { get; set; }
    }
}