using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidateError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidateError> Errors { get; private set; }

        public string ErrorMessages => string.Join(", ", Errors.Select(e => e.ErrorMessage));
    }
}