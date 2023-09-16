namespace facade;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // allows Shell.Current.GoToAsync("<page name>")
        Routing.RegisterRoute(nameof(GameOverPage), typeof(GameOverPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}

