﻿namespace BookingProject.Domain.Entities
{
    public class Pricing
    {
        public int PricingID { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public decimal PerHourRatePrice { get; set; }
        public decimal PerDayRatePrice { get; set; }
        public decimal PerMonthRatePrice { get; set; }
    }
}
