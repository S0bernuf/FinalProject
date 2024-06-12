using System.ComponentModel.DataAnnotations;


namespace FinalProject.Database.Entities
{
    /*
     * 1. remove not used usings - DONE
     */
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string UserName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public string Role { get; set; } = "User";

        public virtual List<Person> Persons { get; set; }

    }
}
