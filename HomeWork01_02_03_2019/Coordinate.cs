using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Coordinate
    {
        private double latitude;
        private double longitude;

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (value >= -90 && value <= 90)
                    latitude = value;
                else
                    latitude = 0;
            }
        }
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (value >= -180 && value <= 180)
                    longitude = value;
                else
                    Longitude = 0;
            }
        }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }
    }
}
