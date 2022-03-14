using Demo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeCheckOut
{
    public interface IEmployeeCheckOutService
    {
        Task CheckOut(int employeeId);
        Task<IEnumerable<EmployeeCheckOutViewModel>> GetEmployeeCheckOut();
    }
}
