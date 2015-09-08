using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class TwoPersonsPerRoomPriceRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room != null)
            {
                if (room.NumberOfPersons == 2)
                {
                    room.Price = 100;
                    return 100;
                }
            }

            return 0;
        }
    }
}
