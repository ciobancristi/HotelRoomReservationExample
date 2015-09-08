using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.Refractored
{
    public class Room : IRoom
    {
        public decimal Price { get; set; }
        public int NumberOfPersons { get; set; }
        public decimal TVA { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool IsSeeSideRoom { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public int NumberOfBreakfastsPerDay { get; set; }
    }
}
