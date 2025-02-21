using System;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using DynamicData.Binding;
using PhoneBook.BLL;
using PhoneBook.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PhoneBook.Desktop.ViewModels;

public class MainPageViewModel : PageViewModelBase
{
    public ObservableCollection<Person> Persons { get; } = [];
    [Reactive] public Person? SelectedPerson { get; set; }

    public ReactiveCommand<Unit, Unit> CommandEditPerson { get; }

    public MainPageViewModel(ICrudService crudService)
    {
        Title = "PhoneBook";

        var persons = crudService.GetAll();
        Persons.Clear();
        foreach (var person in persons)
        {
            Persons.Add(person);
        }

        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedPerson,
            vm => vm.SelectedPerson,
            (p1, _) => p1 is not null);
        
        CommandEditPerson = ReactiveCommand.Create(() =>
        {
            var person = SelectedPerson; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model) 
                model.Person = person;
        }, canEdit);
    }
}