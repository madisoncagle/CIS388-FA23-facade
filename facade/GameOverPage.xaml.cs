namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage
{
    private bool didWin;
    public bool DidWin
    {
        get => didWin;
        set
        {
            didWin = value;
            ResultLabel.Text = didWin ? "You won!" : "Too bad";
        }
    }

    public GameOverPage()
    {
        InitializeComponent();
    }
}
