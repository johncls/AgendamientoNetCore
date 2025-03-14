using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Clients
{
    public class CreatedClientCommandValidator : AbstractValidator<CreatedClientCommand>
    {
        public CreatedClientCommandValidator()
        {
            RuleFor(c => c.email).NotEmpty();
            RuleFor(c => c.name).NotEmpty();
            RuleFor(c => c.phone).NotEmpty();
            RuleFor(c => c.lastName).NotEmpty();
        }
    }
}