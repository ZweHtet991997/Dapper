using Dapper_in_.Net_6.Models;
using Dapper_in_.Net_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_in_.Net_6.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDbServices _service;

        public EmployeeController(EmployeeDbServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/employee")]
        public async Task<IActionResult> GetEmployee()
        {
            var dataResult = await _service.GetEmployee();
            return Ok(dataResult);
        }

        [HttpPost]
        [Route("api/employee")]
        public async Task<IActionResult> Create([FromBody] EmployeeModel model)
        {
            var dataResult = await _service.Create(model);
            return dataResult > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        [Route("api/employee")]
        public async Task<IActionResult> Update([FromBody] EmployeeModel model)
        {
            var dataResult = await _service.Update(model);
            return dataResult > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("api/employee")]
        public async Task<IActionResult> Delete(int Id)
        {
            var dataResult = await _service.Delete(Id);
            return dataResult > 0 ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("api/getemployeebyid")]
        public async Task<IActionResult> GetEmployeeById(int employeeID)
        {
            var dataResult = await _service.GetEmployeeById(employeeID);
            return Ok(dataResult);
        }
    }
}
