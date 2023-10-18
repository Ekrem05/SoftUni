using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SqlConnection con =
                new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MinionsDB;");
            using (con)
            {
                con.Open();
                string querry = "Select [Name], Count(*)as Count from Villains as v Join MinionsVillains as mv ON mv.VillainId=v.Id Group By [Name] HAVING Count(*)>3 Order By Count(*) desc";
                SqlCommand command = new SqlCommand(querry,con);
                SqlDataReader dataReader = command.ExecuteReader();
                while ( dataReader.Read())
                {
                    Console.WriteLine(dataReader[0].ToString() +" - "+ dataReader[1].ToString());
                }
            }
        }
    }
}
