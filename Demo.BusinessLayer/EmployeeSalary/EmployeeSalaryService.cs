using Demo.Entities.Data;
using Demo.Models;
using Demo.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.EmployeeSalary
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeSalaryService(EmployeeDbContext context)
        {
            _context = context;
        }

        public DateTime CalculateStartDay(DateTime endDate)
        {

            DateTime date = endDate;
            DateTime checkEndDate;
            var checkStartEndDate = _context.EmployeeSalary.FirstOrDefault(a => a.EndDate <= endDate );
            if (checkStartEndDate !=null)
            {
                return (checkEndDate = checkStartEndDate.EndDate.AddDays(1));
            }
            else if (date.DayOfWeek == DayOfWeek.Friday)
            {

                TimeSpan day = new TimeSpan(4, 0, 0, 0);
                DateTime startDate = date.Subtract(day);
                return startDate;
            }
            else if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                TimeSpan day = new TimeSpan(3, 0, 0, 0);
                DateTime startDate = date.Subtract(day);
                return startDate;
            }
            else if (date.DayOfWeek == DayOfWeek.Wednesday)
            {
                TimeSpan day = new TimeSpan(2, 0, 0, 0);
                DateTime startDate = date.Subtract(day);
                return startDate;
            }
            else if (date.DayOfWeek == DayOfWeek.Tuesday)
            {
                TimeSpan day = new TimeSpan(1, 0, 0, 0);
                DateTime startDate = date.Subtract(day);
                return startDate;
            }
            else
            {
                if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    TimeSpan day = new TimeSpan(0, 0, 0, 0);
                    DateTime startDate = date.Subtract(day);
                    return startDate;
                }
                else
                {
                    throw new Exception("end date shoudnot be sunday or saturday");
                }
            }
        }
        public async Task<IEnumerable<EmployeeSalaryViewModel>> GetEmployeeSalary(DateTime endDate)
        {
            string dateString = endDate.ToString();
            DateTime dateValue;

            try
            {
                dateValue = DateTime.Parse(dateString, CultureInfo.InvariantCulture);

                if ((dateValue.ToString("dddd") == DemoEnum.Days.Sunday.ToString()) || (dateValue.ToString("dddd") == DemoEnum.Days.Saturday.ToString()))
                {
                    throw new Exception("Please donot select the date that refers to Sunday or Saturday");
                }
                else
                {
                    var calculateEndDay = CalculateStartDay(endDate);

                    var employeeAttendance = await (from ea in _context.EmployeeAttendance
                                                    where (ea.Date <= endDate && endDate >= calculateEndDay && ea.Date >= calculateEndDay)
                                                    group ea by ea.EmployeeId into g
                                                    select new
                                                    {
                                                        EmployeeId = g.Key,
                                                        TotalHours = (decimal)(g.Sum(y => y.TotalHours))
                                                    }).ToListAsync();


                    if (employeeAttendance != null)
                    {
                        foreach (var item in employeeAttendance)
                        {
                            var maxTimeLimit = await _context.MaximumHourLimit.FirstOrDefaultAsync();

                            var minMaxValue = await _context.Salary.Where(a => a.MinimumHour < item.TotalHours &&
                            (a.MaximumHour == null ? (maxTimeLimit.LimitPerDay) * 5 : a.MaximumHour) >= item.TotalHours).ToListAsync();
                            if (minMaxValue != null)
                            {
                                foreach (var value in minMaxValue)
                                {
                                    var list = _context.EmployeeSalary.Where(a => a.EmployeeId == item.EmployeeId).FirstOrDefault();

                                    var employeeSalary = new Demo.Entities.EmployeeSalary();
                                    if (list == null || list.EndDate.DayOfWeek == DayOfWeek.Friday )
                                    {
                                        employeeSalary.TotalWorkingHour = item.TotalHours;
                                        employeeSalary.EmployeeId = item.EmployeeId;
                                        employeeSalary.Rate = value.RatePerHour;
                                        employeeSalary.NetAmount = Convert.ToDecimal(item.TotalHours) * Convert.ToDecimal(value.RatePerHour);
                                        employeeSalary.StartDate = (Convert.ToDateTime(CalculateStartDay(endDate)).Date);
                                        employeeSalary.EndDate = dateValue.Date;
                                        _context.EmployeeSalary.Add(employeeSalary);
                                    }
                                    else if (list != null && list.EndDate < endDate && list.EmployeeId == item.EmployeeId && list.EndDate.DayOfWeek > DayOfWeek.Monday) 
                                    {
                                      
                                        employeeSalary.TotalWorkingHour = item.TotalHours;
                                        employeeSalary.EmployeeId = item.EmployeeId;
                                        employeeSalary.Rate = value.RatePerHour;
                                        employeeSalary.NetAmount = Convert.ToDecimal(item.TotalHours) * Convert.ToDecimal(value.RatePerHour);
                                        employeeSalary.StartDate = list.EndDate.AddDays(1).Date;
                                        employeeSalary.EndDate = dateValue.Date;
                                        _context.EmployeeSalary.Add(employeeSalary);

                                    }
                                    else
                                    {
                                        throw new Exception("Couldnot find the required value!!");
                                    }
                                }
                            }
                        }
                        await _context.SaveChangesAsync();
                        return await GetEmployeeSalaryList();
                    }
                    else
                    {
                        throw new Exception("Somethingwent wrong!!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeSalaryViewModel>> GetEmployeeSalaryList()
        {
            var list = await (from e in _context.EmployeeSalary
                              select new EmployeeSalaryViewModel
                              {
                                  EmployeeId = e.EmployeeId,
                                  StartDate = e.StartDate,
                                  EndDate = e.EndDate,
                                  TotalWorkingHour = e.TotalWorkingHour,
                                  Rate = e.Rate,
                                  NetAmount = e.NetAmount
                              }).ToListAsync();
            return list;
        }
    }
}
