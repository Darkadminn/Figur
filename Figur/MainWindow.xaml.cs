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
        bool elip = false;
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
               resultP = 2*Math.PI*Convert.ToInt32(radius.Text.ToString());
               resultS = Math.PI * Math.Pow(Convert.ToInt32(radius.Text.ToString()), 2);
            }
            else if (P.IsChecked == true && S.IsChecked != true)
            {
                resultP = 2 * Math.PI * Convert.ToInt32(radius.Text.ToString());
            }
            else if(P.IsChecked != true && S.IsChecked == true)
            {
                resultS = Math.PI * Math.Pow(Convert.ToInt32(radius.Text.ToString()), 2);
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
            if (elip)
            {
                grid.Children[2].Visibility = Visibility.Hidden;
            }
            stackpanel.Visibility=Visibility.Visible;
            menu.Visibility=Visibility.Hidden;
        }
        private void Click_Draw(object sender, EventArgs e)
        {
            if((Convert.ToInt32(radius.Text.ToString()) * 2) > 432 || Convert.ToInt32(radius.Text.ToString()) <= 0 )
            {
                MessageBox.Show("рисование невозможно");
            }      
            else 
            {
                if (elip)
                {
                    grid.Children.RemoveAt(2);
                }
                else elip = true;
                Ellipse el = new Ellipse();
                el.Name = "ell";
                el.Width = (Convert.ToInt32(radius.Text.ToString()) * 2);
                el.Height = (Convert.ToInt32(radius.Text.ToString()) * 2);
                el.VerticalAlignment = VerticalAlignment.Center;
                el.HorizontalAlignment = HorizontalAlignment.Center;
                el.Fill = Brushes.BlueViolet;
                grid.Children.Add(el);
            }
            
        }
        private void Double_Click(object sender, EventArgs e)
        {
            radius.Text = "";
        }
    }
}
