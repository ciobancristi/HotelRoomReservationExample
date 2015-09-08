using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp.Interfaces
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(IRoom room);
    }
}
