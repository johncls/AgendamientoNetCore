using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public record ServiceResponse(
        Guid Id,
        string NameService,
        TimeSpan OpeningHour,
        TimeSpan ClosingHour,
        int Duration
    );
}