using System;
using System.Net;
using System.Text.RegularExpressions;

namespace lr4
{
    public class Program
    {
        public static void Main()
        {
            using (WebScan scan = new WebScan())
            {
                scan.AddressFound += (page, addresses) =>
                {
                    Console.WriteLine($"\nPage:\n\t{page}\nAddresses:");

                    foreach(var address in addresses)
                    {
                        Console.WriteLine($"\t{address}");
                    }
                };

                scan.PhoneNumberFound += (page, phoneNumbers) =>
                {
                    Console.WriteLine($"\nPage:\n\t{page}\nPhone numbers:");

                    foreach (var number in phoneNumbers)
                    {
                        Console.WriteLine($"\t{number}");
                    }
                };

                scan.Scan(new Uri("https://www.susu.ru/"), 15);
                Console.WriteLine("Done.");
            }
        }
    }
}