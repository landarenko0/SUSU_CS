using System;

namespace lr3
{
    public class Program
    {
        static void Main()
        {
            ResidentalBuilding b1 = new ResidentalBuilding(FlatType.Economy, 120, "ул. Доватора, д. 4Д");
            NotResidentalBuilding b2 = new NotResidentalBuilding(FlatType.Economy, 200, "ул. Доватора, д. 4А");
            ResidentalBuilding b3 = new ResidentalBuilding(FlatType.Economy, 120, "ул. Доватора, д. 4В");
            NotResidentalBuilding b4 = new NotResidentalBuilding(FlatType.Business, 200, "ул. Доватора, д. 4Г");
            NotResidentalBuilding b5 = new NotResidentalBuilding(FlatType.Business, 1440, "ул. Доватора, д. 4Б");
            ManagementCompany company = new ManagementCompany();

            company.Add(b1);
            company.Add(b2);
            company.Add(b3);
            company.Add(b4);
            company.Add(b5);

            company.GetBuildingsInformation();
        }
    }
}