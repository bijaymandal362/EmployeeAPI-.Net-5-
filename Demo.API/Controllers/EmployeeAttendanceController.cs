using Demo.BusinessLayer.EmployeeAttendance;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly IEmployeeAttendanceService _iEmployeeAttendanceService;

        public EmployeeAttendanceController(IEmployeeAttendanceService iEmployeeAttendanceService)
        {
            _iEmployeeAttendanceService = iEmployeeAttendanceService;
        }


        [HttpPost]
        [Route("api/InsertEmployeeAttendance")]
        public async Task InsertEmployeeAttendance(EmployeeAttendanceViewModel employeeAttendanceViewModel)
        {
            try
            {
                await _iEmployeeAttendanceService.InsertEmployeeAttendance(employeeAttendanceViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        [HttpGet]
        [Route("api/GetEmployeeAttendance")]
        public async Task<IEnumerable<EmployeeAttendanceViewModel>> GetEmployeeAttendance()
        {
            try
            {
              return  await _iEmployeeAttendanceService.GetEmployeeAttendance();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
