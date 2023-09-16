using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        public MainPageViewModel()
        {
            Name = "Madison";
        }
    }
}
