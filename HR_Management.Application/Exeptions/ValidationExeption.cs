using FluentValidation.Results;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;

namespace HR_Management.Application.Exeptions
{
    public class ValidationExeption : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationExeption(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
