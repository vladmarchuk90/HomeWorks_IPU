using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class CPlane : CVehicle, ISeatingCapacity, IFly
    {
        private int seatingCapacity;
        private int height; // in meters above the ground

        public CPlane()
        {
            Height = 0;
            SeatingCapacity = 0;
        }

        public CPlane(double price, float speed, int yearOfProduction, Coordinate coordinate, 
            int seatingCapacity, int height)
            : base(price, speed, yearOfProduction, coordinate)
        {
            SeatingCapacity = seatingCapacity;
            Height = height;
        }

        public int SeatingCapacity
        {
            get { return seatingCapacity; }
            set { if (value >= 0) seatingCapacity = value; }
        }
        public int Height
        {
            get { return height; }
            set { if (value >= 0) height = value; }
        }

        public void Fly()
        {
            Console.WriteLine($"We're flying at the height {Height} with speed {Speed}"); ;
        }

        public override string ToString()
        {
            return $"CPlane \t({base.ToString()},\t seat. cap.: {SeatingCapacity},\t height: {Height})";
        }
    }
}
