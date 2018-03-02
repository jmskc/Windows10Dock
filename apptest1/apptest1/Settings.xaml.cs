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
using System.Windows.Shapes;

namespace apptest1
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public Settings()
        {
            InitializeComponent();
        }

        private void Appereance_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Appereance_Button.Background = new SolidColorBrush(SystemColors.ControlLightColor);
        }

        private void Appereance_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Appereance_Button.Background = new SolidColorBrush();
        }

        private void Features_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Features_Button.Background = new SolidColorBrush(SystemColors.ControlLightColor);
        }

        private void Features_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Features_Button.Background = new SolidColorBrush();
        }

        private void Appereance_Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Appearance appearance = new Appearance();
            this.Close();
            appearance.Show();
        }
        private void Features_Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Features features = new Features();
            this.Close();
            features.Show();
        }
    }
}
