using Microsoft.Identity.Client;
using PrimeiraAPI.Model;

namespace PrimeiraAPI.DB
{
    public class EmployeeRepository : IEmmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
