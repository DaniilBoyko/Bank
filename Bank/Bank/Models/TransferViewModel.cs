using System.ComponentModel.DataAnnotations;
using Bank.Infrastructure.Attributes;

namespace Bank.Models
{
    /// <summary>
    /// Model for transfer money from one account to another.
    /// </summary>
    public class TransferViewModel
    {
        /// <summary>
        /// Gets or sets id of recipient.
        /// </summary>
        [Required]
        [Display(Name = "Id of recipient")]
        public int ToId { get; set; }

        /// <summary>
        /// Gets or sets amount of transfer.
        /// </summary>
        [Required]
        [MoneyValue(ErrorMessage = "Money must be greater than 0")]
        public double Amount { get; set; }
    }
}