using Demo.Entities.Data;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLayer.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;

        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployee()
        {

            try
            {
                var list = await (from e in _context.Employee
                                  select new EmployeeViewModel
                                  {
                                      EmployeeId = e.EmployeeId,
                                      FullName = e.FullName,
                                      Address = e.Address,

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
