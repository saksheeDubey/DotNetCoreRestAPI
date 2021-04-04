using RESTAPICRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPICRUD.EmployeeData
{
  public  interface IEmployeeData
    {
        List<Employees> GetEmployees();

        Employees GetEmployee(Guid empid);

        Employees AddEmployee(Employees employee);

        void deleteEmployee(Employees employee);

        Employees EditEmployee(Employees employee);
    }
}
