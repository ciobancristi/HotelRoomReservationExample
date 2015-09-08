using HotelReservationApp.Interfaces;
using HotelReservationApp.PriceRules;
using HotelReservationApp.Refractored;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2020,12,12);
            
            List<IPriceRule> pricingRules = new List<IPriceRule>();
            pricingRules.Add(new OnePersonPerRoomPriceRule());
            pricingRules.Add(new TwoPersonsPerRoomPriceRule());
            pricingRules.Add(new TVAPriceRule());
            pricingRules.Add(new SeeSideRoomPriceRule());
            pricingRules.Add(new AirConditionedRoomPriceRule());
            pricingRules.Add(new BreakfastPriceRule());
            pricingRules.Add(new MoreThanTwoPersonsPerRoomPriceRule());

            List<IPriceRule> discountRules = new List<IPriceRule>();
            discountRules.Add(new EarlyBirdDisountRule());
            discountRules.Add(new LastMinuteDiscountRule());

            IPriceCalculator priceCalculator = new PriceCalculator(pricingRules,discountRules);
            IRoom room = new Room();
            room.NumberOfPersons = 2;
            room.NumberOfDays = 1 ;
            room.IsSeeSideRoom = true;
            room.NumberOfBreakfastsPerDay = 1;
            room.ReservationStartDate = date;
            room.HasAirConditioner = true;

            var price = priceCalculator.CalculatePrice(room);
            Console.WriteLine("The price for the room is: {0}.", price);
        }
    }
}
