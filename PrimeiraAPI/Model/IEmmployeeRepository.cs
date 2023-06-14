namespace PrimeiraAPI.Model
{
    public interface IEmmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> GetAll();

        Employee? Get (int id);


    }
}

