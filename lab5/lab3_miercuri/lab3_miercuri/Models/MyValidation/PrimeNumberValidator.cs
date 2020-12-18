using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab3_miercuri.Models
{
    public class PrimeNumberValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var book = (Book)validationContext.ObjectInstance;
            int pages = book.NoOfPages;
            bool cond = true;

            for (int i = 2; i <= Math.Sqrt(pages); i++)
            {
                if (pages % i == 0)
                {
                    cond = false;
                    break;
                }
            }
            return cond ? ValidationResult.Success : new ValidationResult("This is not a prime number!");
        }
    }
}