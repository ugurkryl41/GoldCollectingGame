using MyGame4.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame4.Concrete
{
    public class oyunayar:Oyunayarlari
    {
        public static oyunayar _nesne { get; set; }
        private oyunayar()
        {

        }
        public static oyunayar nesnever()
        {
            if (_nesne == null)
            {
                _nesne = new oyunayar();
            }
            return _nesne;
        }

      

    }
}
