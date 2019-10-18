using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var resizer = new ImageResizer();

            var img = Image.FromFile("d:\\tmp\\1.jpg");
            var newImg = resizer.ResizeImage(img, 200, 200);
            newImg.Save("d:\\tmp\\new200.png", ImageFormat.Jpeg);

            newImg = resizer.ResizeImage(img, 320, 200);
            newImg.Save("d:\\tmp\\new320.png", ImageFormat.Jpeg);

            newImg = resizer.ResizeImage(img, 600, 200);
            newImg.Save("d:\\tmp\\new600.png", ImageFormat.Jpeg);

            newImg = resizer.ResizeImage(img, 1200, 800);
            newImg.Save("d:\\tmp\\new1200.png", ImageFormat.Jpeg);
        }
    }
}
