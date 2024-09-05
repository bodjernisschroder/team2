using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtensions
{
    public class Sparegris
    {
        public event EventHandler<MyEventArgs> DataChanged;
        private double _data;

        public void InsertAmount(double amount)
        {
            if (amount <= 0) return;

            _data += amount;
            OnSaldoChanged(new MyEventArgs { Data = _data });

            if (_data > 1197) Console.WriteLine("Tillykke – du har nu penge nok til tre sæsonkort til OBs kampe");
            else if (_data > 799) Console.WriteLine("Tillykke – du har nu penge nok til et premium sæsonkort til OBs kampe");
            else if (_data > 399) Console.WriteLine("Tillykke – du har nu penge nok til et sæsonkort til OBs kampe");
        }

        protected virtual void OnSaldoChanged(MyEventArgs e)
        {
            EventHandler<MyEventArgs> handler = DataChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
