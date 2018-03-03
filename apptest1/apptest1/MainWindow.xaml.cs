using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Interop;
using DynamicImageHandler;
using System.Windows.Media.Effects;

namespace apptest1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Appearance appearance = Application.Current.Windows.Cast<Appearance>().FirstOrDefault(window => window is Appearance) as Appearance;   //  Main Window
        List<Models.ShortcutModel> ShortcutList = new List<Models.ShortcutModel>();
        DropShadowEffect dropShadow = new DropShadowEffect();

        private byte ThemeColorValue;   // RGB color of the window.
        string[] fileButton1;
        string[] fileButton1reset;
        string Label = "";

        int counter = 2;

        //string[] fileButton2;
        //string[] fileButton3;
        //string[] fileButton4;
        //string[] fileButton5;

            //this is test comment

        private ContextMenu CustomContextMenu = new ContextMenu();
        
        private double halfWidth;

        public MainWindow()
        {
            InitializeComponent();

            InitializeSettingsButton();
            InitializeExitButton();

            ThemeColorValue = Convert.ToByte(Properties.Settings.Default.ThemeColor);

            // WINDOW SIZE 
            this.MainGrid.Height = Properties.Settings.Default.IconSize;
            this.Width = this.MainGrid.Children.Count * Properties.Settings.Default.IconSize+50;

            // PROPERTIES
            MainGrid.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(Properties.Settings.Default.Opacity), ThemeColorValue, ThemeColorValue, ThemeColorValue));
            MainGridBorder.BorderBrush = MainGrid.Background;
            SettingsButton.Height = Properties.Settings.Default.IconSize;

            InitializeDropShadowEffect();

            // POSITION
            //can probably move this into a method/class just returning the variables?
            //sets half the width of the main window as a variable for formatting use
            double halfWidth = this.Width / 2;

            //sets the left distance parameter for the main window distance to half the screen width minus half the mindow width
            //sets the top of the screen distance to 0 pixels
            PositionWindow(SystemParameters.PrimaryScreenWidth / 2 - halfWidth, 0);
        }

        private void InitializeDropShadowEffect()
        {
            Color color = new Color();
            if (Properties.Settings.Default.ThemeColor == 255)
            {
                dropShadow.Opacity = 0.2;
                dropShadow.BlurRadius = 20;
                color.ScB = 0;
                color.ScG = 0;
                color.ScR = 0;
                dropShadow.Color = color;
            }
            else if(Properties.Settings.Default.ThemeColor == 0)
            {
                dropShadow.Opacity = 0.7;
                dropShadow.BlurRadius = 20;
                color.ScB = 0;
                color.ScG = 0;
                color.ScR = 0;
                dropShadow.Color = color;
            }
            MainGridBorder.Effect = dropShadow;
        }
        
        /// <summary>
        /// Position Main Window on the screen.
        /// </summary>
        /// <param name="left">Position on the left side of the screen</param>
        /// <param name="top">Position on the top of the screen</param>
        private void PositionWindow(double left, double top)
        {
            this.Left = left;
            this.Top = top;
        }

        /// <summary>
        /// Creates Exit button.
        /// </summary>
        private void InitializeExitButton()
        {
            Models.ShortcutModel ExitShortcut = new Models.ShortcutModel();
            Button button = new Button();
            Image image = new Image();

            ExitShortcut.ID = ShortcutList.Count;
            ExitShortcut.BitmapSource = new BitmapImage(new Uri("/Icons/Exit.ico", UriKind.Relative));

            TestTextBlock.Visibility = Visibility.Hidden;

            ExitShortcut.Name = "Exit";

            button.MouseEnter += (s, f) => { TestTextBlock.Text = ExitShortcut.Name; };

            image.Source = ExitShortcut.BitmapSource;

            ShortcutList.Add(ExitShortcut); //  Store shortcut in global List for later re-use.
            MainGrid.Children.Add(button);   // Add button at the end of Items Control in Main Window
            button.Content = image; //  Add image to the button
            button.Click += (s, f) => { Environment.Exit(0); };   // Button click event
        }

        /// <summary>
        /// Manipulates Settings button.
        /// </summary>
        private void InitializeSettingsButton()
        {
            Models.ShortcutModel SettingsShortcut = new Models.ShortcutModel();
            Button button = new Button();
            Image image = new Image();

            SettingsShortcut.ID = ShortcutList.Count;
            SettingsShortcut.BitmapSource = new BitmapImage(new Uri("/Icons/Settings.ico", UriKind.Relative));

            image.Source = SettingsShortcut.BitmapSource;

            SettingsShortcut.Name = "Settings";

            SettingsButton.MouseEnter += (s, f) => { TestTextBlock.Text = SettingsShortcut.Name; };

            ShortcutList.Add(SettingsShortcut); //  Store shortcut in global List for later re-use. 
            button.Content = image; //  Add image to the button
            button.Click += (s, f) => { Settings Settings = new Settings(); Settings.Show(); };   // Button click event
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Process.Start(fileButton1[0]);
        //    //https://msdn.microsoft.com/en-us/library/system.diagnostics.process.start(v=vs.110).aspx
        //}

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    Process.Start(fileButton2[0]);
        //}

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    Process.Start(fileButton3[0]);
        //}

        //private void Button_Click_4(object sender, RoutedEventArgs e)
        //{
        //    Process.Start(fileButton4[0]);
        //}

        //private void Button_Click_5(object sender, RoutedEventArgs e)
        //{
        //    Process.Start(fileButton5[0]);
        //}

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Settings Settings = new Settings();
            Settings.Show();
        }

        //private void Button_Drop_1(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        // Note that you can have more than one file.
        //        fileButton1 = (string[])e.Data.GetData(DataFormats.FileDrop);

        //        //puts the filename back together as a full single string (concatenates ;) )
        //        string result = String.Concat(fileButton1);

        //        //found this bit online, not sure if theres another way to do it, will have to look and / or play with it
        //        //var is an implicitly typed data type, meaning that it is determined by the compiler

        //        //needed to include the system.Drawing.dll to get this to work
        //        //right click references, add references, System.Drawing -> in solution explorer
        //        //some reason does not work with folders



        //        try
        //        {
        //            var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(result);



        //            DynamicImageHandler.ImageTool.Wpf.WpfImageTool imageTool = new DynamicImageHandler.ImageTool.Wpf.WpfImageTool();
        //            var bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
        //                        ShellEx.GetBitmapFromFilePath(result, ShellEx.IconSizeEnum.ExtraLargeIcon).GetHicon(),
        //                        System.Windows.Int32Rect.Empty,
        //                        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

        //            sysicon.Dispose();

        //            //sets the source image to the icon associated  
        //            Icon1.Source = bmpSrc;

        //        }
        //        //catches an error that occurs if the icon image is not found (needed for folders as a priority)
        //        catch (System.IO.FileNotFoundException)
        //        {
        //            //sets the file to a default image saved in the icons folder .ico file
        //            Icon1.Source = new BitmapImage(new Uri("/Icons/FolderIcon.ico", UriKind.Relative));
        //            //https://stackoverflow.com/questions/350027/setting-wpf-image-source-in-code
        //        }

        //        //icon1 is the identifier for the image location on the actual dock

        //        //https://bhrnjica.net/2014/05/28/how-to-extract-default-file-icon-in-wpf-application/
        //        //https://www.codeproject.com/Questions/514592/DragplusandplusdropplusWPFplusC-plusgettingplusf
        //        //https://stackoverflow.com/questions/4841401/convert-string-array-to-string
        //        //20/02/2018
        //    }
        //}
        //private void Button_Drop_2(object sender, DragEventArgs e)
        //{
            
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        fileButton2 = (string[])e.Data.GetData(DataFormats.FileDrop);

        //        string result = String.Concat(fileButton2);

        //        try
        //        {
        //            var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(result);

        //            // Access Label -File Name
        //            string label = System.IO.Path.GetFileNameWithoutExtension(result);

        //            DynamicImageHandler.ImageTool.Wpf.WpfImageTool imageTool = new DynamicImageHandler.ImageTool.Wpf.WpfImageTool();
        //            var bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
        //                        ShellEx.GetBitmapFromFilePath(result, ShellEx.IconSizeEnum.ExtraLargeIcon).GetHicon(),
        //                        System.Windows.Int32Rect.Empty,
        //                        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

        //            sysicon.Dispose();

        //            TestTextBlock.Text = label;

        //            Icon2.Source = bmpSrc;

        //        }

        //        catch (System.IO.FileNotFoundException)
        //        {
        //            Icon2.Source = new BitmapImage(new Uri("/Icons/FolderIcon.ico", UriKind.Relative));
        //        }

        //    }
        //}
        //private void Button_Drop_3(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        // Note that you can have more than one file.
        //        fileButton3 = (string[])e.Data.GetData(DataFormats.FileDrop);

        //        string result = String.Concat(fileButton3);

        //        try
        //        {
        //            var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(result);


        //            DynamicImageHandler.ImageTool.Wpf.WpfImageTool imageTool = new DynamicImageHandler.ImageTool.Wpf.WpfImageTool();
        //            var bmpSrc =    Imaging.CreateBitmapSourceFromHIcon(
        //                            ShellEx.GetBitmapFromFilePath(result, ShellEx.IconSizeEnum.ExtraLargeIcon).GetHicon(),
        //                            Int32Rect.Empty,
        //                            BitmapSizeOptions.FromEmptyOptions());

        //            sysicon.Dispose();

        //            Icon3.Source = bmpSrc;

        //        }

        //        catch (System.IO.FileNotFoundException)
        //        {
        //            Icon3.Source = new BitmapImage(new Uri("/Icons/FolderIcon.ico", UriKind.Relative));
        //        }
        //    }
        //}
        //Button AddButton(Grid parent)
        //{
        //    Button button = new Button();
        //    parent.Children.Add(button);
        //    return button;
        //}
        ///// <summary>
        ///// Button 4 drop function - this variation operates with the Model (ShortcutModel).
        ///// </summary>
        //private void Button_Drop_4(object sender, DragEventArgs e)
        //{
            
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        Models.ShortcutModel Shortcut = new Models.ShortcutModel();
                
        //        fileButton4 = (string[])e.Data.GetData(DataFormats.FileDrop);

        //        Shortcut.Path = String.Concat(fileButton4);

        //        try
        //        {
        //            Shortcut.BitmapSource = Imaging.CreateBitmapSourceFromHIcon(
        //                                    ShellEx.GetBitmapFromFilePath(Shortcut.Path, ShellEx.IconSizeEnum.ExtraLargeIcon).GetHicon(),
        //                                    Int32Rect.Empty,
        //                                    BitmapSizeOptions.FromEmptyOptions());

        //            Icon4.Source = Shortcut.BitmapSource;
                    
        //        }

        //        catch (FileNotFoundException)
        //        {
        //            Icon4.Source = new BitmapImage(new Uri("/Icons/FolderIcon.ico", UriKind.Relative));
        //        }
        //    }
        //}
        //private void Button_Drop_5(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        // Note that you can have more than one file.
        //        fileButton5 = (string[])e.Data.GetData(DataFormats.FileDrop);

        //        string result = String.Concat(fileButton5);

        //        try
        //        {
        //            var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(result);


        //            DynamicImageHandler.ImageTool.Wpf.WpfImageTool imageTool = new DynamicImageHandler.ImageTool.Wpf.WpfImageTool();
        //            var bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
        //                        ShellEx.GetBitmapFromFilePath(result, ShellEx.IconSizeEnum.ExtraLargeIcon).GetHicon(),
        //                        System.Windows.Int32Rect.Empty,
        //                        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

        //            sysicon.Dispose();

        //            Icon5.Source = bmpSrc;

        //        }

        //        catch (System.IO.FileNotFoundException)
        //        {
        //            Icon5.Source = new BitmapImage(new Uri("/Icons/FolderIcon.ico", UriKind.Relative));
        //        }
        //    }
        //}

        /// <summary>
        /// Checks whether another widnow is open.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The XAML name of the window</param>
        /// <returns></returns>
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        /// <summary>
        /// Animation
        /// </summary>
        private void Mouse_Enter_Event(object sender, RoutedEventArgs e)
        {
            TestTextBlock.Visibility = Visibility.Visible;

            if (IsWindowOpen<Settings>("Settings1") || IsWindowOpen<Appearance>("Appearance1"))
            {

            }
            else
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation
                {
                    From = 0 - MainGrid.Height + 1,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.25)),
                };
                DoubleAnimation VisibilityAnimation = new DoubleAnimation()
                {
                    From = (IsVisible) ? 0.2 : 1,
                    To = (IsVisible) ? 1 : 0,
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                BeginAnimation(OpacityProperty, VisibilityAnimation);
                BeginAnimation(Canvas.TopProperty, myDoubleAnimation);
            }
        }

        /// <summary>
        /// Animation
        /// </summary>
        private void Mouse_Leave_Event(object sender, RoutedEventArgs e)
        {
            TestTextBlock.Visibility = Visibility.Hidden;

            if (IsWindowOpen<Settings>("Settings1") || IsWindowOpen<Appearance>("Appearance1"))
            {

            }
            else
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 0 - MainGrid.Height + 1,
                    Duration = new Duration(TimeSpan.FromSeconds(0.25)),

                };
                DoubleAnimation VisibilityAnimation = new DoubleAnimation()
                {
                    From = (IsVisible) ? 1 : 0.2,
                    To = (IsVisible) ? 0.2 : 1,
                    Duration = TimeSpan.FromSeconds(1)
                };
                BeginAnimation(OpacityProperty, VisibilityAnimation);
                BeginAnimation(Canvas.TopProperty, myDoubleAnimation);
            }

        }

        //private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    fileButton1 = fileButton1reset;
        //    fileButton1reset = fileButton1;
        //}


        /// <summary>
        /// Items dropped onto main grid will be added at the end of the column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_Drop(object sender, DragEventArgs e)
        {

            Models.ShortcutModel shortcut = new Models.ShortcutModel();
            Button button = new Button();
            Image image = new Image();

            shortcut.ID = ShortcutList.Count;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                shortcut.FileButton = (string[])e.Data.GetData(DataFormats.FileDrop);


                shortcut.Path = String.Concat(shortcut.FileButton);

                shortcut.Name = System.IO.Path.GetFileNameWithoutExtension(shortcut.Path);

                try
                {
                    shortcut.BitmapSource = Imaging.CreateBitmapSourceFromHIcon(
                                            ShellEx.GetBitmapFromFilePath(shortcut.Path, ShellEx.IconSizeEnum.ExtraLargeIcon).GetHicon(),
                                            Int32Rect.Empty,
                                            BitmapSizeOptions.FromEmptyOptions());

                    image.Source = shortcut.BitmapSource;
                    button.Content = shortcut.FileButton;

                }

                catch (FileNotFoundException)
                {
                    image.Source = new BitmapImage(new Uri("/Icons/FolderIcon.ico", UriKind.Relative));
                }
            }
            if(MainGrid.Columns < 7)
            {
                MainGrid.Columns += 1;
            }
            
            ShortcutList.Add(shortcut); //  Store shortcut in global List for later re-use.
            MainGrid.Children.Add(button);   // Add button at the end of Items Control in Main Window
            button.Content = image; //  Add image to the button
            button.Click += (s, f) => { Process.Start(shortcut.FileButton.ElementAt(0)); };   // Button click event
            ContextMenu contextMenu = new ContextMenu();
            button.ContextMenu = contextMenu;
            button.ToolTip = shortcut.Name;
            
            // Re used Ryan's deletion code for this purpouse + Remove button from Item Control + resize window
            MenuItem DeleteItem = new MenuItem();
            DeleteItem.Header = "Delete";
            button.ContextMenu.Items.Clear();
            DeleteItem.Click += (s, f) => {
                                            MainGrid.Children.Remove(button);
                                            MainGrid.Columns -= 1;
                                            MainGrid.Width = MainGrid.Children.Count * Properties.Settings.Default.IconSize;
                                            this.Width = this.MainGrid.Children.Count * Properties.Settings.Default.IconSize+50;
                                            halfWidth = this.Width / 2;
                                            this.Left = SystemParameters.PrimaryScreenWidth / 2 - halfWidth;

                //reduce the counter that checks the number of icons present
                counter--;
            };
            button.MouseEnter += (s, f) => { TestTextBlock.Text = shortcut.Name; };

            button.ContextMenu.Items.Add(DeleteItem);

            //for ever set maximum number of icons in the grid (including the settings and exit)
            if (counter % 7 == 0)
            {
                //set the columns to a maximum
                MainGrid.Columns = 7;
                //increase rows by 1
                MainGrid.Rows++;
                //set the height + 50 (for icon seperation)
                MainGrid.Height = (MainGrid.Height + MainGrid.Height / MainGrid.Rows) + 50;
                //reset the top value to the top of the screen to compensate for the height change
                Top = 0;

            }
            if(counter < 7)
            {
                // Update Sizing and Positioning
                MainGrid.Width = MainGrid.Children.Count * Properties.Settings.Default.IconSize;
                this.Width = this.MainGrid.Children.Count * Properties.Settings.Default.IconSize + 50;
                halfWidth = this.Width / 2;
                this.Left = SystemParameters.PrimaryScreenWidth / 2 - halfWidth;
            }
            
            counter++;

        }
    }
}

//https://www.codeproject.com/Questions/514592/DragplusandplusdropplusWPFplusC-plusgettingplusf

