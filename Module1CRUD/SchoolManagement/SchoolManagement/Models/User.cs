using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Username { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string PasswordHash { get; set; }
    }
}
