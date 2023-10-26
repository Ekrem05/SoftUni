using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetEmployeesWithSalaryOver50000(new SoftUniContext()) ); 
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
           var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.Salary,
                    e.JobTitle
                }).ToList();

            StringBuilder sb = new();
            sb.Append(string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")));
            return sb.ToString();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                }).Where(e=>e.Salary>50000).OrderBy(e=>e.FirstName).ToList();
            StringBuilder sb = new();
            sb.Append(string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} - {e.Salary:f2}")));
            return sb.ToString();
        }
    }
}