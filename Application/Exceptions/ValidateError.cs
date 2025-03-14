using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public sealed record ValidateError(
    string PropertyName,
    string ErrorMessage);
}