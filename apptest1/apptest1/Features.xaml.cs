
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
        private void Startup_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(@"C:\Users\Pussy Cake\Documents\GitHub\Windows10Dock\apptest1\apptest1\SoundClips\Startup.m4a", UriKind.Relative));
            mplayer.Play();
        }
        private void enable(object sender, RoutedEventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("My Application", @"C:\Users\Vespir\Desktop\apptest1\setup.exe");
            MessageBox.Show("Program is now enabled at startup.");
        }
        private void disable(object sender, RoutedEventArgs e)
        {
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.DeleteValue("My Application", false);
            MessageBox.Show("Program is now disabled at startup.");
        }
    }
}
