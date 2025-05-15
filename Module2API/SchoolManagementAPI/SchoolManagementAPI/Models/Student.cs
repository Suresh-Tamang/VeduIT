using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class Student
    {
    [Key]
        public int Id { get; set; }
    [Required]
    [MaxLength(50)]
        public string Name { get; set; }
        [Required]
    [MaxLength(50)]

        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string Course { get; set; }

        [Required]
        public bool Enrolled { get; set; }
    }
}
