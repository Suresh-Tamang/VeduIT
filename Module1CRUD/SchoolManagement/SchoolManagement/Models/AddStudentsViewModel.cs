using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class AddStudentsViewModel
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Phone]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Course { get; set; }

        public bool Enrolled { get; set; }
    }
}
