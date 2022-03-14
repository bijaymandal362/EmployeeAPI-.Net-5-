using Demo.Entities.Data;
using Demo.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeCheckOut
{
    public class EmployeeCheckOutService : IEmployeeCheckOutService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeCheckOutService(EmployeeDbContext context)
        {
          _context = context;
        }
        public async Task CheckOut(int employeeId)
        {
            try
            {
                var checkInExit = _context.EmployeeCheckIn.FirstOrDefault(a => a.EmployeeId == employeeId);
                if (checkInExit !=null  &&checkInExit.Day == DateTime.Now.DayOfWeek.ToString())
                {
                    Demo.Entities.Model.EmployeeCheckOut employeeCheckOut = new Entities.Model.EmployeeCheckOut();
                    employeeCheckOut.EmployeeId = checkInExit.EmployeeId;
                    employeeCheckOut.Date = DateTime.Now.Date.ToShortDateString();
                    employeeCheckOut.CheckOut = (DateTime.Now.ToString("h:mm:ss tt"));
                    employeeCheckOut.Day = DateTime.Now.DayOfWeek.ToString();
                    await _context.AddAsync(employeeCheckOut);
                    _context.SaveChanges();


                }
                else
                {
                    throw new Exception("Please CheckIn First!!");
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<IEnumerable<EmployeeCheckOutViewModel>> GetEmployeeCheckOut()
        {
            try
            {
                var list = await(from e in _context.EmployeeCheckOut
                                 select new EmployeeCheckOutViewModel
                                 {
                                     EmployeeId = e.EmployeeId,
                                     Day = e.Day,
                                     CheckOut = e.CheckOut
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
