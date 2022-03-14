using Demo.BusinessLayer.EmployeeCheckIn;
using Demo.BusinessLayer.EmployeeCheckOut;
using Demo.Models.ViewModel;
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
    public class EmployeeCheckInOutController : ControllerBase
    {
        private readonly IEmployeeCheckInService _iEmployeeCheckInService;
        private readonly IEmployeeCheckOutService _iEmployeeCheckOutService;

        public EmployeeCheckInOutController(IEmployeeCheckInService iEmployeeCheckInService, IEmployeeCheckOutService iEmployeeCheckOutService)
        {
            _iEmployeeCheckInService = iEmployeeCheckInService;
            _iEmployeeCheckOutService = iEmployeeCheckOutService;
        }

        [HttpPost]
        [Route("api/CheckIn")]
        public async Task CheckIn(int employeeId)
        {
            try
            {
                await _iEmployeeCheckInService.CheckIn(employeeId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/CheckOut")]
        public async Task CheckOut(int employeeId)
        {
            try
            {
                await _iEmployeeCheckOutService.CheckOut(employeeId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/GetEmployeeCheckIn")]
        public async Task<IEnumerable<EmployeeCheckInViewModel>> GetEmployeeCheckIn()
        {
            try
            {
                return await _iEmployeeCheckInService.GetEmployeeCheckIn();
            }
            catch (System.Exception)
            {

                throw;
            }
        } 
        
        [HttpGet]
        [Route("api/GetEmployeeCheckOut")]
        public async Task<IEnumerable<EmployeeCheckOutViewModel>> GetEmployeeCheckOut()
        {
            try
            {
              return   await _iEmployeeCheckOutService.GetEmployeeCheckOut();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
