using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace Observer
{
    public class OpenWeatherManager
    {
        public static OpenWeatherAPI.OpenWeatherAPI client;
        //Now it's just a catalog where would be files with names by city and stored info of last weather parameters
        private string databaseCatalog;  

        static OpenWeatherManager()
        {
            ClientInitialization();
        }

        public OpenWeatherManager()
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains("databaseCatalog"))
                DatabaseCatalog = ConfigurationManager.AppSettings["databaseCatalog"].ToString();
            else
                DatabaseCatalog = @"C:\weatherDatabase";
        }

        public string DatabaseCatalog
        {
            get
            {
                return databaseCatalog;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    databaseCatalog = value;
                }
                else
                {
                    databaseCatalog = Directory.CreateDirectory(@value).FullName; 
                }
            }
        }

        public WeatherInfo GetWeatherInfo(string city)
        {
            // using the third-party library that working with OpenWeather API "https://github.com/swiftyspiffy/OpenWeatherMap-API-CSharp"
            try
            {
                if(client == null)
                {
                    // can be some exception in static constructor or for example by time out
                    ClientInitialization();
                }

                var results = client.Query(city);

                WeatherInfo weatherInfo = new WeatherInfo
                {
                    Temperature = results.Main.Temperature.CelsiusCurrent,
                    Humidity = results.Main.Humdity,
                    Pressure = results.Main.Pressure,
                    City = city
                };

                return weatherInfo;
            }
            catch (Exception e)
            {
                throw new OpenWeatherAPIException("Can't get result at that time. See info in inner exception.", e);
            }
        }

        public bool WeatherInCityChanged(string city, WeatherInfo weatherInfo)
        {
            bool weatherIsChanged = true;
            string fileName = Path.Combine(DatabaseCatalog, city + ".xml");

            if (File.Exists(fileName))
            {
                XmlSerializer reader = new XmlSerializer(typeof(WeatherInfo));
                StreamReader streamReader = new StreamReader(fileName);
                WeatherInfo previousWeatherInfo = (WeatherInfo)reader.Deserialize(streamReader);
                streamReader.Close();

                if (weatherInfo.Equals(previousWeatherInfo))
                    weatherIsChanged = false;
            }

            XmlSerializer writer = new XmlSerializer(typeof(WeatherInfo));
            StreamWriter streamWriter = new StreamWriter(fileName);

            writer.Serialize(streamWriter, weatherInfo);
            streamWriter.Close();

            return weatherIsChanged;
        }

        private static void ClientInitialization()
        {
            string APIkey = ConfigurationManager.AppSettings["openWeatherAPIKey"].ToString();
            client = new OpenWeatherAPI.OpenWeatherAPI(APIkey);
        }
    }
}
