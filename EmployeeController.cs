using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using MVC_Binding_Webgrid.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC_Binding_Webgrid.Controllers
{
    public class EmployeeController : Controller
    {
        string conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: Employee
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                sqlconn.Open();
                string sqlQuery = " select * from Employee";
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, sqlconn);
                da.Fill(dt);
                return View(dt);
            }
        }

        public ActionResult Create()
        {

            return View(new EmpClass());
        }

        [HttpPost]
        public ActionResult Create(EmpClass empclass)
        {
            using (SqlConnection sqlconn = new SqlConnection(conn))
            {
                sqlconn.Open();
                string sqlQuery = "Insert into Employee values(@EmployeeID, @EmployeeName, @EmployeeAge, @EmployeeSalary)";
                SqlCommand sqlcmd = new SqlCommand(sqlQuery, sqlconn);
                sqlcmd.Parameters.Add(new SqlParameter() { ParameterName = "@EmployeeID", Value = empclass.EmployeeID });
                sqlcmd.Parameters.Add(new SqlParameter() { ParameterName = "@EmployeeName", Value = empclass.EmployeeName });
                sqlcmd.Parameters.Add(new SqlParameter() { ParameterName = "@EmployeeAge", Value = empclass.EmployeeAge});
                sqlcmd.Parameters.Add(new SqlParameter() { ParameterName = "@EmployeeSalary", Value = empclass.EmployeeSalary });
                sqlcmd.ExecuteNonQuery();
               // sqlcmd.Parameters.AddWithValue(@EmployeeID, empclass.EmployeeID);
            }
            return RedirectToAction("Index");
        }

    }
}