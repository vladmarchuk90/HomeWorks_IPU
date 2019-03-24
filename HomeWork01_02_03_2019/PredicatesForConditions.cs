using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public static class PredicatesForConditions
    {
        static Func<CVehicle, bool> ConditionForCheckingVehicle;
        
        public static bool Predicate(CVehicle vehicle)
        {
            if (vehicle.YearOfProduction >= 2000 && vehicle.YearOfProduction <= 2005
                && vehicle.Speed >= 150)
                return true;
            else
                return false;
        }

    }
}
