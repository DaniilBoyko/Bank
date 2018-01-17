using System.ComponentModel.DataAnnotations;
using Bank.Infrastructure.Attributes;

namespace Bank.Models
{
    /// <summary>
    /// View model of the account.
    /// </summary>
    public class AccountViewModel
    {
        /// <summary>
        /// Gets or sets id of the account.
        /// </summary>
        [Display(Name = "Account #")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets type of the account.
        /// </summary>
        [Required]
        [Display(Name = "Account Type")]
        public string Type { get; set; }
        
        /// <summary>
        /// Gets or sets amount money of the account.
        /// </summary>
        [Required]
        [PositiveValue(ErrorMessage = "Money must be greater than 0 or equal.")]
        [Display(Name = "Money")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets points of the account.
        /// </summary>
        [Display(Name = "Bonus points")]
        public int Points { get; set; }
    }
}