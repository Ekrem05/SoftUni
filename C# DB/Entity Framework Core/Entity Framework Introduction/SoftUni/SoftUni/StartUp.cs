using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetEmployeesFullInformation(new SoftUniContext()) ); 
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
                    e.HireDate
                }).ToList();

            StringBuilder sb = new();
            sb.Append(string.Join(Environment.NewLine, employees.Select(e => $"{e.FirstName} {e.MiddleName} {e.LastName} {e.Salary:f2} {e.HireDate}")));
            return sb.ToString();
        }
    }
}