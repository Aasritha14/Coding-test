using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__New_Features_Coding_test
{

    public class EmployeeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } 
        public bool IsVeteran { get; set; }
    }

    // 2) DI interface
    public interface IEmployeeDataReader
    {
        EmployeeRecord GetEmployeeRecord(int employeeId);
    }

    // 2b) Mock reader
    public class MockEmployeeDataReader : IEmployeeDataReader
    {

        public EmployeeRecord GetEmployeeRecord(int employeeId)
        {
           
            switch (employeeId)
            {
                case 101:
                    return new EmployeeRecord { Id = 101, Name = "Aasritha", Role = "Manager", IsVeteran = true };
                case 102:
                    return new EmployeeRecord { Id = 102, Name = "Jungkook", Role = "Manager", IsVeteran = false };
                case 103:
                    return new EmployeeRecord { Id = 103, Name = "Deepti", Role = "Developer", IsVeteran = false };
                case 104:
                    return new EmployeeRecord { Id = 104, Name = "Pujitha", Role = "Intern", IsVeteran = false };
                case 105:
                    return new EmployeeRecord { Id = 105, Name = "Anvitha", Role = "Analyst", IsVeteran = false };
                default:
                    throw new ArgumentException($"Employee with id {employeeId} was not found.");
            }
        }
    }

    // 3) Processor (Dictionary + Pattern Matching)
    public class PayrollProcessor
    {
        private readonly IEmployeeDataReader _dataReader;

        private static readonly IReadOnlyDictionary<int, decimal> BaseSalaries =
            new Dictionary<int, decimal>
            {
                { 101, 65000m },
                { 102, 60000m },
                { 103, 55000m },
                { 104, 30000m },
               
            };

        public PayrollProcessor(IEmployeeDataReader dataReader)
        {
            _dataReader = dataReader ?? throw new ArgumentNullException(nameof(dataReader));
        }

        public decimal CalculateTotalCompensation(int employeeId)
        {
            var employee = _dataReader.GetEmployeeRecord(employeeId);

            if (!BaseSalaries.TryGetValue(employee.Id, out var baseSalary))
                throw new ArgumentException($"Base salary not found for employee {employee.Id}.");


            decimal bonus;
            if (employee.Role == "Manager" && employee.IsVeteran)
                bonus = 10_000m;
            else if (employee.Role == "Manager" && !employee.IsVeteran)
                bonus = 5_000m;
            else if (employee.Role == "Developer")
                bonus = 2_000m;
            else if (employee.Role == "Intern")
                bonus = 500m;
            else
                bonus = 0m;


            return baseSalary + bonus;
        }
    }

}