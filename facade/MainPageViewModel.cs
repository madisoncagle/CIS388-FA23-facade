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

            Guesses.Add(new ColorGuess("beaded"));
            Guesses.Add(new ColorGuess("deface"));
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
        void Guess()
        {
            if (CurrentGuess.Length == 6) // only if there's enough letters in the guess
            {
                if (CurrentGuess == SecretColor)
                {
                    // go to game over page, DidWin = true
                }
                else if (Guesses.Count == 6)
                {
                    // go to game over page, DidWin = false
                }
                else
                {
                    // add CurrentGuess to Guesses
                    Guesses.Add(new ColorGuess(CurrentGuess));
                    CurrentGuess = "";
                }
            }
        }

        [RelayCommand]
        void Clear()
        {
            CurrentGuess = "";
        }
    }
}
