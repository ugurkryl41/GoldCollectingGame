using MyGame4.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame4.Concrete
{
    public class A : Oyuncu
    {
        private static A _nesne;
        static object _lockObject = new object();
        private A()
        {

        }
        public static Oyuncu nesnever()
        {
            lock (_lockObject)
            {
                if (_nesne == null)
                {
                    _nesne = new A();
                }
            }
            return _nesne;
        }    
       
    }
}
