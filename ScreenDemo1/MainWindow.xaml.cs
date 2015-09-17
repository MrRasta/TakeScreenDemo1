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
    public partial class MainWindow
    {
        private Image _currentImage;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region UI Events
        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion

        private void BtnTakeScreen_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

            Image allScreen = ImageWorker.CaptureRectagle(0, 0, SystemParameters.PrimaryScreenWidth,
                SystemParameters.PrimaryScreenHeight);

            if (allScreen != null)
            {
                Img.Source = Converters.ConvertToImageSource(allScreen);

                WindowState = WindowState.Normal;

                _currentImage = allScreen;
                BtnSave.IsEnabled = true;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog { DefaultExt = "png", Filter = "Png Files|*.png" };
            bool? res = dlg.ShowDialog();

            if (res == true)
                _currentImage.Save(dlg.FileName, ImageFormat.Png);
        }

        private void BtnTakeRectangle_Click(object sender, RoutedEventArgs e)
        {
            
            Image rect = TakeRectWindow.GetRectangle();
            if (rect != null)
            {
                Img.Source = Converters.ConvertToImageSource(rect);
                _currentImage = rect;

                BtnSave.IsEnabled = true;
            }
        }
    }
}
