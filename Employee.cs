using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    public class Employee
    {

        //Properties
        public int EmpId {  get; set; }
        public string Name { get; set; }
        public string Department {  get; set; }
        public double Salary {  get; set; }
        public int Experience {  get; set; }

        //Constructor
        public Employee(int empId, string name, string department, double salary,int experience)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Salary = salary;
            Experience = experience;
        }

        //Override ToString for Display
        public override string ToString()
        {
            return $"ID : {EmpId}, Name : {Name}, Depart : {Department}, Salary : {Salary}, Exp : {Experience} yrs";
        }
    }
}
