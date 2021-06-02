using MyGame4.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame4.Concrete
{
    public class D : Oyuncu
    {
        private static D _nesne;
        private D()
        {

        }
        public static Oyuncu nesnever()
        {
            if (_nesne == null)
            {
                _nesne = new D();
            }

            return _nesne;
        }

   
        
    }
}
