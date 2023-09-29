using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    [QueryProperty("Result", "Result")]
    [QueryProperty("SecretColor", "SecretColor")]
    [QueryProperty("SecretColorHex", "SecretColorHex")]
    [QueryProperty("Subtext", "Subtext")]
    public partial class GameOverViewModel : ObservableObject
    {
        [ObservableProperty]
        private string result;

        [ObservableProperty]
        private Color secretColor;

        [ObservableProperty]
        private string secretColorHex;

        [ObservableProperty]
        private string subtext;

        public GameOverViewModel()
        {
            
        }

        [RelayCommand]
        async Task Replay()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
