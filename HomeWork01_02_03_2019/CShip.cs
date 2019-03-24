using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class CShip : CVehicle, ISeatingCapacity, ISwim
    {
        private int seatingCapacity;

        public CShip()
        {
            HomePort = null;
            SeatingCapacity = 0;
        }

        public CShip(double price, float speed, int yearOfProduction, Coordinate coordinate,
            int seatingCapacity, string homePort)
            : base(price, speed, yearOfProduction, coordinate)
        {
            SeatingCapacity = seatingCapacity;
            HomePort = homePort;
        }

        public int SeatingCapacity
        {
            get { return seatingCapacity; }
            set { if (value >= 0) seatingCapacity = value; }
        }
        public string HomePort { get; set; }

        public void Swim()
        {
            Console.WriteLine($"We're swimming with speed {Speed}");
        }

        public override string ToString()
        {
            return $"CShip \t({base.ToString()},\t seat. cap.: {SeatingCapacity},\t home port: {HomePort})";
        }
    }
}
