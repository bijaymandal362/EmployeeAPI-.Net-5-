using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.Employee
{
  public  interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetEmployee();
    }
}
