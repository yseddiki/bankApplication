using System.ComponentModel.DataAnnotations;

namespace API_Client.Model;
public class User
{
    public int Id { get; set; }

    public virtual Role Role { get; set; }
    [Required]
    public int RoleId { get; set; }
   

    [Required]
    [MaxLength(50)]
    public string username { get; set; }
    [Required]
    [MaxLength(50)]
    public string password { get; set; }
    [Required]
    [MaxLength(50)]
    public string firstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string lastName { get; set; }
    [Required]
    [MaxLength(50)] 
    public string address { get; set; }
    [Required]
    [MaxLength(50)] 
    public string city { get; set; }
    [Required]
    [MaxLength(50)] 
    public string postalCode { get; set; }
    [Required]
    [MaxLength(50)] 
    public string country { get; set; }
    [MaxLength(50)] 
    public string phone { get; set; }
    [MaxLength(100)]
    public string email { get; set; }
    public DateTime dateInscription { get; set; }
   
    
}

