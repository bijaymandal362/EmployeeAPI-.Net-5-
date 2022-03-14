using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeAttendance
{
    public interface IEmployeeAttendanceService
    {
        Task InsertEmployeeAttendance(EmployeeAttendanceViewModel employeeAttendanceViewModel);
        Task<IEnumerable<EmployeeAttendanceViewModel>> GetEmployeeAttendance();

    }
}
