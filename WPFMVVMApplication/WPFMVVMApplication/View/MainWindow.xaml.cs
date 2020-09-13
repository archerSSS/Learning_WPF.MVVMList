using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMVVMApplication.DC;
using WPFMVVMApplication.VM;

namespace WPFMVVMApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool listOpened;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void ShowList(object sender, RoutedEventArgs e)
        {
            double FromBottom = 0;
            double ToBottom = 0;
            if (listOpened)
            {
                TextBlockShow.Text = "Show List";
                FromBottom = 300;
            }
            else
            {
                TextBlockShow.Text = "Hide List";
                ToBottom = 300;
            }
            listOpened = !listOpened;

            ThicknessAnimation ta = new ThicknessAnimation();
            Storyboard sb= new Storyboard();
            EasingFunctionBase efb = new PowerEase() { Power = 8 };
            ta.From = new Thickness(0, 0, 0, FromBottom);
            ta.To = new Thickness(0, 0, 0, ToBottom);
            ta.Duration = new Duration(TimeSpan.FromSeconds(2));
            ta.EasingFunction = efb;

            sb.Children.Add(ta);
            Storyboard.SetTargetProperty(ta, new PropertyPath(Grid.MarginProperty));
            Storyboard.SetTargetName(ta, BorderBox.Name);
            sb.Begin(this);
            Storyboard.SetTargetName(ta, BorderBox.Name);
            sb.Begin(this);
        }
    }
}
