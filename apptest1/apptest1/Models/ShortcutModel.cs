using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace apptest1.Models
{
    class ShortcutModel 
    {
        public string Path { get; set; }
        public BitmapSource BitmapSource { get; set; }
        public string[] FileButton { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
