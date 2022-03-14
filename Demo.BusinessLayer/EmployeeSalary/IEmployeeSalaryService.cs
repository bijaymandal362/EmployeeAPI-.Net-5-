using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeSalary
{
    public interface IEmployeeSalaryService
    {
        Task<IEnumerable<EmployeeSalaryViewModel>> GetEmployeeSalary(DateTime endDate);
        DateTime CalculateStartDay(DateTime endDate);
        Task<IEnumerable<EmployeeSalaryViewModel>> GetEmployeeSalaryList();
    }
}
