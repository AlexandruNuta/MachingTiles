using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1mvp
{
    public class ImageItem
    {
        public string ImagePath { get; set; }
        public ImageItem(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
