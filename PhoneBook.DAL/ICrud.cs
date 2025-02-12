using PhoneBook.Model;

namespace PhoneBook.DAL;

public interface ICrud
{
    public bool Insert(Person person);
    public bool Update(Person person);
    public IEnumerable<Person> GetAll();
}