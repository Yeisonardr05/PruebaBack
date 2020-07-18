using Cross.Employees;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataAccess.Employees
{
    public class EmployeeDM
    {
        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString("http://masglobaltestapi.azurewebsites.net/api/employees");
                employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(json);
            }
            return employees;
        }

    }
}
