using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.Salary
{
    public interface ISalaryService
    {
        Task<IEnumerable<SalaryViewModel>> GetSalary();
    }
}
