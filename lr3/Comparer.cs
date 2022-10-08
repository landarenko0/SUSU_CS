using System;

namespace lr3
{
    internal class Comparer : IComparer<Building>
    {
        public int Compare(Building x, Building y)
        {
            if (x.Average != y.Average) 
            {
                //return x.Average.CompareTo(y.Average);
                if (x.Average < y.Average)
                {
                    return 1;
                }
                
                return -1;
            }
            else if (x.BuildingType != y.BuildingType)
            {
                return x.BuildingType.CompareTo(y.BuildingType);
            }

            return x._address.CompareTo(y._address);
        }
    }
}
