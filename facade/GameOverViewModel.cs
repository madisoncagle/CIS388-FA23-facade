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
    [QueryProperty("SecretColor", "SecretColor")]
    [QueryProperty("SecretColorHex", "SecretColorHex")]
    public partial class GameOverViewModel : ObservableObject
    {
        [ObservableProperty]
        private Color secretColor;

        [ObservableProperty]
        private string secretColorHex;

        public GameOverViewModel()
        {
            //SecretColorHex = SecretColor.ToHex().ToUpper().Remove(0, 1);
        }

        [RelayCommand]
        async Task Replay()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
