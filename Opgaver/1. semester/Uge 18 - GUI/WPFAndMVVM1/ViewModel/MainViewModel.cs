using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAndMVVM1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string myLabelText = "Text not set yet";

        public string MyLabelText
        {
            get { return myLabelText; }
            set
            {
                myLabelText = value;
                OnPropertyChanged("MyLabelText");
            }
        }

        private string myTextBoxText = "Text not set yet";

        public string MyTextBoxText
        {
            get { return myTextBoxText; }
            set
            {
                myTextBoxText = value;
                OnPropertyChanged("MyTextBoxText");
            }
        }

        //public event PropertyChangedEventHandler? PropertyChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)

        {

            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;

            if (propertyChanged != null)

            {

                propertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }

        }

        //protected void OnPropertyChanged(string MyLabelText)

        //{

        //    PropertyChangedEventHandler propertyChanged = this.PropertyChanged;

        //    if (propertyChanged != null)

        //    {

        //        propertyChanged(this, new PropertyChangedEventArgs(MyLabelText));

        //    }

        //}
    }
}

//public string MyLabelText
//{
//    get { return _myLabelText; }
//    set
//    {
//        if (_myLabelText != value)
//        {
//            _myLabelText = value;
//            OnPropertyChanged(MyLabelText);
//        }
//    }
//}
