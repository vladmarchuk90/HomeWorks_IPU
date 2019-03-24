using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class CCar : CVehicle, IMove
    {
        public CCar()
        {
        }

        public CCar(double price, float speed, int yearOfProduction, Coordinate coordinate)
            : base(price, speed, yearOfProduction, coordinate)
        { 
        }

        public void Drive()
        {
            Console.WriteLine($"We're driving with speed {Speed}");
        }

        public override string ToString()
        {
            return $"CCar \t({base.ToString()})";
        }
    }
}
