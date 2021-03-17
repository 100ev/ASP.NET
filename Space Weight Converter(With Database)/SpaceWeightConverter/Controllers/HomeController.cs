using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SpaceWeightConverter.Models;


namespace SpaceWeightConverter.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(Calculation calculator)
        {
            return View(calculator);
        }

        [HttpPost]
        public IActionResult Calculate(Calculation calculator)
        {
            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
            string connectionString = @"Data Source = USER-PC\SQLEXPRESS01; Initial Catalog = SpaceWeightConverterDb; Integrated Security = True";

            string queryString = "select Coefficient from DataFromCalculate where SpaceObject = @name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;
                command.Parameters.AddWithValue("@name", calculator.SpaceObjectName);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        calculator.CoefficientValue = (decimal)reader["Coefficient"];
                        calculator.CalculateResult();
                    }
                }
            }

            return RedirectToAction("Index", calculator);
        }
    }
}

