using System.Collections.ObjectModel;
using PhoneBook.BLL;
using PhoneBook.Model;

namespace PhoneBook.Desktop.ViewModels;

public class MainPageViewModel : PageViewModelBase
{
    public ObservableCollection<Person> Persons { get; } = [];

    public MainPageViewModel(ICrudService crudService)
    {
        Title = "PhoneBook";

        var persons = crudService.GetAll();
        Persons.Clear();
        foreach (var person in persons)
        {
            Persons.Add(person);
        }
    }
}