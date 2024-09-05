using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public class MySubcriber
    {
        public void Subscribe(Sparegris sparegris)
        {
            sparegris.DataChanged += OnSaldoChanged;
        }
        private void OnSaldoChanged(object sender, MyEventArgs e) 
        {
            Console.WriteLine("Sparegrisen har nu: " + e.Data + " kroner.");
        }

        public void TickListener(Metronome metronome) 
        {
            metronome.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Heard you!");
        }
    }
}
