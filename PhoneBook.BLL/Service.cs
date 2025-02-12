using PhoneBook.DAL;
using PhoneBook.Model;

namespace PhoneBook.BLL;

public class Service : ICrudService
{
    private readonly ICrud _crud;

    public Service()
    {
        _crud = new DbContext();
    }

    public bool Insert(Person person)
    {
        return _crud.Insert(person);
    }

    public bool Update(Person person)
    {
        return _crud.Update(person);
    }

    public bool Delete(Person person)
    {
        person.IsActive = false;
        return _crud.Update(person);
    }

    public IEnumerable<Person> GetAll()
    {
        return _crud.GetAll();
    }
}