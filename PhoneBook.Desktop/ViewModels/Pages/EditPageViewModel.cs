using System.Reactive;
using PhoneBook.BLL;
using PhoneBook.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PhoneBook.Desktop.ViewModels;

public class EditPageViewModel : PageViewModelBase
{
    [Reactive] public Person? Person { get; set; }
    
    public ReactiveCommand<Unit, Unit> CommandSave { get; }
    
    public EditPageViewModel(ICrudService crudService)
    {
        Title = "Edit";
        
        CommandSave = ReactiveCommand.Create(() =>
        {
            crudService.Update(Person);
        });
    }

    public void CommandClear()
    {
        Person = null;
    }
}