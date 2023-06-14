using Microsoft.Identity.Client;

namespace PrimeiraAPI.ViewModel
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }

        //public int id { get; set; }

        public IFormFile photo { get; set; } 

    }
}
