using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

namespace apptest1
{
    /// <summary>
    /// Interaction logic for Appearance.xaml
    /// </summary>
    public partial class Features : Window
    {
        MediaPlayer mplayer = new MediaPlayer();
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
        private void StartupVoiceover(object sender, RoutedEventArgs e)
        {
            mplayer.Open(new Uri(@"C:\Users\jmsko\OneDrive\Documents\GitHub\Windows10Dock\apptest1\apptest1\SoundClips\Startup.m4a", UriKind.Relative));
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
