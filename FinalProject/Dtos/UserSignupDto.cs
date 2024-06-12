using System.ComponentModel.DataAnnotations;


namespace FinalProject.BusinessLogic.Dtos
{
    public class UserSignupDto
    {
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 12)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,}$")]
        public string Password { get; set; }

    }

}
