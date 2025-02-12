using PhoneBook.Model;

namespace PhoneBook.BLL;

public interface ICrudService
{
    public bool Insert(Person person);
    public bool Update(Person person);
    public bool Delete(Person person);
    public IEnumerable<Person> GetAll();
}