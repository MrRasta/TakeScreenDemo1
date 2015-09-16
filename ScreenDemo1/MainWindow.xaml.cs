using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
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
            Image allScreen = CaptureScreen(0, 0, SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight);
            Img.Source = ConvertImg(allScreen);

            _currentImage = allScreen;
            BtnSave.IsEnabled = true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private Image CaptureScreen(double x, double y, double width, double height)
        {
            int ix, iy, iw, ih;
            ix = Convert.ToInt32(x);
            iy = Convert.ToInt32(y);
            iw = Convert.ToInt32(width);
            ih = Convert.ToInt32(height);
            Image image = new Bitmap(iw, ih, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(ix, iy, ix, iy, new Size(iw, ih), CopyPixelOperation.SourceCopy);

            return image;
        }

        private void Save()
        {
            SaveFileDialog dlg = new SaveFileDialog { DefaultExt = "png", Filter = "Png Files|*.png" };
            bool? res = dlg.ShowDialog();

            if (res == true)
                _currentImage.Save(dlg.FileName, ImageFormat.Png);
            
        }

        private static ImageSource ConvertImg(object value)
        {
            MemoryStream ms = new MemoryStream();
            ((Bitmap)value).Save(ms, ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            return image;
        }
    }
}
