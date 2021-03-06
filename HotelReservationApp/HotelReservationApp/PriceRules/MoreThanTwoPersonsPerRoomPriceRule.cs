﻿using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.PriceRules
{
    public class MoreThanTwoPersonsPerRoomPriceRule : IPriceRule
    {
        public decimal CalculatePrice(IRoom room)
        {
            if (room != null)
            {
                if (room.NumberOfPersons > 2)
                {
                    room.Price = 100 + 20 * (room.NumberOfPersons - 2);
                    return 100 + 20 * (room.NumberOfPersons - 2);
                }
            }

            return 0;
        }
    }
}
