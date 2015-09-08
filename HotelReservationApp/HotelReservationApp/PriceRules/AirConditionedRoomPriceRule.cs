using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class AirConditionedRoomPriceRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room != null) {
                if (room.HasAirConditioner)
                {
                    return 3;
                }
            }

            return 0;
        }
    }
}
