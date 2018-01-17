using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bank.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute for money value.
    /// </summary>
    public class MoneyValueAttribute : ValidationAttribute
    {
        /// <summary>
        /// Check money for valid.
        /// </summary>
        /// <param name="value">value of money</param>
        /// <returns>Boolean represent the validate.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
          
            return value is double d && d > 0;
        }
    }
}