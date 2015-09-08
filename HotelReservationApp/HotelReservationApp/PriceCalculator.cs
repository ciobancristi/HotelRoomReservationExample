using HotelReservationApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationApp
{
    public class PriceCalculator : IPriceCalculator
    {
        public List<IPriceRule> PricingRules {get;set;}
        public List<IPriceRule> DiscountRules { get; set; }

        public PriceCalculator(List<IPriceRule> pricingRules, List<IPriceRule> discountRules){

            this.PricingRules = pricingRules;
            this.DiscountRules = discountRules;
        
        }

        public decimal CalculatePrice(IRoom room)
        {
            decimal price = 0;

            if (PricingRules != null)
            {
                foreach (var priceRule in PricingRules)
                {
                    price += priceRule.CalculatePrice(room);
                }
            }

            if (DiscountRules != null)
            {
                foreach (var discountRule in DiscountRules)
                {
                    price -= discountRule.CalculatePrice(room);
                }
            }
            

            return price;
        }
    }
}
