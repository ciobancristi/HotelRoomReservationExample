using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class BreakfastPriceRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room != null)
            {
                if (room.NumberOfBreakfastsPerDay > 0)
                {
                    return room.NumberOfBreakfastsPerDay * 10;
                }
            }

            return 0;
        }
    }
}
