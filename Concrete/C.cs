using MyGame4.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame4.Concrete
{
    public class C : Oyuncu
    {
        private static C _nesne;
        private C()
        {

        }
        public static Oyuncu nesnever()
        {
            if (_nesne == null)
            {
                _nesne = new C();
            }

            return _nesne;
        }

       

       
    }
}
