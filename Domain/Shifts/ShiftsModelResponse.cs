using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Shifts
{
    public class ShiftsModelResponse
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool State { get; set; }
    }
}