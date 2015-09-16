using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ScreenDemo1
{
   static class ImageWorker
    {
        public static Image CaptureRectagle(double x, double y, double width, double height)
        {
            int ix = Convert.ToInt32(x);
            int iy = Convert.ToInt32(y);
            int iw = Convert.ToInt32(width);
            int ih = Convert.ToInt32(height);
            Image image = new Bitmap(iw, ih, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(ix, iy, ix, iy, new Size(iw, ih), CopyPixelOperation.SourceCopy);

            return image;
        }
    }
}
