using Demo.Entities.Data;
using Demo.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeCheckIn
{
    public class EmployeeCheckInService : IEmployeeCheckInService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeCheckInService(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task CheckIn( int employeeId)
        {
            try
            {
               
                var employeId =await _context.Employee.FirstOrDefaultAsync(a=>a.EmployeeId==employeeId);
                if (employeId != null)
                {
                  
                    Demo.Entities.Model.EmployeeCheckIn employeeCheckIn = new Entities.Model.EmployeeCheckIn();
                    employeeCheckIn.EmployeeId = employeId.EmployeeId;
                    employeeCheckIn.Date = DateTime.Now.Date.ToShortDateString();
                    employeeCheckIn.CheckIn =( DateTime.Now.ToString("h:mm:ss tt")); 
                    employeeCheckIn.Day = DateTime.Now.DayOfWeek.ToString();
                    await _context.AddAsync(employeeCheckIn);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("You are not allow to login!!Please contact Hr or TeamLead");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public async Task<IEnumerable<EmployeeCheckInViewModel>> GetEmployeeCheckIn()
        {
            try
            {
                var list = await (from e in _context.EmployeeCheckIn
                                  select new EmployeeCheckInViewModel
                                  {
                                      EmployeeId = e.EmployeeId,
                                      Date=e.Date,
                                      Day =e.Day,
                                      CheckIn = e.CheckIn
                                  }).ToListAsync();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
