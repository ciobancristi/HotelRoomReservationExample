using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class LastMinuteDiscountRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room != null)
            {
                if (room.ReservationStartDate != null && room.NumberOfDays > 4)
                {
                    if ((room.ReservationStartDate - DateTime.Now).Days > 4)
                    {
                        return 30;
                    }
                }
            }

            return 0;
        }
    }
}
