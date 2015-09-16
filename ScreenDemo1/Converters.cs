using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ScreenDemo1
{
    static class Converters
    {
        public static ImageSource ConvertToImageSource(object value)
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
