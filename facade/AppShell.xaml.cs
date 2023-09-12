﻿namespace facade;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(GameOverPage), typeof(GameOverPage)); // allows Shell.Current.GoToAsync("<page name>")
    }
}

