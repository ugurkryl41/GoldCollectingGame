using MyGame4.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame4.Concrete
{
    public class B : Oyuncu
    {
        private static B _nesne;
        private B()
        {

        }
        public static Oyuncu nesnever()
        {
            if (_nesne == null)
            {
                _nesne = new B();
            }

            return _nesne;
        }

       

        
    }
}
