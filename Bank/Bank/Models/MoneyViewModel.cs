using System.ComponentModel.DataAnnotations;
using Bank.Infrastructure.Attributes;

namespace Bank.Models
{
    /// <summary>
    /// Model store transfer money.
    /// </summary>
    public class MoneyViewModel
    {
        /// <summary>
        /// Gets or sets amount of money.
        /// </summary>
        [Required]
        [MoneyValue(ErrorMessage = "Money must be greater than 0")]
        public double Amount { get; set; }
    }
}