using MyGame4.Abstract;
using MyGame4.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame4
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        Oyunayarlari oyunayarlari = oyunayar.nesnever();
        private void Ayarlar_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Oyunayarlari.Alanboyut = new Point(Convert.ToInt32(tbx_xboyut.Text),Convert.ToInt32(tbx_ykonum.Text));
            oyunayarlari.altinoran = Convert.ToInt32(tbx_altinoran.Text);
            oyunayarlari.gizlialtinoran = Convert.ToInt32(tbx_gizlialtin.Text);
            oyunayarlari.bakiyemiktar = Convert.ToInt32(tbx_bakiyemiktar.Text);
            oyunayarlari.hamleucreti = Convert.ToInt32(tbx_hamlefiyat.Text);
            oyunayarlari.hamlesayisi = Convert.ToInt32(tbx_hamlesayisi.Text);
            oyunayarlari.C_gizlialtinacma = Convert.ToInt32(tbx_cgizlialtin.Text);
            oyunayarlari.A_hedefsecucret = Convert.ToInt32(tbx_ahedefmaliyet.Text);
            oyunayarlari.B_hedefsecucret = Convert.ToInt32(tbx_bhedefmaliyet.Text);
            oyunayarlari.C_hedefsecucret = Convert.ToInt32(tbx_chedefmaliyet.Text);
            oyunayarlari.D_hedefsecucret = Convert.ToInt32(tbx_dhedefmaliyet.Text);

            this.Close();
            Giris giris = new Giris();
            giris.Show();
        }
    }
}
