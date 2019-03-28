using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class WeatherData
    {
        private Dictionary<string, Action<WeatherInfo>> weathersByCities;

        public WeatherData()
        {
            weathersByCities = new Dictionary<string, Action<WeatherInfo>>();
        }

        public WeatherData(string city, Action<WeatherInfo> action) : this()
        {
            weathersByCities.Add(city, action);
        }

        // It's not the main way to subscribe\unsubscribe
        // Main methods: SubscribeOnTheWeatherInCity and UnsubscribeOnTheWeatherInCity
        public event Action<WeatherInfo> WeatherChanged
        {
            add
            {
                lock (weathersByCities)
                {
                    string cityByDefault = GetCityByDefault();
                    SubscribeOnTheWeatherInCity(cityByDefault, value);
                }
            }
            remove
            {
                lock (weathersByCities)
                {
                    string cityByDefault = GetCityByDefault();
                    UnsubscribeOnTheWeatherInCity(cityByDefault, value);
                }
            }
        }

        public void SubscribeOnTheWeatherInCity(string city, Action<WeatherInfo> action)
        {
            if (weathersByCities.ContainsKey(city))
            {
                weathersByCities[city] += action;
            }
            else
            {
                weathersByCities.Add(city, action);
            }
        }

        public void UnsubscribeOnTheWeatherInCity(string city, Action<WeatherInfo> action)
        {
            if (weathersByCities.ContainsKey(city))
            {
                weathersByCities[city] -= action;
            }
        }

        public void OnWeatherChanged(string city, WeatherInfo weatherInfo)
        {
            if (weathersByCities.ContainsKey(city))
            {
                weathersByCities[city].Invoke(weatherInfo);
            }
        }

        public void DoMeasurements()
        {
            foreach (var city in weathersByCities.Keys)
            {
                OpenWeatherManager weatherManager = new OpenWeatherManager();
                try
                {
                    WeatherInfo weatherInfo = weatherManager.GetWeatherInfo(city);
                    bool weatherInCityChanged = weatherManager.WeatherInCityChanged(city, weatherInfo);
                    if (weatherInCityChanged)
                        OnWeatherChanged(city, weatherInfo);

                }
                catch (OpenWeatherAPIException e)
                {
                    Console.WriteLine("Problem with connection or credentials. Try later or check your credentials more accurate!");
                    break;
                }
            }
        }

        private string GetCityByDefault()
        {
            return "Kyiv";
        }
    }
}
