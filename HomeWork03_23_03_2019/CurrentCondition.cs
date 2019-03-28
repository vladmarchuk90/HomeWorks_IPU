using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class CurrentCondition : IObserver
    {
        public void Update(WeatherInfo weatherInfo)
        {
            Console.WriteLine($"Current conditions in the city {weatherInfo.ToString()}");
        }
    }
}
