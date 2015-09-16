using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Size = System.Drawing.Size;

namespace ScreenDemo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image _currentImage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnTakeScreen_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

            Image allScreen = ImageWorker.CaptureRectagle(0, 0, SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight);
            Img.Source = Converters.ConvertToImageSource(allScreen);

            WindowState = WindowState.Normal;

            _currentImage = allScreen;
            BtnSave.IsEnabled = true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            SaveFileDialog dlg = new SaveFileDialog { DefaultExt = "png", Filter = "Png Files|*.png" };
            bool? res = dlg.ShowDialog();

            if (res == true)
                _currentImage.Save(dlg.FileName, ImageFormat.Png);
        }

        private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
