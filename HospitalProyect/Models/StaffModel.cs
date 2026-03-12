using System.ComponentModel.DataAnnotations;

namespace HospitalProyect.Models
{
    public class StaffModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public int StaffCategoryId { get; set; }
         
        public StaffCategoryModel StaffCategory { get; set; }

        public int? SpecialtyId { get; set; }

        public SpecialtyModel Specialty { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
