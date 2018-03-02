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
using Microsoft.Win32;

namespace apptest1
{
    /// <summary>
    /// Interaction logic for Appearance.xaml
    /// </summary>
    public partial class Features : Window
    {
        public Features()
        {
            InitializeComponent();
        }

        private void FeaturesBackButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.Close();
            settings.ShowDialog();
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("My Application", @"C:\Users\Vespir\Desktop\apptest1\setup.exe");
            MessageBox.Show("Program is now enabled at startup.");
        }
        private void button_click1(object sender, RoutedEventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.DeleteValue("My Application", false);
            MessageBox.Show("Program is now disabled at startup.");
        }
    }
}
