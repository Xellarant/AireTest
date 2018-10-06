using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AirespringBenefitsForm.Models
{
    public class Employee
    {
        static string con = ConfigurationManager.ConnectionStrings["salesbookSandbox"].ConnectionString;
        public string EmployeeID { get; set; } // assumed integer IDs. Can be changed.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; } // made a string in case of 10-digit postal code.
        public DateTime HireDate { get; set; }

        public static List<Employee> GetEmployees(string searchTerm = null)
        {
            List<Employee> resultSet = new List<Employee>();
            
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = $"EXEC erpEmployeeBenefitsGetAll '{searchTerm}'";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    myConnection.Open();
                    oCmd.ExecuteNonQuery();
                    SqlDataReader oReader = oCmd.ExecuteReader();                    
                        while (oReader.Read()) // while there's something in the result set...
                        {
                            resultSet.Add(new Employee
                            { // conversion and parse done under the assumption of strict sanitization.
                                EmployeeID = oReader["EmployeeID"].ToString(),
                                FirstName = oReader["EmployeeFirstName"].ToString(),
                                LastName = oReader["EmployeeLastName"].ToString(),
                                PhoneNumber = oReader["EmployeePhone"].ToString(),
                                ZipCode = oReader["EmployeeZip"].ToString(),
                                HireDate = DateTime.Parse(oReader["HireDate"].ToString())
                            });                            
                        } // end of results (nothing left to read).
                        myConnection.Close();                  
                } // end connection using block                
            }
            catch (Exception ex) // too many things could go wrong here tbh. TODO: add individual catches.
            {
                Console.Error.WriteLine("Panic!");
                Console.Error.WriteLine(ex);
            }

            return resultSet; // list is either done or empty. There ya go.
        } // end GetEmployees method
        public static void AddEmployee(Employee newEntry) // assuming each field has been pre-packaged into an object.
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = $"EXEC erpEmployeeInsert '{newEntry.EmployeeID}', '{newEntry.LastName}', '{newEntry.FirstName}', '{newEntry.PhoneNumber}', '{newEntry.ZipCode}', '{newEntry.HireDate}'";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.ExecuteNonQuery();
                    
                } // end SqlConnection using
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Panic!"); // TODO: write better error handling.
                Console.Error.WriteLine(ex);
            }
            
        } // TODO: add overloaded method for individual fields (maybe)
    } // end Employee Class
}