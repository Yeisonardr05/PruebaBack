using Business.Constants;
using Cross.Employees;
using DataAccess.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Employees
{
    public class EmployeeBM
    {
        public List<EmployeeDTO> GetAll(string name)
        {
            EmployeeDM employeeDM = new EmployeeDM();
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            if (string.IsNullOrEmpty(name))
            {
                employees = employeeDM.GetAll();
            }
            else
            {
                employees = employeeDM.GetAll()
                    .Where(x => (x.Name.ToLower()).Contains(name.ToLower()))
                    .ToList();
            }

            foreach (var item in employees)
            {
                if (item.ContractTypeName == Constant.HOURLY_SALARY_EMPLOYEE)
                {
                    item.Salary = 120 * item.HourlySalary * 12;
                }
                else
                {
                    item.Salary = item.MonthlySalary * 12;
                }
            }

            return employees;
        }
    }
}
