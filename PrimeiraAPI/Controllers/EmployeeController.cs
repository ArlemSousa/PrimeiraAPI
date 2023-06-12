using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PrimeiraAPI.DB;
using PrimeiraAPI.Model;
using PrimeiraAPI.ViewModel;

namespace PrimeiraAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
       

        private readonly IEmmployeeRepository _emmployeeRepository;

        //construtor
        public EmployeeController(IEmmployeeRepository emmployeeRepository)
        {
            _emmployeeRepository = emmployeeRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {

            var employee = new Employee(employeeView.Name, employeeView.Age, null);

            //para adicionar eu chamo o meu repository e passo o meu var
            _emmployeeRepository.Add(employee);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _emmployeeRepository.GetAll();
            return Ok(employees);
        }
    }

   
}
