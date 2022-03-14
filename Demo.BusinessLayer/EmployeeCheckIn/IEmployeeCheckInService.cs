using Demo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeCheckIn
{
    public interface IEmployeeCheckInService
    {
        Task CheckIn(int employeeId);
        Task<IEnumerable<EmployeeCheckInViewModel>> GetEmployeeCheckIn();
    }
}
