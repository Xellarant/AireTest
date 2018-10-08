using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AirespringBenefitsForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //  Private Methods //
        protected void refreshEmployeeTable(string searchTerm = null)
        {
            gvEmployees.DataSource = Models.Employee.GetEmployees(searchTerm);
            gvEmployees.DataBind();
        }

        // Events //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // so form submissions don't trigger this (only initial load or refresh)
            {
                refreshEmployeeTable();
            }
        }

        protected void btSubmitNewEmployee_Click(object sender, EventArgs e)
        {
            Models.Employee newEmployee = new Models.Employee
            {
                EmployeeID = Request.Form["tbEmployeeID"],
                FirstName = Request.Form["tbFirstName"],
                LastName = Request.Form["tbLastName"],
                PhoneNumber = Request.Form["tbPhoneNumber"],
                ZipCode = Request.Form["tbZipCode"],
                HireDate = DateTime.Parse(Request.Form["tbHireDate"])
            };
            Models.Employee.AddEmployee(newEmployee);
            refreshEmployeeTable();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = Request.Form["tbSearch"];
            refreshEmployeeTable(searchTerm);
        }
    }
}