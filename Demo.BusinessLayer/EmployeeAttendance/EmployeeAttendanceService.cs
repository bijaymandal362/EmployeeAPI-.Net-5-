using Demo.Entities.Data;
using Demo.Models;
using Demo.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeAttendance
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeAttendanceService(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeAttendanceViewModel>> GetEmployeeAttendance()
        {
            try
            {
                var list = await (from e in _context.EmployeeAttendance
                                  select new EmployeeAttendanceViewModel
                                  {
                                      EmployeeAttendanceId = e.EmployeeAttendanceId,
                                      EmployeeId = e.EmployeeId,
                                      TotalHours = e.TotalHours,
                                      Date = e.Date
                                  }).ToListAsync();

                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task InsertEmployeeAttendance(EmployeeAttendanceViewModel employeeAttendanceViewModel)
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                string dateString = employeeAttendanceViewModel.Date.ToString();
                DateTime dateValue;

                //var checkDate = (from e in _context.EmployeeSalary
                //                 select new 
                //             { 

                //}   )
                try
                {
                    var employee = await _context.Employee.Where(a => a.EmployeeId == employeeAttendanceViewModel.EmployeeId).FirstAsync();
                    var limitPerDay = await _context.MaximumHourLimit.Where(a => a.LimitPerDay >= employeeAttendanceViewModel.TotalHours).FirstAsync();

                    if (employee != null && limitPerDay != null)
                    {
                        dateValue = DateTime.Parse(dateString, CultureInfo.InvariantCulture);
                       

                        Demo.Entities.EmployeeAttendance employeeAttendance = new Entities.EmployeeAttendance();
                        if (employeeAttendanceViewModel.EmployeeAttendanceId == 0)
                        {
                            if ((dateValue.ToString("dddd") == DemoEnum.Days.Sunday.ToString()) || (dateValue.ToString("dddd") == DemoEnum.Days.Saturday.ToString()))
                            {
                                throw new Exception("Please donot select the date that refers to Sunday or Saturday");
                            }
                            else
                            {
                                employeeAttendance.EmployeeId = employeeAttendanceViewModel.EmployeeId;
                                employeeAttendance.TotalHours = employeeAttendanceViewModel.TotalHours;
                                employeeAttendance.Date = employeeAttendanceViewModel.Date.Date;
                                await _context.EmployeeAttendance.AddAsync(employeeAttendance);
                                _context.SaveChanges();
                                transaction.Commit();
                            }
                        }
                        else
                        {
                            throw new Exception("EmployeeAttendanceId is null");
                        }
                    }
                    else
                    {
                        throw new Exception("EmployeeId doesnot exists");
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }
    }
}
