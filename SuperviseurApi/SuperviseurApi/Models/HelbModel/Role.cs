using System.ComponentModel.DataAnnotations;

namespace SuperviseurApi.Models.HelbModel
{
    public class Role
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string nameRole { get; set; }
        [MaxLength(100)]
        public string roleDescription { get; set; }
    }
}
