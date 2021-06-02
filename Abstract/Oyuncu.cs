using MyGame4.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame4.Abstract
{
    public abstract class Oyuncu
    {       
        public int kasaaltin { get; set; }
        public int toplanan_altin { get; set; }
        public int harcanan_altin { get; set; }
        public int toplam_adim { get; set; }
        public bool durumu { get; set; } = true;
        public bool hedef_varmi { get; set; } = false;
        public Point konum { get; set; }
        public Point hedef { get; set; }

        public int[,] yolmatris;

    }
}
