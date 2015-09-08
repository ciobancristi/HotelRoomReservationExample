using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.Interfaces
{
    public interface IRoom
    {
        decimal Price { get; set; }
        int NumberOfPersons { get; set; }
        decimal TVA { get; set; }
        bool HasAirConditioner { get; set; }
        bool IsSeeSideRoom { get; set; }
        int NumberOfDays { get; set; }
        DateTime ReservationStartDate { get; set; }
        int NumberOfBreakfastsPerDay { get; set; }
    }
}
