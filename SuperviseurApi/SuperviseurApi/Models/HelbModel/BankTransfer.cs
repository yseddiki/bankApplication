using System.ComponentModel.DataAnnotations;

namespace SuperviseurApi.Models.HelbModel
{
    public class BankTransfer
    {

        [Required]
        public int Id { get; set; }
        public int ReceiverAccountId { get; set; }
        public int ExpeditorAccountId { get; set; }
        public int Amount { get; set; }
        public Account ReceiverAccount { get; set; }
        public Account ExpeditorAccount { get; set; }
        [MaxLength(500)]
        public string Communication { get; set; }
        [Required]
        public DateTime DateExpedition { get; set; }
    }
}
