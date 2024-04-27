using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Login
    {
        [Key]
        public int  LoginId { get; set; }
        [Required]
        [Display(Name ="Username")]

        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

    }
}
