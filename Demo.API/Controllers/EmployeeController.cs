using Demo.BusinessLayer.Employee;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _iEmployeeService;

        public EmployeeController(IEmployeeService iEmployeeService)
        {
            _iEmployeeService = iEmployeeService;
        }


        [HttpGet]
        [Route("api/GetEmployee")]
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployee()
        {
            try
            {
                return await _iEmployeeService.GetEmployee();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
