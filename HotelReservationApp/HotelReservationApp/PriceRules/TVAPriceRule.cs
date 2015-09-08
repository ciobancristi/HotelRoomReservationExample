using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class TVAPriceRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room == null)
                throw new ArgumentNullException("room");

            if (room.Price > 0)
            {                
                return (decimal)(0.19) * room.Price;
            }

            return 0;
        }
    }
}
