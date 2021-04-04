using RESTAPICRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RESTAPICRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employees> empdata = new List<Employees>()
       {
           new Employees
           {
               empid = Guid.NewGuid(),
               empname= "Employee one"

           },
           new Employees
           {
               empid = Guid.NewGuid(),
               empname= "Employee Two"

           }

       };
        
        public Employees AddEmployee(Employees employee)
        {
            employee.empid  = Guid.NewGuid();
            empdata.Add(employee);
            return employee;
        }

        public void deleteEmployee(Employees employee)
        {
            empdata.Remove(employee);
        }

        public Employees EditEmployee(Employees employee)
        {
            var existingemployee = GetEmployee(employee.empid);
            existingemployee.empname = employee.empname;
            return employee;
        }

        public List<Employees> GetEmployees()
        {
            return empdata;
        }

        public Employees GetEmployee(Guid empid)
        {
            return empdata.SingleOrDefault(x => x.empid == empid);
        }
    }
}
