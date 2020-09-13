using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFMVVMApplication.CM;
using WPFMVVMApplication.DC;

namespace WPFMVVMApplication.VM
{
    public class BitElementVM : INotifyPropertyChanged
    {
        public string Text { get; set; }
        private BitElement be;
        public BitElement Be { get { return be; } set { be = value; NotifyPropertyChanged("Be"); } }

        private ObservableCollection<BitElement> bitElements;
        public ObservableCollection<BitElement> BitElements { get { return bitElements; } set { bitElements = value; NotifyPropertyChanged("BitElements"); } }

        public BitElementVM()
        {
            BitElements = new ObservableCollection<BitElement>();
        }

        ICommand addCommand;
        ICommand clearCommand;

        public ICommand AddText
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new MaskCommand(Execute, CanExecute);
                }
                return addCommand;
            }
        }

        public ICommand ClearList
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new MaskCommand(ClearExecute, CanExecute);
                }
                return clearCommand;
            }
        }

        private void Execute(object parameter)
        {
            bitElements.Add(new BitElement() { Text = this.Text });
        }

        private void ClearExecute(object parameter)
        {
            bitElements.Clear();
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
    }
}
