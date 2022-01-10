﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Client.Model
{
    public class BankTransfer
    {
        [Required]
        public int Id { get; set; }
        public int ReceiverAccountId { get; set; }
        public int ExpeditorAccountId { get; set; }
        public int Amount { get; set; }
        public virtual Account ReceiverAccount { get; set; }
        public virtual Account ExpeditorAccount { get; set; }
        [MaxLength(500)]
        public string Communication { get; set; }
        [Required]
        public DateTime DateExpedition { get; set; }
    }
}
