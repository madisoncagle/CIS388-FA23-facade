using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    public partial class MainPageViewModel : ObservableObject
    {
        // PRIVATE VARS

        private List<Color> colors = new List<Color>
        {
            // Is there a better way to do this? Yes. Do I know it? No.
            new Color(Color.FromArgb("#EFFACE").Red, Color.FromArgb("#EFFACE").Green, Color.FromArgb("#EFFACE").Blue, Color.FromArgb("#EFFACE").Alpha),
            new Color(Color.FromArgb("#DEFACE").Red, Color.FromArgb("#DEFACE").Green, Color.FromArgb("#DEFACE").Blue, Color.FromArgb("#DEFACE").Alpha),
            new Color(Color.FromArgb("#DEEDED").Red, Color.FromArgb("#DEEDED").Green, Color.FromArgb("#DEEDED").Blue, Color.FromArgb("#DEEDED").Alpha),
            new Color(Color.FromArgb("#BEEFED").Red, Color.FromArgb("#BEEFED").Green, Color.FromArgb("#BEEFED").Blue, Color.FromArgb("#BEEFED").Alpha),
            new Color(Color.FromArgb("#BEDDED").Red, Color.FromArgb("#BEDDED").Green, Color.FromArgb("#BEDDED").Blue, Color.FromArgb("#BEDDED").Alpha),
            new Color(Color.FromArgb("#FACADE").Red, Color.FromArgb("#FACADE").Green, Color.FromArgb("#FACADE").Blue, Color.FromArgb("#FACADE").Alpha),
            new Color(Color.FromArgb("#DECADE").Red, Color.FromArgb("#DECADE").Green, Color.FromArgb("#DECADE").Blue, Color.FromArgb("#DECADE").Alpha),
            new Color(Color.FromArgb("#ACCEDE").Red, Color.FromArgb("#ACCEDE").Green, Color.FromArgb("#ACCEDE").Blue, Color.FromArgb("#ACCEDE").Alpha),
            new Color(Color.FromArgb("#DABBED").Red, Color.FromArgb("#DABBED").Green, Color.FromArgb("#DABBED").Blue, Color.FromArgb("#DABBED").Alpha),
            new Color(Color.FromArgb("#CABBED").Red, Color.FromArgb("#CABBED").Green, Color.FromArgb("#CABBED").Blue, Color.FromArgb("#CABBED").Alpha),
            new Color(Color.FromArgb("#BEADED").Red, Color.FromArgb("#BEADED").Green, Color.FromArgb("#BEADED").Blue, Color.FromArgb("#BEADED").Alpha)
        };

        private Random random = new Random();

        // PROPERTIES

        [ObservableProperty]
        private Color secretColor;

        [ObservableProperty]
        private string currentGuess;

        public ObservableCollection<ColorGuess> Guesses { get; set; }

        // CONSTRUCTOR

        public MainPageViewModel()
        {
            secretColor = colors[random.Next(colors.Count)];
            currentGuess = "";

            Guesses = new ObservableCollection<ColorGuess>();
        }

        // METHODS

        [RelayCommand]
        void AddLetter(string letter)
        {
            if (CurrentGuess.Length < 6)
            {
                CurrentGuess += letter;
            }
        }

        // TODO
        [RelayCommand]
        void DeleteLetter()
        {
            if (CurrentGuess.Length > 0)
            {
                CurrentGuess = CurrentGuess.Remove(CurrentGuess.Length - 1);
            }
        }

        // TODO
        [RelayCommand]
        async Task Guess()
        {
            if (CurrentGuess.Length == 6) // only if there's enough letters in the guess
            {
                if (CurrentGuess.ToLower() == SecretColor.ToHex().ToLower().Remove(0, 1))
                {
                    // go to game over page, DidWin = true
                    //await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={true}&SecretColor={SecretColor}");
                    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}", new Dictionary<string, object>
                    {
                        { "DidWin", true },
                        { "SecretColor", SecretColor },
                        { "SecretColorHex", SecretColor.ToHex().ToUpper() }
                    });
                    Reset();
                }
                else if (Guesses.Count == 5)
                {
                    // go to game over page, DidWin = false
                    //await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={false}&SecretColor={SecretColor}");
                    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}", new Dictionary<string, object>
                    {
                        { "DidWin", false },
                        { "SecretColor", SecretColor },
                        { "SecretColorHex", SecretColor.ToHex().ToUpper() }
                    });
                    Reset();
                }
                else
                {
                    // add CurrentGuess to Guesses
                    Guesses.Add(new ColorGuess(CurrentGuess.ToLower()));
                    CurrentGuess = "";
                }
            }
        }

        [RelayCommand]
        void Clear()
        {
            CurrentGuess = "";
        }

        void Reset()
        {
            CurrentGuess = "";
            Guesses.Clear();
            SecretColor = colors[random.Next(colors.Count)];
        }
    }
}
