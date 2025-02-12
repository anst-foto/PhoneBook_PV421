using System.Collections.ObjectModel;
using System.Reactive;
using PhoneBook.BLL;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PhoneBook.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PageListItem> Pages { get; } = 
    [
        new() {PageViewModel = new MainPageViewModel(new Service())},
        new() {PageViewModel = new EditPageViewModel()},
    ];
    [Reactive] public PageListItem SelectedPage { get; set; }
    
    [Reactive] public bool IsPaneOpen { get; set; }
    
    public ReactiveCommand<Unit, bool> CommandPaneOpenClose { get; }

    public MainWindowViewModel()
    {
        SelectedPage = Pages[0];
        
        IsPaneOpen = true;
        CommandPaneOpenClose = ReactiveCommand.Create(() => IsPaneOpen = !IsPaneOpen);
    }
}