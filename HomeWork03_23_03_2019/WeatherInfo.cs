using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class WeatherInfo : IEquatable<WeatherInfo>
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public string City { get; set; }

        public bool Equals(WeatherInfo other)
        {
            if (other == null)
                return false;

            return Math.Abs(Temperature - other.Temperature) < 0.5 &&
                Math.Abs(Humidity - other.Humidity) < 0.5 &&
                Math.Abs(Pressure - other.Pressure) < 0.5;
        }

        public override string ToString()
        {
            return $"{City}: temperature {Temperature}, humidity {Humidity}, pressure {Pressure}";
        }
    }
}
