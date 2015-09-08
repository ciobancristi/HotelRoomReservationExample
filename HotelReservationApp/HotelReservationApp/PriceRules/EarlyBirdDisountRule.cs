using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class EarlyBirdDisountRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room != null)
            {
                if (room.ReservationStartDate != null && room.NumberOfDays > 5)
                {
                    if (room.ReservationStartDate.AddMonths(-3) >= DateTime.Now)
                    {
                        return 50;
                    }
                }
            }

            return 0;
        }
    }
}
