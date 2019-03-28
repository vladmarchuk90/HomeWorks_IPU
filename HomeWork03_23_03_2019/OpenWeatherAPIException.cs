using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class OpenWeatherAPIException : Exception
    {
        public OpenWeatherAPIException(string message) 
            : base(message)
        {
            
        }

        public OpenWeatherAPIException(string message, Exception innerException) 
            : base(message, innerException)
        {

        }
    }
}
