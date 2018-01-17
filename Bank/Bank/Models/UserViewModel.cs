using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    /// <summary>
    /// View model of user.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets name of user.
        /// </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets surname of user.
        /// </summary>
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

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
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets confirm password of user.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}