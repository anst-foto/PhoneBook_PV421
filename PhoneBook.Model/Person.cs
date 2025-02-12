namespace PhoneBook.Model;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Phone> Phones { get; set; }
    public bool IsDeleted => !IsActive;
    public bool IsActive { get; set;} = true;
}