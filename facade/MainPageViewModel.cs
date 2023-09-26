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
        // PROPERTIES

        [ObservableProperty]
        private string secretColor;

        [ObservableProperty]
        private string currentGuess;

        public ObservableCollection<ColorGuess> Guesses { get; set; }

        // CONSTRUCTOR

        public MainPageViewModel()
        {
            secretColor = "facade";
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
                Console.WriteLine("adding letter");
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
                if (CurrentGuess.ToLower() == SecretColor)
                {
                    // go to game over page, DidWin = true
                    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={true}");
                    ClearData();
                }
                else if (Guesses.Count == 6)
                {
                    // go to game over page, DidWin = false
                    await Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={false}");
                    ClearData();
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

        void ClearData()
        {
            CurrentGuess = "";
            Guesses.Clear();
        }
    }
}
