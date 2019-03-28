using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    //[Serializable]
    public class WeatherInfo
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public string City { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is WeatherInfo weatherInfo))
                return false;

            return Math.Abs(Temperature - weatherInfo.Temperature) < 0.5 &&
                Math.Abs(Humidity - weatherInfo.Humidity) < 0.5 &&
                Math.Abs(Pressure - weatherInfo.Pressure) < 0.5;
        }

        public override string ToString()
        {
            return $"{City}: temperature {Temperature}, humidity {Humidity}, pressure {Pressure}";
        }
    }
}
