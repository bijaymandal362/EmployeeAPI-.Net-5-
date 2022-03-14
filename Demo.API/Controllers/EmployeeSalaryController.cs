using Demo.BusinessLayer.EmployeeSalary;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IEmployeeSalaryService _iEmployeeSalaryService;

        public EmployeeSalaryController(IEmployeeSalaryService iEmployeeSalaryService)
        {
            _iEmployeeSalaryService = iEmployeeSalaryService;
        }

        [HttpGet] 
        [Route("api/GetEmployeeSalary")]
        public async Task<IEnumerable<EmployeeSalaryViewModel>> GetEmployeeSalary(DateTime endDate)
        {
            try
            {
               return  await _iEmployeeSalaryService.GetEmployeeSalary(endDate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet] 
        [Route("api/GetEmployeeSalaryList")]
        public async Task<IEnumerable<EmployeeSalaryViewModel>> GetEmployeeSalaryList()
        {
            try
            {
               return  await _iEmployeeSalaryService.GetEmployeeSalaryList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
