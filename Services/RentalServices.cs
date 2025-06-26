using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Entities;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    class RentalServices
    {
        public double PricePerHour { get;private set; }
        public double PricePerDay { get;private set; }

        private ITaxServices _taxService;

        public RentalServices(double pricePerHour, double pricePerDay, ITaxServices taxServices)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxServices;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = 0.0;
            if(duration.TotalHours <= 12)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }
            double tax = _taxService.Tax(basicPayment);
            carRental.Invoice = new Invoice(basicPayment, tax);
        }

    }
}
