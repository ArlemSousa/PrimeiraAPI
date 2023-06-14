using Microsoft.AspNetCore.Authorization;
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
       

        private readonly IEmmployeeRepository _employeeRepository;

        //construtor
        public EmployeeController(IEmmployeeRepository emmployeeRepository)
        {
            _employeeRepository = emmployeeRepository;
        }

        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            //caminho onde estou salvando a foto
            var filePath = Path.Combine("Storage", employeeView.photo.FileName);

            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);


            //para adicionar eu chamo o meu repository e passo o meu var
            _employeeRepository.Add(employee);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.GetAll();
            return Ok(employees);
        }


        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);
            return File(dataBytes, "image/png");
        }


    }

   
}
