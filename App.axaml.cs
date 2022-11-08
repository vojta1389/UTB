using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace PizzaProjectBlank
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                InitialSetup initialSetup = new InitialSetup();
                MainViewModel mainViewModel = new MainViewModel();
                desktop.MainWindow = new MainWindow() {DataContext = mainViewModel};
                
                mainViewModel.LoadPizzas();
                mainViewModel.LoadIngredients();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}