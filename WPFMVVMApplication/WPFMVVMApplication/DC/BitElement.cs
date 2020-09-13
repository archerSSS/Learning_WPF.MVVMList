using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMApplication.DC
{
    public class BitElement : INotifyPropertyChanged
    {
        private string text;

        public string Text { get { return text; } set { text = value; OnPropertyChanged("Text"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }
    }
}
