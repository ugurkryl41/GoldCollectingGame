using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame4.Abstract
{
    public abstract class Oyunayarlari
    {
        public static Point Alanboyut { get; set; } = new Point(20, 20);
        public int altinoran { get; set; } = 20;
        public int gizlialtinoran { get; set; } = 10;
        public int bakiyemiktar { get; set; } = 200;
        public int hamleucreti { get; set; } = 5;
        public int hamlesayisi { get; set; } = 3;
        public int A_hedefsecucret { get; set; } = 5;
        public int B_hedefsecucret { get; set; } = 10;
        public int C_hedefsecucret { get; set; } = 15;
        public int D_hedefsecucret { get; set; } = 20;
        public int C_gizlialtinacma { get; set; } = 2;

    }
}
