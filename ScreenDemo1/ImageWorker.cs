using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            if (iw == 0 || ih == 0)
                return null;

            Image image = new Bitmap(Math.Abs(iw), Math.Abs(ih), PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.CopyFromScreen(ix, iy, 0, 0, new Size(Math.Abs(iw), Math.Abs(ih)), CopyPixelOperation.SourceCopy);
       
            return image;
        }

    }
}
