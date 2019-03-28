using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentCondition currentCondition1 = new CurrentCondition();
            CurrentCondition currentCondition2 = new CurrentCondition();

            weatherData.SubscribeOnTheWeatherInCity("Kyiv", currentCondition1.Update);
            weatherData.SubscribeOnTheWeatherInCity("Lviv", currentCondition1.Update);
            weatherData.SubscribeOnTheWeatherInCity("Kyiv", currentCondition2.Update);
            weatherData.SubscribeOnTheWeatherInCity("Lutsk", currentCondition2.Update);
            weatherData.WeatherChanged += currentCondition1.Update;

            for (int i = 0; i < 5; i++)
            {
                weatherData.DoMeasurements();
                Thread.Sleep(10000);
            }

            Console.ReadLine();
        }
    }
}
