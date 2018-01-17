using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    /// <summary>
    /// Model for login.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets email of user.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password of user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}