using Demo.Entities.Data;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.Salary
{
    public class SalaryService : ISalaryService
    {
        private readonly EmployeeDbContext _context;

        public SalaryService(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SalaryViewModel>> GetSalary()
        {
            try
            {
                var list = await (from s in _context.Salary
                                  select new SalaryViewModel
                                  {
                                      EmployeeSalaryId = s.EmployeeSalaryId,
                                      MaximumHour = (decimal)s.MaximumHour,
                                      MinimumHour = s.MinimumHour,
                                      RatePerHour = s.RatePerHour

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
