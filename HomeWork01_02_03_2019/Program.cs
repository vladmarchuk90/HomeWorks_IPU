using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CVehicle> vehiclesList = GetTestDataForCheckingCommonProperties();
            List<ISeatingCapacity> seatingCapacities = GetTestDataForCheckingSeatingCapacity();

            Console.WriteLine("We have the next list of vehicles (3 Plane, 3 CShip, 3, CCar) below:");
            Console.WriteLine(new string('-', 50));
            foreach (var veh in vehiclesList)
            {
                Console.WriteLine(veh);
            }

            string textOfVariants =
        @"You can choose the next filters:
            1.  Get the highest price
            2.  Get the lowest price
            3.  Get the newest one
            4.  Get the oldest one
            5.  Get the fastest one
            6.  Get the slowest one
            7.  Get all in Northern hemisphere
            8.  Get all in Southern hemisphere
            9.  Get all in Western hemisphere
            10. Get all in Eastern hemisphere
            11. Get all at Equator
            12. Get all at Prime Meridian
            13. Get the biggest seating capacity
            14. Get the smallest seating capacity
            15. Get the biggest seating capacity among plane
            16. Get the vehicle by any condition
        If you gonna leave press button 'q'";

            CVehicle vehicle = null;
            List<CVehicle> vehicles = null;
            ISeatingCapacity seatingCapacity = null;
            string answer = null;
            char firstLetter;

            do
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(textOfVariants);
                Console.Write("Answer:\t");

                answer = Console.ReadLine();
                firstLetter = answer.ToUpper().First();

                //int option;
                int.TryParse(answer, out int option);

                if (option > 0 && option <= 16)
                {
                    switch (option)
                    {
                        case 1:
                            vehicle = CVehiclesUtil.GetTheHighestPrice(vehiclesList);
                            break;
                        case 2:
                            vehicle = CVehiclesUtil.GetTheLowestPrice(vehiclesList);
                            break;
                        case 3:
                            vehicle = CVehiclesUtil.GetTheNewest(vehiclesList);
                            break;
                        case 4:
                            vehicle = CVehiclesUtil.GetTheOldest(vehiclesList);
                            break;
                        case 5:
                            vehicle = CVehiclesUtil.GetTheFastest(vehiclesList);
                            break;
                        case 6:
                            vehicle = CVehiclesUtil.GetTheSlowest(vehiclesList);
                            break;
                        case 7:
                            vehicles = CVehiclesUtil.GetAllInNorthernHemisphere(vehiclesList);
                            break;
                        case 8:
                            vehicles = CVehiclesUtil.GetAllInSouthernHemisphere(vehiclesList);
                            break;
                        case 9:
                            vehicles = CVehiclesUtil.GetAllInWesternHemisphere(vehiclesList);
                            break;
                        case 10:
                            vehicles = CVehiclesUtil.GetAllInEasternHemisphere(vehiclesList);
                            break;
                        case 11:
                            vehicles = CVehiclesUtil.GetAllAtEquator(vehiclesList);
                            break;
                        case 12:
                            vehicles = CVehiclesUtil.GetAllAtPrimeMeridian(vehiclesList);
                            break;
                        case 13:
                            seatingCapacity = CVehiclesUtil.GetTheBiggestSeatingCapacity(seatingCapacities);
                            break;
                        case 14:
                            seatingCapacity = CVehiclesUtil.GetTheSmallestSeatingCapacity(seatingCapacities);
                            break;
                        case 15:
                            seatingCapacity = CVehiclesUtil.GetTheBiggestSeatingCapacityAmongPlane(seatingCapacities);
                            break;
                        case 16:
                            vehicles = CVehiclesUtil.GetAllAtAnyCondition(vehiclesList, PredicatesForConditions.Predicate);
                            break;
                    }

                    Console.WriteLine("Result:");

                    if (vehicle == null && vehicles == null && seatingCapacity == null)
                    {
                        Console.WriteLine("We've found nothing!");
                    }
                    else
                    { 
                        if (vehicle != null)
                        {
                            Console.WriteLine(vehicle);
                            vehicle = null;
                        }
                        if (vehicles != null)   //list of vehicles
                        {

                            foreach (var veh in vehicles)
                            {
                                Console.WriteLine(veh);
                            }
                            vehicles = null;
                        }
                        if (seatingCapacity != null)
                        {
                            Console.WriteLine(seatingCapacity);
                            seatingCapacity = null;
                        }
                    }
                }
                else if (firstLetter != 'Q')
                {
                    Console.WriteLine("This option is unavailable. Try again with choosing from list.");
                }
            }while (firstLetter != 'Q');
        }

        static List<CVehicle> GetTestDataForCheckingCommonProperties()
        {
            List<CVehicle> vehiclesList = new List<CVehicle>
            {
                new CPlane(20000, 230, 1999, null, 160, 8500),                          //new Coordinate(10.98, 34.56)
                new CPlane(80100, 330, 2007, new Coordinate(238.98, 54.72), 182, 12000),
                new CPlane(250000, 370, 2016, new Coordinate(-36.98, 84.56), 220, 12000),

                new CShip(300000, 65, 1989, new Coordinate(17.36, -78.56), 382, "Amsterdam"),
                new CShip(400000, 80, 2010, new Coordinate(45.24, 48.73), 2000, "Hamburg"),
                new CShip(350000, 72, 2007, new Coordinate(26.94, -62.95), 1800, "Dunkirk"),

                new CCar(28000, 220, 2001, new Coordinate(26.78, -120.71)),
                new CCar(45000, 250, 2015, new Coordinate(45.32, 128.71)),
                new CCar(28000, 220, 2001, new Coordinate(26.78, 34.67))
            };

            return vehiclesList;
        }

        static List<ISeatingCapacity> GetTestDataForCheckingSeatingCapacity()
        {
            List<ISeatingCapacity> vehiclesList = new List<ISeatingCapacity>
            {
                new CPlane(20000, 230, 1999, new Coordinate(10.98, 34.56), 160, 8500),                          
                new CPlane(80100, 330, 2007, new Coordinate(238.98, 54.72), 182, 12000),
                new CPlane(250000, 370, 2016, new Coordinate(-36.98, 84.56), 220, 12000),

                new CShip(300000, 65, 1989, new Coordinate(17.36, -78.56), 382, "Amsterdam"),
                new CShip(400000, 80, 2010, new Coordinate(45.24, 48.73), 2000, "Hamburg"),
                new CShip(350000, 72, 2007, new Coordinate(26.94, -62.95), 1800, "Dunkirk")
            };

            return vehiclesList;
        }
    }
}
