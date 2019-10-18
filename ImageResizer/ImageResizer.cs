using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    public class ImageResizer
    {
        public Image ResizeImage(Image img, int width, int height, bool withCorrectBySmallerSize = false)
        {
            Size newSize = GetCorrectSize(img.Size, width, height, withCorrectBySmallerSize);
            Image result = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, newSize.Width, newSize.Height);
            }
            return result;
        }

        private Size GetCorrectSize(Size originalSize, int width, int height, bool correctSmaller)
        {
            var result = new Size();

            if (originalSize.Width > originalSize.Height)
            {
                result.Width = width;
                result.Height = CalculateRelationSize(originalSize, width);

                if (correctSmaller && result.Height > height)
                {
                    result.Width = CalculateCorrectionSize(result.Height, width, height);
                    result.Height = height;
                }
            }
            else if (originalSize.Width < originalSize.Height)
            {
                result.Height = height;
                result.Width = CalculateRelationSize(originalSize, height);

                if (correctSmaller && result.Width > width)
                {
                    result.Height = CalculateCorrectionSize(result.Width, height, width);
                    result.Width = width;
                }
            }
            else
            {
                result.Width =
                    result.Height = height > width ? width : height;
            }

            return result;
        }

        private int CalculateRelationSize(Size oldSize, int newBiggerSize)
        {
            var biggerSize = 0;
            var smallerSize = 0;

            CheckBiggerSize(oldSize, ref biggerSize, ref smallerSize);

            var percentRelation = smallerSize * 100 / biggerSize;
            return newBiggerSize * percentRelation / 100;
        }

        private int CalculateCorrectionSize(int smallerSize, int biggerSize, int newSmallerSize)
        {
            var pecentRelation = smallerSize * 100 / biggerSize;
            return newSmallerSize * 100 / pecentRelation;
        }

        private void CheckBiggerSize(Size oldSize, ref int biggerSize, ref int smallerSize)
        {
            if (oldSize.Width >= oldSize.Height)
            {
                biggerSize = oldSize.Width;
                smallerSize = oldSize.Height;
            }
            else if (oldSize.Width < oldSize.Height)
            {
                biggerSize = oldSize.Height;
                smallerSize = oldSize.Width;
            }
        }
    }
}
