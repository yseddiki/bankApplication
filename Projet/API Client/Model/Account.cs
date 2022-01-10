using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Client.Model
{
    public class Account
    {
        [Required]
        public int Id { get; set; }
        public virtual User User { get; set; }
        [Required]
        public int Userid { get; set; }
        [Required]
        [MaxLength(50)]
        public string IBAN { get; set; }
        [Required]
        public int balance { get; set; }
        [Required]
        public DateTime dateCreated { get; set; }
        [JsonIgnore]
        public virtual List<BankTransfer> BankTransferExpiditor { get; set; }
        [JsonIgnore]
        public virtual List<BankTransfer> BankTransferReceiver { get; set; }
    }
}
