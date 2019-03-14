using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    abstract public class CVehicle
    {
        private double price;
        private float speed;
        private int yearOfProduction;
        private Coordinate coordinate;

        public CVehicle()
        {
            Price = 0;
            Speed = 0;
            YearOfProduction = 2000;
            Coordinate = null;
        }

        public CVehicle(double price, float speed, int yearOfProduction, Coordinate coordinate)
        {
            Price = price;
            Speed = speed;
            YearOfProduction = yearOfProduction;
            Coordinate = coordinate;
        }

        public double Price
        {
            get { return price; }
            set { if (value >= 0) price = value; }
        }
        public float Speed
        {
            get { return speed; }
            set { if (value >= 0) speed = value; }
        }
        public int YearOfProduction
        {
            get { return yearOfProduction; }
            set { if (value >= 1900 && value <= DateTime.Now.Year) yearOfProduction = value; }
        }

        public Coordinate Coordinate
        {
            get
            {
                if (coordinate == null)
                    coordinate = new Coordinate(0, 0);
                return coordinate;
            }
            set { coordinate = value; }
        }

        public override string ToString()
        {
            return $"price: {Price},\t speed: {Speed},\t year of prod.: {YearOfProduction},\t coord.: {Coordinate}";
        }
    }
}
