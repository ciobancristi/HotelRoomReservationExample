using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class OnePersonPerRoomPriceRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room != null)
            {
                if (room.NumberOfPersons == 1)
                {
                    room.Price = 60;
                    return 60;
                }
            }
            return 0;
        }
    }
}
