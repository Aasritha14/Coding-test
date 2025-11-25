using C__New_Features_Coding_test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployeeDataReader dataReader = new MockEmployeeDataReader();
            var processor = new PayrollProcessor(dataReader);

            var employeeIdsToCheck = new[] { 101, 102, 103, 104, 105 };

            foreach (var id in employeeIdsToCheck)
            {
                try
                {
                    var total = processor.CalculateTotalCompensation(id);
                    Console.WriteLine($"Employee {id}: Total Compensation = {total:C}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Employee {id}: Error - {ex.Message}");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}



