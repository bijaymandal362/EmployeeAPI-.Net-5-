using Demo.BusinessLayer.Salary;
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
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _iSalaryService;

        public SalaryController(ISalaryService iSalaryService)
        {
            _iSalaryService = iSalaryService;
        }

        [HttpGet]
        [Route("api/GetSalary")]
        public async Task<IEnumerable<SalaryViewModel>> GetSalary()
        {
            try
            {
                return await _iSalaryService.GetSalary();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
