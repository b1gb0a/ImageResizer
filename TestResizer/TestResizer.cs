using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestResizer
{
    [TestClass]
    public class TestResizer
    {
        private readonly Image origVerticalImg;
        private readonly Image origHorizontalImg;
        private readonly ImageResizer.ImageResizer resizer;

        public TestResizer()
        {
            origHorizontalImg = new Bitmap(1024, 800);
            origVerticalImg = new Bitmap(800, 1024);
            resizer = new ImageResizer.ImageResizer();
        }

        [TestMethod]
        public void TestHorizontalWithoutCorrection()
        {                        
            Image result = resizer.ResizeImage(origHorizontalImg, 800, 600);
            Assert.AreEqual(800, result.Width);

            result = resizer.ResizeImage(origHorizontalImg, 800, 800);
            Assert.AreEqual(800, result.Width);

            result = resizer.ResizeImage(origHorizontalImg, 600, 800);            
            Assert.AreEqual(600, result.Width);
        }

        [TestMethod]
        public void TestVerticalWithoutCorrection()
        {
            Image result = resizer.ResizeImage(origVerticalImg, 800, 600);
            Assert.AreEqual(600, result.Height);

            result = resizer.ResizeImage(origVerticalImg, 800, 800);
            Assert.AreEqual(800, result.Height);

            result = resizer.ResizeImage(origVerticalImg, 600, 800);
            Assert.AreEqual(800, result.Height);            
        }

        [TestMethod]
        public void TestHorizontalWithCorrection()
        {
            Image result = resizer.ResizeImage(origHorizontalImg, 800, 600, true);
            Assert.AreEqual(true, result.Width < 800);
            Assert.AreEqual(600, result.Height);

            result = resizer.ResizeImage(origHorizontalImg, 600, 600, true);
            Assert.AreEqual(600, result.Width);
            Assert.AreEqual(true, result.Height < 600);

            result = resizer.ResizeImage(origHorizontalImg, 600, 800, true);
            Assert.AreEqual(600, result.Width);
            Assert.AreEqual(true, result.Height < 800);
        }

        [TestMethod]
        public void TestVerticalWithCorrection()
        {
            Image result = resizer.ResizeImage(origVerticalImg, 800, 600, true);
            Assert.AreEqual(true, result.Width < 800);
            Assert.AreEqual(600, result.Height);

            result = resizer.ResizeImage(origVerticalImg, 600, 600, true);
            Assert.AreEqual(600, result.Height);
            Assert.AreEqual(true, result.Width < 600);

            result = resizer.ResizeImage(origVerticalImg, 600, 800, true);
            Assert.AreEqual(true, result.Height < 800);
            Assert.AreEqual(600, result.Width);
        }
    }
}
