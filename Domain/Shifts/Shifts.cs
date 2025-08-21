using Domain.Abstractions;

namespace Domain.Shifts
{
    public class Shifts : Entity
    {
        public Shifts()
        {

        }

        public Shifts(
            Guid id,
            Guid serviceId,
            DateTime shiftDate,
            TimeSpan startTime,
            TimeSpan endTime,
            bool state) : base(id)
        {
            ServiceId = serviceId;
            ShiftDate = shiftDate;
            StartTime = startTime;
            EndTime = endTime;
            State = state;
        }
      
        /// <summary>
        /// Id del servicio
        /// </summary>
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Fecha del turno
        /// </summary>
        public DateTime ShiftDate { get; set; }
        /// <summary>
        /// Hora de inicio del turno
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// Hora de fin del turno
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// Estado del turno
        /// </summary>
        public bool State { get; set; }

    }
}