using System.ComponentModel.DataAnnotations;

namespace HospitalProyect.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato de correo invalido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
