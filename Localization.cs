using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGUI_Preferences
{
    class Localization
    {
        public string city;
        public string country;

        public Localization(string city, string country)
        {
            this.city = city;
            this.country = country;
        }

        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }

        public override string ToString()
        {
            return $"{City}, {Country}";
        }
    }
}
