using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facade
{
    public class ColorGuess
    {
        public string Guess { get; set; }

        public Color Color => Color.FromArgb($"#{Guess}");

        public ColorGuess(string color)
        {
            Guess = color;
        }
    }
}
