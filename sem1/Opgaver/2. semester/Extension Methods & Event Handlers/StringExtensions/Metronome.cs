using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public class Metronome
    {
        public event EventHandler Tick;

        public void Start()
        {
            Thread.Sleep(3000);
            OnTick();
        }
        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }

    }
}
