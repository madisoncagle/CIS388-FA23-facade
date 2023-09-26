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
    public partial class GameOverViewModel : ObservableObject
    {
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
