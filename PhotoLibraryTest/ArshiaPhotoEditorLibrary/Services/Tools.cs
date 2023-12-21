using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ArshiaPhotoEditorLibrary.Models;

namespace ArshiaPhotoEditorLibrary.Services
{
    class Tools
    {
        APELImage _apelImage;
        Bitmap _bitmap;
        public Tools(APELImage image)
        {
            _apelImage = image;
            _bitmap = new Bitmap(Bitmap.FromFile(_apelImage.Path));
        }


        internal void Brightness(float value)
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                float[][] matrix = {
                   new float [] {1,0,0,0,0},
                   new float [] {0,1,0,0,0},
                   new float [] {0,0,1,0,0},
                   new float [] {0,0,0,1,0},
                   new float [] {value,value,value,1,1}
                   };

                ColorMatrix colorMatrix = new ColorMatrix(matrix);
                imageAttributes.SetColorMatrix(colorMatrix);
                g.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), 0, 0, _bitmap.Width, _bitmap.Height, GraphicsUnit.Pixel, imageAttributes);

            }
        }

        internal void Contrast(float value)
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                float[][] matrix = {
                   new float [] {value,0,0,0,0},
                   new float [] {0,value,0,0,0},
                   new float [] {0,0,value,0,0},
                   new float [] {0,0,0,1,0},
                   new float [] {0,0,0,1,1}
                   };

                ColorMatrix colorMatrix = new ColorMatrix(matrix);
                imageAttributes.SetColorMatrix(colorMatrix);
                g.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), 0, 0, _bitmap.Width, _bitmap.Height, GraphicsUnit.Pixel, imageAttributes);

            }
        }

        public void CustmeRGB(float r = 1, float g = 1, float b = 1)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                float[][] matrix = {
                          new float[] {r,0,0,0,0},
                          new float[] {0,g,0,0,0},
                          new float[] {0,0,b,0,0},
                          new float[] {0,0,0,1,0},
                          new float[] {0,0,0,1,1},
                 };

                ColorMatrix colorMatrix = new ColorMatrix(matrix);
                imageAttributes.SetColorMatrix(colorMatrix);
                graphics.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), 0, 0, _bitmap.Width, _bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
            }
        }

        public void CustmeRGB(float a = 1, float r = 1, float g = 1, float b = 1)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                float[][] matrix = {
                          new float[] {r,0,0,0,0},
                          new float[] {0,g,0,0,0},
                          new float[] {0,0,b,0,0},
                          new float[] {0,0,0,a,0},
                          new float[] {0,0,0,0,1},
                 };

                ColorMatrix colorMatrix = new ColorMatrix(matrix);
                imageAttributes.SetColorMatrix(colorMatrix);
                _bitmap.MakeTransparent(Color.Red);
                graphics.DrawImage(_bitmap, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), 0, 0, _bitmap.Width, _bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
            }
        }

        internal void Save(string path)
        {
            _bitmap.Save(path);
        }
    }
}