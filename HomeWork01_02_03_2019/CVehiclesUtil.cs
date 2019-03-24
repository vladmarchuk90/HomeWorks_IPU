using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public static class CVehiclesUtil
    {
        public static CVehicle GetTheHighestPrice(List<CVehicle> vehiclesList)
        {
            CVehicle vehicle = (from veh in vehiclesList
                                orderby veh.Price descending
                                select veh).ToList().First();

            return vehicle;
        }

        public static CVehicle GetTheLowestPrice(List<CVehicle> vehiclesList)
        {
            CVehicle vehicle = (from veh in vehiclesList
                                orderby veh.Price ascending
                                select veh).ToList().First();

            return vehicle;
        }

        public static CVehicle GetTheNewest(List<CVehicle> vehiclesList)
        {
            CVehicle vehicle = (from veh in vehiclesList
                                orderby veh.YearOfProduction descending
                                select veh).ToList().First();

            return vehicle;
        }

        public static CVehicle GetTheOldest(List<CVehicle> vehiclesList)
        {
            CVehicle vehicle = (from veh in vehiclesList
                                orderby veh.YearOfProduction ascending
                                select veh).ToList().First();

            return vehicle;
        }

        public static CVehicle GetTheFastest(List<CVehicle> vehiclesList)
        {
            CVehicle vehicle = (from veh in vehiclesList
                                orderby veh.Speed descending
                                select veh).ToList().First();

            return vehicle;
        }

        public static CVehicle GetTheSlowest(List<CVehicle> vehiclesList)
        {
            CVehicle vehicle = (from veh in vehiclesList
                                orderby veh.Speed ascending
                                select veh).ToList().First();

            return vehicle;
        }

        public static List<CVehicle> GetAllInNorthernHemisphere(List<CVehicle> vehiclesList)
        {
            List<CVehicle> vehicles = (from veh in vehiclesList
                                       where veh.Coordinate.Latitude > 0
                                       orderby veh.Speed descending
                                       select veh).ToList();

            return vehicles;
        }

        public static List<CVehicle> GetAllInSouthernHemisphere(List<CVehicle> vehiclesList)
        {
            List<CVehicle> vehicles = (from veh in vehiclesList
                                       where veh.Coordinate.Latitude < 0
                                       select veh).ToList();

            return vehicles;
        }

        public static List<CVehicle> GetAllInWesternHemisphere(List<CVehicle> vehiclesList)
        {
            List<CVehicle> vehicles = (from veh in vehiclesList
                                       where veh.Coordinate.Longitude < 0
                                       select veh).ToList();

            return vehicles;
        }

        public static List<CVehicle> GetAllInEasternHemisphere(List<CVehicle> vehiclesList)
        {
            List<CVehicle> vehicles = (from veh in vehiclesList
                                       where veh.Coordinate.Longitude > 0
                                       select veh).ToList();

            return vehicles;
        }

        public static List<CVehicle> GetAllAtEquator(List<CVehicle> vehiclesList)
        {
            List<CVehicle> vehicles = (from veh in vehiclesList
                                       where veh.Coordinate.Latitude == 0
                                       select veh).ToList();

            return vehicles;
        }

        public static List<CVehicle> GetAllAtPrimeMeridian(List<CVehicle> vehiclesList)
        {
            List<CVehicle> vehicles = (from veh in vehiclesList
                                       where veh.Coordinate.Longitude == 0
                                       select veh).ToList();

            return vehicles;
        }

        // Interface ISeatingCapacity
        public static ISeatingCapacity GetTheBiggestSeatingCapacity(List<ISeatingCapacity> vehiclesList)
        {
            ISeatingCapacity vehicle = (from veh in vehiclesList
                                        orderby veh.SeatingCapacity descending
                                        select veh).ToList().First();

            return vehicle;
        }

        public static ISeatingCapacity GetTheSmallestSeatingCapacity(List<ISeatingCapacity> vehiclesList)
        {
            ISeatingCapacity vehicle = (from veh in vehiclesList
                                        orderby veh.SeatingCapacity ascending
                                        select veh).ToList().First();

            return vehicle;
        }

        public static ISeatingCapacity GetTheBiggestSeatingCapacityAmongPlane(List<ISeatingCapacity> vehiclesList)
        {
            ISeatingCapacity vehicle = (from veh in vehiclesList
                                        where veh.GetType() == typeof(CPlane)
                                        orderby veh.SeatingCapacity descending
                                        select veh).ToList().First();

            return vehicle;
        }

        public static List<CVehicle> GetAllAtAnyCondition(List<CVehicle> vehiclesList, Func<CVehicle, bool> predicate)
        {
            //List<CVehicle> vehicles = (from veh in vehiclesList
            //                           where veh.Coordinate.Longitude == 0
            //                           select veh).ToList();

            List<CVehicle> vehicles = vehiclesList.Where(predicate).OrderBy(v=>v.Price).ToList<CVehicle>();

            return vehicles;
        }
    }
}
