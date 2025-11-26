using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create List<Employee>
            List<Employee> employeesList = new List<Employee>
            {
                new Employee(208, "Aasritha", "IT", 50000, 5 ),
                new Employee(307, "Jungkook", "HR", 45000, 4 ),
                new Employee(267, "Ram", "Finance", 55000, 7),
                new Employee(345, "Deepti Sahu", "Sales", 40000, 3),
                new Employee(786, " Geetha", "IT", 70000, 8),
                new Employee(564, "Kajal", "HR", 48000, 5),
                new Employee(234, "Nagamani", "Finance", 52000, 6),
                new Employee(543, "Anvitha", "Sales", 35000, 2),
                new Employee(765, "Ramakrishna", "IT", 65000, 9),
                new Employee(999, "Pujitha", "Finance", 50000, 4),
            };

            Console.WriteLine("=== All Employees ===");
            employeesList.ForEach(e => Console.WriteLine(e));

            //Filtering using Lambda
            var highSalary = employeesList.Where(e => e.Salary > 50000).ToList();
            var itDept = employeesList.Where(e => e.Department == "IT").ToList();
            var experienced = employeesList.Where(e => e.Experience > 5).ToList();
            var nameStartsWithA = employeesList.Where(e => e.Name.StartsWith("A")).ToList();

            Console.WriteLine("\n=== Salary > 50,000 ===");
            highSalary.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n=== IT Department ===");
            itDept.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n=== Experienece > 5 years === ");
            experienced.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n== Name starts with A ===");
            nameStartsWithA.ForEach(e => Console.WriteLine(e));

            //Sorting using Lambda
            var sortByname = employeesList.OrderBy(e => e.Name).ToList();
            var sortBySalaryDesc = employeesList.OrderByDescending(e => e.Salary).ToList();
            var sortByExperienceAsc = employeesList.OrderBy(e =>e.Experience).ToList();

            Console.WriteLine("\n=== Sort by Name (A - Z) ===");
            sortByname.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n=== Sort by Salary (High - Low) ===");
            sortBySalaryDesc.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n=== Sort by Experience (Low - High) ===");
            sortByExperienceAsc.ForEach(e => Console.WriteLine(e));

            //Promotion List(Example: Experience > 5 years)
            Console.WriteLine("\n=== Promotion List (Experience > 5 years) ===");
            experienced.ForEach(e => Console.WriteLine(e));
        }
    }
}
