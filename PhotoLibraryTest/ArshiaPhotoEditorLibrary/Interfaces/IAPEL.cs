using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ArshiaPhotoEditorLibrary.Models;

namespace ArshiaPhotoEditorLibrary.Interfaces
{
    public interface IAPEL
    {
        public void Ready(APELImage image);
        public void Brightness(float value);
        public void Contrast(float value);
        public void CustomeRGB(float r, float g, float b);
        public void CustomeRGB(float a, float r, float g, float b);
        public void Save(string path);
    }
}