using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bank.Infrastructure.Attributes
{
    /// <summary>
    /// Check value for positive.
    /// </summary>
    public class PositiveValueAttribute : ValidationAttribute
    {
        /// <summary>
        /// Check value for valid.
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>Boolean represent the validate.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            
            return value is double d && d >= 0;
        }
    }
}