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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace apptest1
{
    /// <summary>
    /// Interaction logic for Appearance.xaml
    /// </summary>
    public partial class Appearance : Window
    {
        private MainWindow mainWin = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;   //  Main Window
        byte themeColorValue = Convert.ToByte(Properties.Settings.Default.ThemeColor);
        
        public Appearance()
        {
            InitializeComponent();
            InitializeTheme();
            InitializeOpacitySlider(10);
            InitializeIconSizeSlider(48,128,16);
        }

        /// <summary>
        /// Checks the index of theme picked in the settings and sets it as current theme.
        /// </summary>
        private void InitializeTheme()
        {
            themeColorValue = Convert.ToByte(Properties.Settings.Default.ThemeColor);

            if (themeColorValue == 0)
            {
                ThemeColor.SelectedIndex = 1;
            }
            else if (themeColorValue == 255)
            {
                ThemeColor.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Initialise Icon Size Slider values.
        /// </summary>
        /// <param name="Minimum">Minimum icon size.</param>
        /// <param name="Maximum">Maximum icon size.</param>
        /// <param name="TickFrequency">Frequency in which value is changed.</param>
        private void InitializeIconSizeSlider(int Minimum, int Maximum,int TickFrequency)
        {
            IconSizeSlider.Minimum = Minimum;
            IconSizeSlider.Maximum = Maximum;
            IconSizeSlider.TickFrequency = TickFrequency;
            // Allows slider value to snap into set position depending on TickFrequency
            IconSizeSlider.IsSnapToTickEnabled = true;
        }

        /// <summary>
        /// Opacity of the dock.
        /// </summary>
        /// <param name="Minimum">Minimum opacity allowed (scale from 0 to 255)</param>
        private void InitializeOpacitySlider(int Minimum)
        {
            OpacityValue.Text = Properties.Settings.Default.Opacity.ToString() + "%";   // Display opacity value registered in settings.
            OpacitySlider.Value = Properties.Settings.Default.Opacity;  // Place slider position at value equal to one stored under Opacity field in settings.
            OpacitySlider.Minimum = Minimum;
        }

        /// <summary>
        /// Go back to Settings main menu.
        /// </summary>
        private void AppearanceBackButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            this.Close();
            settings.Show();
        }

        /// <summary>
        /// Opacity control in appearance settings tab.
        /// </summary>
        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) 
        {
            byte themeColorValue = Convert.ToByte(Properties.Settings.Default.ThemeColor);
            int val = Convert.ToInt32(OpacitySlider.Value);
            double displayVal = Properties.Settings.Default.Opacity / 2.55;
            Properties.Settings.Default.Opacity = val;
            OpacityValue.Text = Convert.ToInt32(displayVal).ToString() + "%";
            mainWin.MainGrid.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(Properties.Settings.Default.Opacity), themeColorValue, themeColorValue, themeColorValue));
            mainWin.MainGridBorder.BorderBrush = mainWin.MainGrid.Background;
            mainWin.MainGrid.Height = Properties.Settings.Default.IconSize;
            double halfWidth = mainWin.Width / 2;
            mainWin.Left = SystemParameters.PrimaryScreenWidth / 2 - halfWidth;
            mainWin.LabelBorder.BorderBrush = mainWin.MainGrid.Background;
            mainWin.TestTextBlock.Background = mainWin.MainGrid.Background;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Icon size control in appearance settings tab.
        /// </summary>
        private void IconSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(IconSizeSlider.Value);
            IconSizeValue.Text = val.ToString() + "px";
            Properties.Settings.Default.IconSize = val;
            mainWin.SettingsButton.Height = Properties.Settings.Default.IconSize;
            mainWin.Width = mainWin.MainGrid.Children.Count * Properties.Settings.Default.IconSize + 50;
            mainWin.MainGrid.Width = mainWin.MainGrid.Children.Count * Properties.Settings.Default.IconSize;
            mainWin.MainGrid.Height = Properties.Settings.Default.IconSize;
            double halfWidth = mainWin.Width / 2;
            mainWin.Left = SystemParameters.PrimaryScreenWidth / 2 - halfWidth;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Sets theme color for the dock.
        /// </summary>
        private void ThemeColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DropShadowEffect dropShadowEffect = new DropShadowEffect();
            dropShadowEffect.BlurRadius = 20;
            Color color = new Color();
            byte themeColorValue = Convert.ToByte(Properties.Settings.Default.ThemeColor);
            if (ThemeColor.SelectedValue==ThemeColorLight)
            {
                dropShadowEffect.Opacity = 0.2;
                color.ScB = 255;
                color.ScG = 255;
                color.ScR = 255;
                Properties.Settings.Default.ThemeColor = 255;
                themeColorValue = 255;
                ThemeColor.SelectedValue = ThemeColorLight;
                mainWin.MainGrid.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(Properties.Settings.Default.Opacity), themeColorValue, themeColorValue, themeColorValue));
                mainWin.MainGridBorder.BorderBrush = mainWin.MainGrid.Background;
                mainWin.MainGridBorder.Effect = dropShadowEffect;

                // Label
                mainWin.TestTextBlock.Foreground = Brushes.Black;
                mainWin.LabelBorder.BorderBrush = mainWin.MainGrid.Background;
                mainWin.TestTextBlock.Background = mainWin.MainGrid.Background;
                mainWin.LabelGrid.Effect = dropShadowEffect;
            }
            else if(ThemeColor.SelectedValue==ThemeColorDark)
            {
                dropShadowEffect.Opacity = 0.7;
                color.ScB = 0;
                color.ScG = 0;
                color.ScR = 0;
                dropShadowEffect.Color = color;
                Properties.Settings.Default.ThemeColor = 0;
                themeColorValue = 0;
                ThemeColor.SelectedValue = ThemeColorDark;
                mainWin.MainGrid.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(Properties.Settings.Default.Opacity), themeColorValue, themeColorValue, themeColorValue));
                mainWin.MainGridBorder.BorderBrush = mainWin.MainGrid.Background;
                mainWin.MainGridBorder.Effect = dropShadowEffect;

                // Label
                mainWin.TestTextBlock.Foreground = Brushes.White;
                mainWin.LabelBorder.BorderBrush = mainWin.MainGrid.Background;
                mainWin.TestTextBlock.Background = mainWin.MainGrid.Background;
                mainWin.LabelGrid.Effect = dropShadowEffect;

            }
            Properties.Settings.Default.Save();
        }
    }
}
