using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoGUI_Preferences
{
    enum TripType
    {
        Tourist,
        Naturalistic
    }
    enum SortingPrice
    {
        Ascending,
        Descending
    }
    class Preferences
    {
        public DateTime arrivalDate;
        public DateTime departureDate;
        public int? NumberOfAdults;
        public int NumberOfChildren;
        public List<Localization> localization = new List<Localization>();
        public List<BookingWebsite> website = new List<BookingWebsite>();
        public DateTime ArrivalDate
        {
            get => arrivalDate; set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Date cannot be in the past");
                }
                if (value > DepartureDate)
                {
                    throw new ArgumentException("Date of departure cannot be before the date of arrival");
                }
                arrivalDate = value;
            }
        }
        public DateTime DepartureDate
        {
            get => departureDate; set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Date cannot be in the past");
                }
                if (value < ArrivalDate)
                {
                    throw new ArgumentException("Date of departure cannot be before the date of arrival");
                }
                departureDate = value;
            }
        }

        public int? NumberOfAdults1
        {
            get => NumberOfAdults; set
            {
                if (value == null || value == 0)
                {
                    throw new ArgumentException("This value cannot be empty");
                }
                if (value < 0)
                {
                    throw new ArgumentException("This value cannot be negative");
                }
                if (value > 5)
                {
                    throw new ArgumentException("This number is too large, please select lower number");
                }
                NumberOfAdults = value;
            }
        }
        public int NumberOfChildren1
        {
            get => NumberOfChildren; set
            {
                if (value < 0)
                {
                    throw new ArgumentException("This value cannot be negative");
                }
                if (value > 5)
                {
                    throw new ArgumentException("This number is too large, please select lower number");
                }
                NumberOfChildren = value;
            }
        }

        public List<Localization> Localization { get => localization; set => localization = value; }
        internal List<BookingWebsite> Website { get => website; set => website = value; }
    }
}
