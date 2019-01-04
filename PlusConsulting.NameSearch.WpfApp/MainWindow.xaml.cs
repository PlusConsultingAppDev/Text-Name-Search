using PlusConsulting.NameSearch.WpfApp.ViewModels;

namespace PlusConsulting.NameSearch.WpfApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //NOTE: This should be moved to some type of bootstrapper, where we can setup things like dependency injection, view locators, etc.
            // Since this is a small/clean example, this is will suffice.
            ShellView.DataContext = new ShellViewModel(new NamesViewModel(), new SearchViewModel(), new ResultsViewModel());
        }
    }
}
