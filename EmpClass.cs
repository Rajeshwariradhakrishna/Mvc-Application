using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_Binding_Webgrid.Models
{
    public class EmpClass
    {
        public int EmployeeID { get; set; }
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public int EmployeeSalary { get; set; }

    }
}