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
    public partial class Sonuc : Form
    {
        public Sonuc()
        {
            InitializeComponent();
        }
        Oyuncu oyuncu1 = A.nesnever();
        Oyuncu oyuncu2 = B.nesnever();
        Oyuncu oyuncu3 = C.nesnever();
        Oyuncu oyuncu4 = D.nesnever();
        private void Sonuc_Load(object sender, EventArgs e)
        {
            tbx_akasa.Text = oyuncu1.kasaaltin.ToString();
            tbx_aharcananaltin.Text = oyuncu1.harcanan_altin.ToString();
            tbx_atoplananaltin.Text = oyuncu1.toplanan_altin.ToString();
            tbx_atoplamadim.Text = oyuncu1.toplam_adim.ToString();

            tbx_bkasa.Text = oyuncu2.kasaaltin.ToString();
            tbx_bharcananaltin.Text = oyuncu2.harcanan_altin.ToString();
            tbx_btoplananaltin.Text = oyuncu2.toplanan_altin.ToString();
            tbx_btoplamadim.Text = oyuncu2.toplam_adim.ToString();

            tbx_ckasa.Text = oyuncu3.kasaaltin.ToString();
            tbx_charcananaltin.Text = oyuncu3.harcanan_altin.ToString();
            tbx_ctoplananaltin.Text = oyuncu3.toplanan_altin.ToString();
            tbx_ctoplamadim.Text = oyuncu3.toplam_adim.ToString();

            tbx_dkasa.Text = oyuncu4.kasaaltin.ToString();
            tbx_dharcananaltin.Text = oyuncu4.harcanan_altin.ToString();
            tbx_dtoplananaltin.Text = oyuncu4.toplanan_altin.ToString();
            tbx_dtoplamadim.Text = oyuncu4.toplam_adim.ToString();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Close();
        }
    }
}
