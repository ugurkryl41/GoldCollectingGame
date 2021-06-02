using MyGame4.Abstract;
using MyGame4.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame4
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
       
        private void Giris_Load(object sender, EventArgs e)
        {
            
        }
        private void btn_yenioyun_Click(object sender, EventArgs e)
        {
            // Oyun Başlangıcında Txt dosyalarını sıfırlıyor..
            StreamWriter sw = new StreamWriter(@"A.txt", false);
            sw.Write("");
            sw.Flush();
            sw.Close();

            StreamWriter sw1 = new StreamWriter(@"B.txt", false);
            sw1.Write("");
            sw1.Flush();
            sw1.Close();

            StreamWriter sw2 = new StreamWriter(@"C.txt", false);
            sw2.Write("");
            sw2.Flush();
            sw2.Close();

            StreamWriter sw3 = new StreamWriter(@"D.txt", false);
            sw3.Write("");
            sw3.Flush();
            sw3.Close();

            this.Hide();
            Oyunalani oyunalani = new Oyunalani();
            oyunalani.Show();
        }

        private void btn_ayarlar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
