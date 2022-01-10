using System.ComponentModel.DataAnnotations;

namespace SuperviseurApi.Models.HelbModel
{
    public class Account
    {
        [Required]
        public int Id { get; set; }
        public User User { get; set; }
        [Required]
        public int Userid { get; set; }
        [Required]
        [MaxLength(50)]
        public string IBAN { get; set; }
        [Required]
        public int balance { get; set; }
        [Required]
        public DateTime dateCreated { get; set; }
        public List<BankTransfer> BankTransferExpiditor { get; set; }
        public List<BankTransfer> BankTransferReceiver { get; set; }
    }
}
