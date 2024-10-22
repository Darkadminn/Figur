using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Figur
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double resultP = 0;
        double resultS = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Result(object sender, RoutedEventArgs e)
        {
            resultP = 0;
            resultS = 0;
            if (P.IsChecked == true && S.IsChecked == true)
            {
                resultP = Convert.ToInt32(value1.Text.ToString()) + Convert.ToInt32(value2.Text.ToString()) + Convert.ToInt32(value3.Text.ToString());
                double p = (Convert.ToInt32(value1.Text.ToString()) + Convert.ToInt32(value2.Text.ToString()) + Convert.ToInt32(value3.Text.ToString())) / 2;
                resultS = Math.Sqrt(p * (p - Convert.ToInt32(value1.Text.ToString())) * (p - Convert.ToInt32(value2.Text.ToString())) * (p - Convert.ToInt32(value3.Text.ToString())));
            }
            else if (P.IsChecked == true && S.IsChecked != true)
            {
                resultP = Convert.ToInt32(value1.Text.ToString()) + Convert.ToInt32(value2.Text.ToString()) + Convert.ToInt32(value3.Text.ToString());
            }
            else if(P.IsChecked != true && S.IsChecked == true)
            {
                double p = (Convert.ToInt32(value1.Text.ToString()) + Convert.ToInt32(value2.Text.ToString()) + Convert.ToInt32(value3.Text.ToString())) / 2;
                resultS = Math.Sqrt(p * (p - Convert.ToInt32(value1.Text.ToString())) * (p - Convert.ToInt32(value2.Text.ToString())) * (p - Convert.ToInt32(value3.Text.ToString())));
            }
            stackpanel.Visibility = Visibility.Hidden;
            menu.Visibility = Visibility.Visible;
        }
        private void Click_Calc(object sender, EventArgs e)
        {
            if (resultP != 0 && resultS != 0) MessageBox.Show($"Периметр - {resultP}\nПлощадь - {resultS}");
            else if (resultP == 0 && resultS != 0) MessageBox.Show($"Площадь - {resultS}");
            else if (resultP != 0 && resultS == 0) MessageBox.Show($"Периметр - {resultP}");
            
        }
        private void Click_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Click_Input(object sender, EventArgs e)
        {
            stackpanel.Visibility=Visibility.Visible;
            menu.Visibility=Visibility.Hidden;
        }
    }
}
