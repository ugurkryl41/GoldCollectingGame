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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame4
{
    public partial class Oyunalani : Form
    {
        public Oyunalani()
        {
            InitializeComponent();
        }

        Oyunayarlari oyunayarlari = oyunayar.nesnever();

        Oyuncu oyuncu1 = A.nesnever();
        Oyuncu oyuncu2 = B.nesnever();
        Oyuncu oyuncu3 = C.nesnever();
        Oyuncu oyuncu4 = D.nesnever();

        Random rastgele = new Random();

        public Button[,] buttons = new Button[oyunayar.Alanboyut.X, oyunayar.Alanboyut.Y];
        public int[,] alanmatris = new int[oyunayar.Alanboyut.X, oyunayar.Alanboyut.Y];
        public int[,] altinmatris = new int[oyunayar.Alanboyut.X, oyunayar.Alanboyut.Y];
        public int Toplamaltin = 0;
        private void Oyunalani_Load(object sender, EventArgs e)
        {
            Array.Clear(buttons, 0, buttons.Length);
            Array.Clear(alanmatris, 0, alanmatris.Length);
            Array.Clear(altinmatris, 0, altinmatris.Length);
            this.Location = new Point(100, 100);
            this.Height = 900;
            this.Width = 900;
          
            oyuncu1.yolmatris = new int[oyunayar.Alanboyut.X, oyunayar.Alanboyut.Y];
            oyuncu2.yolmatris = new int[oyunayar.Alanboyut.X, oyunayar.Alanboyut.Y];
            oyuncu3.yolmatris = new int[oyunayar.Alanboyut.X, oyunayar.Alanboyut.Y];
            oyuncu4.yolmatris = new int[oyunayar.Alanboyut.X, oyunayar.Alanboyut.Y];

            for (int i = 0; i < oyunayar.Alanboyut.X; i++)
            {
                for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                {
                    oyuncu1.yolmatris[i, j] = 0;
                    oyuncu2.yolmatris[i, j] = 0;
                    oyuncu3.yolmatris[i, j] = 0;
                    oyuncu4.yolmatris[i, j] = 0;
                }
            }

            oyuncu1.yolmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 1;
            oyuncu2.yolmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 1;
            oyuncu3.yolmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 1;
            oyuncu4.yolmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 1;

            oyuncubilgileri();
            oyunalanolustur();

        }

        private void btn_basla_Click(object sender, EventArgs e)
        {
            while (Toplamaltin > 0)
            {
                if (oyuncu1.durumu == false && oyuncu2.durumu == false && oyuncu3.durumu == false && oyuncu4.durumu == false)
                {
                    break;
                }
                if (Toplamaltin == 0)
                {
                    break;
                }

                int a = oyunayarlari.hamlesayisi;

                if (oyuncu1.hedef_varmi == false)
                {
                    Aoyuncuhedefsec();
                }
                while (a > 0)
                {
                    if (oyuncu1.durumu == true)
                    {
                        if (oyuncu1.hedef_varmi == false)
                        {
                            break;
                        }
                        else
                        {
                            AoyuncuHamleyap(); a--; Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        a--;

                    }
                }
                Thread.Sleep(200); this.Refresh();

                a = oyunayarlari.hamlesayisi;
                if (oyuncu2.hedef_varmi == false)
                {
                    Boyuncuhedefsec();
                }
                while (a > 0)
                {
                    if (oyuncu2.durumu == true)
                    {
                        if (oyuncu2.hedef_varmi == false)
                        {
                            break;
                        }
                        else
                        {
                            BoyuncuHamleyap(); a--; Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        a--;

                    }
                }
                Thread.Sleep(200); this.Refresh();

                a = oyunayarlari.hamlesayisi;
                if (oyuncu3.hedef_varmi == false)
                {
                    Coyuncuhedefsec();
                }
                while (a > 0)
                {
                    if (oyuncu3.durumu == true)
                    {
                        if (oyuncu3.hedef_varmi == false)
                        {
                            break;
                        }
                        else
                        {
                            CoyuncuHamleyap(); a--; Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        a--;

                    }
                }
                Thread.Sleep(200); this.Refresh();

                a = oyunayarlari.hamlesayisi;
                if (oyuncu4.hedef_varmi == false)
                {
                    Doyuncuhedefsec();
                }
                while (a > 0)
                {
                    if (oyuncu4.durumu == true)
                    {
                        if (oyuncu4.hedef_varmi == false)
                        {
                            break;
                        }
                        else
                        {
                            DoyuncuHamleyap(); a--; Thread.Sleep(200); this.Refresh();
                        }
                    }
                    else
                    {
                        a--;

                    }
                }
                Thread.Sleep(200); this.Refresh();
            }
            this.Refresh();
            Thread.Sleep(500);
            this.Refresh();
            Sonuc sonuc = new Sonuc();
            sonuc.Show();
            this.Close();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Close();
            Giris giris = new Giris();
            giris.Show();
        }

        public void oyuncubilgileri()
        {
            oyuncu1.kasaaltin = oyunayarlari.bakiyemiktar;
            oyuncu1.konum = new Point(0, 0);
            oyuncu1.hedef = new Point(0, 0);
            oyuncu1.hedef_varmi = false;
            oyuncu1.durumu = true;
            oyuncu1.toplam_adim = 0;
            oyuncu1.toplanan_altin = 0;
            oyuncu1.harcanan_altin = 0;
            
            oyuncu2.kasaaltin = oyunayarlari.bakiyemiktar;
            oyuncu2.konum = new Point(0, buttons.GetUpperBound(1));
            oyuncu2.hedef = new Point(0, 0);
            oyuncu2.hedef_varmi = false;
            oyuncu2.durumu = true;
            oyuncu2.toplam_adim = 0;
            oyuncu2.toplanan_altin = 0;
            oyuncu2.harcanan_altin = 0;

            oyuncu3.kasaaltin = oyunayarlari.bakiyemiktar;
            oyuncu3.konum = new Point(buttons.GetUpperBound(0), buttons.GetUpperBound(1));
            oyuncu3.hedef = new Point(0, 0);
            oyuncu3.hedef_varmi = false;
            oyuncu3.durumu = true;
            oyuncu3.toplam_adim = 0;
            oyuncu3.toplanan_altin = 0;
            oyuncu3.harcanan_altin = 0;

            oyuncu4.kasaaltin = oyunayarlari.bakiyemiktar;
            oyuncu4.konum = new Point(buttons.GetUpperBound(0), 0);
            oyuncu4.hedef = new Point(0, 0);
            oyuncu4.hedef_varmi = false;
            oyuncu4.durumu = true;
            oyuncu4.toplam_adim = 0;
            oyuncu4.toplanan_altin = 0;
            oyuncu4.harcanan_altin = 0;

            tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();
            tbx_Akonum.Text = oyuncu1.konum.ToString();
            tbx_Ahedef.Text = oyuncu1.hedef.ToString();

            tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();
            tbx_Bkonum.Text = oyuncu2.konum.ToString();
            tbx_Bhedef.Text = oyuncu2.hedef.ToString();

            tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();
            tbx_Ckonum.Text = oyuncu3.konum.ToString();
            tbx_Chedef.Text = oyuncu3.hedef.ToString();

            tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();
            tbx_Dkonum.Text = oyuncu4.konum.ToString();
            tbx_Dhedef.Text = oyuncu4.hedef.ToString();
        }

        public void oyunalanolustur()
        {
            int top = 0, left = 0;
            int butonboyut = 30;

            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Height = butonboyut * (Oyunayarlari.Alanboyut.X + 2);

            for (int i = 0; i < Oyunayarlari.Alanboyut.X; i++)
            {
                for (int j = 0; j < Oyunayarlari.Alanboyut.Y; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Height = butonboyut;
                    buttons[i, j].Width = butonboyut;
                    buttons[i, j].Top = top;
                    buttons[i, j].Left = left;
                    buttons[i, j].BackColor = Color.LightGray;
                    left += butonboyut;
                    pictureBox1.Controls.Add(buttons[i, j]);

                }
                left = 0;
                top += butonboyut;
            }

            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";

            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;

            // Altınları matrise ekleme kodu 

            double altinsayisi = (oyunayar.Alanboyut.X * oyunayar.Alanboyut.Y * oyunayarlari.altinoran) / 100;
            double gizlialtinsayisi = (altinsayisi * oyunayarlari.gizlialtinoran) / 100;

            for (int i = 0; i < Math.Ceiling(altinsayisi);)
            {
                int xkonum = rastgele.Next(0, oyunayar.Alanboyut.X);
                int ykonum = rastgele.Next(0, oyunayar.Alanboyut.Y);

                if (alanmatris[xkonum, ykonum] == 0)
                {
                    alanmatris[xkonum, ykonum] = 1; i++;
                }
            }
            for (int i = 0; i < Math.Ceiling(gizlialtinsayisi);)
            {
                int xkonum = rastgele.Next(0, oyunayar.Alanboyut.X);
                int ykonum = rastgele.Next(0, oyunayar.Alanboyut.Y);

                if (alanmatris[xkonum, ykonum] == 1)
                {
                    alanmatris[xkonum, ykonum] = 2; i++;
                }
            }

            //** Altın değerleri altındeğer matrise ekliyoruz.

            for (int i = 0; i < oyunayar.Alanboyut.X; i++)
            {
                for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                {
                    int altindeger = rastgele.Next(1, 5) * 5;
                    if (alanmatris[i, j] == 1 || alanmatris[i, j] == 2)
                    {
                        altinmatris[i, j] = altindeger;
                        Toplamaltin += altindeger;
                    }
                }
            }

            // Altınları oyunalanında gösterme kodu

            for (int i = 0; i < oyunayar.Alanboyut.X; i++)
            {
                for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                {
                    if (alanmatris[i, j] == 1)
                    {
                        buttons[i, j].Text = altinmatris[i, j].ToString();
                    }
                }
            }
        }

        public void Aoyuncuhedefsec()
        {
            if (oyuncu1.kasaaltin < oyunayarlari.A_hedefsecucret || Toplamaltin <= 0)
            {
                oyuncu1.durumu = false;
                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "";
                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                oyuncu1.konum = Point.Empty; oyuncu1.hedef = Point.Empty;
                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                tbx_Akonum.Text = oyuncu1.konum.ToString();
                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
            }

            if (oyuncu1.durumu == true && oyuncu1.hedef_varmi == false && Toplamaltin > 0)
            {
                double max_uzaklik = double.MaxValue;

                for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                {
                    for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                    {
                        if (alanmatris[i, j] == 1)
                        {
                            double yol_uzaklik = Math.Sqrt(Math.Pow((oyuncu1.konum.X - i), 2) + Math.Pow((oyuncu1.konum.Y - j), 2));

                            if (yol_uzaklik < max_uzaklik)
                            {
                                max_uzaklik = yol_uzaklik;
                                oyuncu1.hedef = new Point(i, j);
                            }
                        }
                    }
                }
                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                buttons[oyuncu1.hedef.X, oyuncu1.hedef.Y].BackColor = Color.Pink;
                oyuncu1.harcanan_altin += oyunayarlari.A_hedefsecucret;
                oyuncu1.kasaaltin -= oyunayarlari.A_hedefsecucret;
                tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();
                oyuncu1.hedef_varmi = true;
                oyuncu1.yolmatris[oyuncu1.hedef.X, oyuncu1.hedef.Y] = 2;
                Aoyuncu_yaz();
                if (oyuncu1.hedef.X == 0 && oyuncu1.hedef.Y == 0)
                {
                    oyuncu1.hedef_varmi = false;
                }
            }
        }

        public void Boyuncuhedefsec()
        {
            if (oyuncu2.kasaaltin < oyunayarlari.B_hedefsecucret || Toplamaltin <= 0)
            {
                oyuncu2.durumu = false;
                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "";
                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                oyuncu2.konum = new Point(0, alanmatris.GetUpperBound(1)); oyuncu2.hedef = Point.Empty;
                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                tbx_Bkonum.Text = oyuncu2.konum.ToString();
                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                
            }

            if (oyuncu2.durumu == true && oyuncu2.hedef_varmi == false && Toplamaltin > 0)
            {
                double max_uzaklik = double.MaxValue;

                for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                {
                    for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                    {
                        if (alanmatris[i, j] == 1)
                        {
                            double yol_uzaklik = Math.Sqrt(Math.Pow((oyuncu2.konum.X - i), 2) + Math.Pow((oyuncu2.konum.Y - j), 2));
                            double maliyet = (yol_uzaklik * 5) - altinmatris[i, j];
                            if (maliyet < max_uzaklik)
                            {
                                max_uzaklik = maliyet;
                                oyuncu2.hedef = new Point(i, j);
                            }
                        }
                    }
                }
                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                buttons[oyuncu2.hedef.X, oyuncu2.hedef.Y].BackColor = Color.PaleGreen;
                oyuncu2.harcanan_altin += oyunayarlari.B_hedefsecucret;
                oyuncu2.kasaaltin -= oyunayarlari.B_hedefsecucret;
                tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();
                oyuncu2.hedef_varmi = true;
                oyuncu2.yolmatris[oyuncu2.hedef.X, oyuncu2.hedef.Y] = 2;
                Boyuncu_yaz();
                if (oyuncu2.hedef.X == 0 && oyuncu2.hedef.Y == 0)
                {
                    oyuncu2.hedef_varmi = false;
                }
            }
        }

        public void Coyuncuhedefsec()
        {
            if (oyuncu3.kasaaltin < oyunayarlari.C_hedefsecucret || Toplamaltin <= 0)
            {
                oyuncu3.durumu = false;
                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "";
                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                oyuncu3.konum = new Point(alanmatris.GetUpperBound(0), alanmatris.GetUpperBound(1)); oyuncu3.hedef = Point.Empty;
                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                tbx_Ckonum.Text = oyuncu3.konum.ToString();
                tbx_Chedef.Text = oyuncu3.hedef.ToString();
                
            }

            if (oyuncu3.durumu == true && oyuncu3.hedef_varmi == false && Toplamaltin > 0)
            {
                // Gizli altin açma

                for (int m = 0; m < oyunayarlari.C_gizlialtinacma; m++)
                {
                    bool kontrol = false; Point hedef = new Point(0, 0);
                    for (int a = 0; a < oyunayar.Alanboyut.X; a++)
                    {
                        for (int b = 0; b < oyunayar.Alanboyut.Y; b++)
                        {
                            if (alanmatris[a, b] == 2)
                            {
                                kontrol = true;
                            }
                        }
                    }
                    if (kontrol == true)
                    {
                        double yakinolan = double.MaxValue;
                        for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                        {
                            for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                            {
                                if (alanmatris[i, j] == 2)
                                {
                                    double yol_uzaklik = Math.Sqrt(Math.Pow((oyuncu3.konum.X - i), 2) + Math.Pow((oyuncu3.konum.Y - j), 2));

                                    if (yol_uzaklik < yakinolan)
                                    {
                                        yakinolan = yol_uzaklik;
                                        hedef = new Point(i, j);
                                    }
                                }
                            }
                        }
                        buttons[hedef.X, hedef.Y].BackColor = Color.AliceBlue;
                        buttons[hedef.X, hedef.Y].Text = altinmatris[hedef.X, hedef.Y].ToString();
                        alanmatris[hedef.X, hedef.Y] = 1;
                    }
                }

                //***************

                double max_uzaklik = double.MaxValue;

                for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                {
                    for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                    {
                        if (alanmatris[i, j] == 1)
                        {
                            double yol_uzaklik = Math.Sqrt(Math.Pow((oyuncu3.konum.X - i), 2) + Math.Pow((oyuncu3.konum.Y - j), 2));
                            double maliyet = (yol_uzaklik * 5) - altinmatris[i, j];
                            if (maliyet < max_uzaklik)
                            {
                                max_uzaklik = maliyet;
                                oyuncu3.hedef = new Point(i, j);
                            }
                        }
                    }
                }
                tbx_Chedef.Text = oyuncu3.hedef.ToString();
                buttons[oyuncu3.hedef.X, oyuncu3.hedef.Y].BackColor = Color.BurlyWood;
                oyuncu3.harcanan_altin += oyunayarlari.C_hedefsecucret;
                oyuncu3.kasaaltin -= oyunayarlari.C_hedefsecucret;
                tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();
                oyuncu3.hedef_varmi = true;
                oyuncu3.yolmatris[oyuncu3.hedef.X, oyuncu3.hedef.Y] = 2;
                Coyuncu_yaz();
                if (oyuncu3.hedef.X == 0 && oyuncu3.hedef.Y == 0)
                {
                    oyuncu3.hedef_varmi = false;
                }
            }
        }

        public void Doyuncuhedefsec()
        {
            if (oyuncu4.kasaaltin < oyunayarlari.D_hedefsecucret || Toplamaltin <= 0)
            {
                oyuncu4.durumu = false;
                buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "";
                alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                oyuncu4.konum = new Point(alanmatris.GetUpperBound(0),0); oyuncu4.hedef = Point.Empty;
                buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";
                alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                tbx_Dkonum.Text = oyuncu4.konum.ToString();
                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
            }

            if (oyuncu4.durumu == true && oyuncu4.hedef_varmi == false && Toplamaltin > 0)
            {
                double max_uzaklik = double.MaxValue; bool rakiphedef = false;

                // A oyuncunun hedefi D oyuncusunun konuma göre uzaklığı
                int A_hedef_yol = Math.Abs(oyuncu1.konum.X - oyuncu1.hedef.X) + Math.Abs(oyuncu1.konum.Y - oyuncu1.hedef.Y);
                int B_hedef_yol = Math.Abs(oyuncu2.konum.X - oyuncu2.hedef.X) + Math.Abs(oyuncu2.konum.Y - oyuncu2.hedef.Y);
                int C_hedef_yol = Math.Abs(oyuncu3.konum.X - oyuncu3.hedef.X) + Math.Abs(oyuncu3.konum.Y - oyuncu3.hedef.Y);

                int D_Ahedefyol = Math.Abs(oyuncu4.konum.X - oyuncu1.hedef.X) + Math.Abs(oyuncu4.konum.Y - oyuncu1.hedef.Y);
                int D_Bhedefyol = Math.Abs(oyuncu4.konum.X - oyuncu2.hedef.X) + Math.Abs(oyuncu4.konum.Y - oyuncu2.hedef.Y);
                int D_Chedefyol = Math.Abs(oyuncu4.konum.X - oyuncu3.hedef.X) + Math.Abs(oyuncu4.konum.Y - oyuncu3.hedef.Y);

                if (D_Ahedefyol < A_hedef_yol && oyuncu1.hedef.X != 0 && oyuncu1.hedef.Y != 0)
                {
                    rakiphedef = true;
                }
                else if (D_Bhedefyol < B_hedef_yol && oyuncu2.hedef.X != 0 && oyuncu2.hedef.Y != 0)
                {
                    rakiphedef = true;
                }
                else if (D_Chedefyol < C_hedef_yol && oyuncu3.hedef.X != 0 && oyuncu3.hedef.Y != 0)
                {
                    rakiphedef = true;
                }
                else
                {
                    rakiphedef = false;
                }

                if (rakiphedef == true)
                {
                    if (D_Ahedefyol < D_Bhedefyol || D_Ahedefyol < D_Chedefyol)
                    {
                        oyuncu4.hedef = new Point(oyuncu1.hedef.X, oyuncu1.hedef.Y);
                        tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    }
                    if (D_Bhedefyol < D_Ahedefyol || D_Bhedefyol < D_Chedefyol)
                    {
                        oyuncu4.hedef = new Point(oyuncu2.hedef.X, oyuncu2.hedef.Y);
                        tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    }
                    if (D_Chedefyol < D_Ahedefyol || D_Chedefyol < D_Bhedefyol)
                    {
                        oyuncu4.hedef = new Point(oyuncu3.hedef.X, oyuncu3.hedef.Y);
                        tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    }
                    if (D_Ahedefyol == D_Bhedefyol || D_Ahedefyol == D_Chedefyol || D_Bhedefyol == D_Chedefyol)
                    {
                        oyuncu4.hedef = new Point(oyuncu1.hedef.X, oyuncu1.hedef.Y);
                        tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                    {
                        for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                        {
                            if (alanmatris[i, j] == 1)
                            {
                                double yol_uzaklik = Math.Sqrt(Math.Pow((oyuncu4.konum.X - i), 2) + Math.Pow((oyuncu4.konum.Y - j), 2));
                                double maliyet = (yol_uzaklik * 5) - altinmatris[i, j];
                                if (maliyet < max_uzaklik)
                                {
                                    if (oyuncu1.hedef.X != i && oyuncu1.hedef.Y != j 
                                        || oyuncu2.hedef.X != i && oyuncu2.hedef.Y != j 
                                        || oyuncu3.hedef.X != i && oyuncu3.hedef.Y != j)
                                    {
                                        max_uzaklik = maliyet;
                                        oyuncu4.hedef = new Point(i, j);
                                    }
                                    else
                                    {
                                        double max_uzaklik1 = double.MaxValue;
                                        for (int m = 0; m < oyunayar.Alanboyut.X; m++)
                                        {
                                            for (int n = 0; n < oyunayar.Alanboyut.Y; n++)
                                            {
                                                if (alanmatris[m, n] == 1)
                                                {
                                                    double yol_uzaklik1 = Math.Sqrt(Math.Pow((oyuncu4.konum.X - m), 2) + Math.Pow((oyuncu4.konum.Y - n), 2));
                                                    double maliyet1 = (yol_uzaklik1 * 5) - altinmatris[m, n];
                                                    if (maliyet1 < max_uzaklik1)
                                                    {
                                                       
                                                            max_uzaklik1 = maliyet1;
                                                            oyuncu4.hedef = new Point(m, n);                                                     

                                                    }
                                                }
                                            }
                                        }
                                    }
                                   
                                }
                            }
                        }
                    }
                }

                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                buttons[oyuncu4.hedef.X, oyuncu4.hedef.Y].BackColor = Color.Cornsilk;
                oyuncu4.harcanan_altin += oyunayarlari.D_hedefsecucret;
                oyuncu4.kasaaltin -= oyunayarlari.D_hedefsecucret;
                tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();
                oyuncu4.hedef_varmi = true;
                oyuncu4.yolmatris[oyuncu4.hedef.X, oyuncu4.hedef.Y] = 2;
                Doyuncu_yaz();
                if (oyuncu4.hedef.X == 0 && oyuncu4.hedef.Y == 0)
                {
                    oyuncu4.hedef_varmi = false;
                }
                Thread.Sleep(300); this.Refresh();
            }
        }

        //*************

        public void AoyuncuHamleyap()
        {
            if (oyuncu1.kasaaltin < oyunayarlari.hamleucreti || Toplamaltin <= 0)
            {
                oyuncu1.durumu = false;
                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "";
                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                oyuncu1.konum = Point.Empty; oyuncu1.hedef = Point.Empty;
                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                tbx_Akonum.Text = oyuncu1.konum.ToString();
                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
            }
            if (oyuncu1.durumu == true && Toplamaltin > 0)
            {
                int adim_x = Math.Abs(oyuncu1.konum.X - oyuncu1.hedef.X);
                int adim_y = Math.Abs(oyuncu1.konum.Y - oyuncu1.hedef.Y);

                if (adim_x != 0)
                {
                    if (oyuncu1.konum.X < oyuncu1.hedef.X)
                    {
                        buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "";
                        if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 2)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y].ToString();
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                        }
                        if (oyuncu1.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "B";
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        }
                        if (oyuncu1.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "C";
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        }
                        if (oyuncu1.konum == oyuncu4.konum)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "D";
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        }
                        oyuncu1.konum = new Point(oyuncu1.konum.X + 1, oyuncu1.konum.Y);
                        if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 1)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].BackColor = Color.LightGray;
                            oyuncu1.kasaaltin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                            oyuncu1.toplanan_altin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                            tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();

                            if (oyuncu1.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu1.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu3.hedef.ToString();
                            }
                            if (oyuncu1.konum == oyuncu4.hedef)
                            {
                                oyuncu4.hedef_varmi = false;
                                oyuncu4.hedef = Point.Empty;
                                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
                        tbx_Akonum.Text = oyuncu1.konum.ToString();
                        Thread.Sleep(200); this.Refresh();

                    }
                    if (oyuncu1.konum.X > oyuncu1.hedef.X)
                    {
                        buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "";
                        if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 2)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y].ToString();
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                        }
                        if (oyuncu1.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "B";
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        }
                        if (oyuncu1.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "C";
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        }
                        if (oyuncu1.konum == oyuncu4.konum)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "D";
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        }
                        oyuncu1.konum = new Point(oyuncu1.konum.X - 1, oyuncu1.konum.Y);
                        if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 1)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].BackColor = Color.LightGray;
                            oyuncu1.kasaaltin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                            oyuncu1.toplanan_altin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                            tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();

                            if (oyuncu1.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu1.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu3.hedef.ToString();
                            }
                            if (oyuncu1.konum == oyuncu4.hedef)
                            {
                                oyuncu4.hedef_varmi = false;
                                oyuncu4.hedef = Point.Empty;
                                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                        buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
                        tbx_Akonum.Text = oyuncu1.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                }
                if (adim_x == 0)
                {
                    if (adim_y != 0)
                    {
                        if (oyuncu1.konum.Y < oyuncu1.hedef.Y)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "";
                            if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 2)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y].ToString();
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 1;
                            }
                            else
                            {
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                            }
                            if (oyuncu1.konum == oyuncu2.konum)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "B";
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            }
                            if (oyuncu1.konum == oyuncu3.konum)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "C";
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            }
                            if (oyuncu1.konum == oyuncu4.konum)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "D";
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            }
                            oyuncu1.konum = new Point(oyuncu1.konum.X, oyuncu1.konum.Y + 1);
                            if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 1)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].BackColor = Color.LightGray;
                                oyuncu1.kasaaltin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                                oyuncu1.toplanan_altin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                                Toplamaltin -= altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                                altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                                tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();

                                if (oyuncu1.konum == oyuncu2.hedef)
                                {
                                    oyuncu2.hedef_varmi = false;
                                    oyuncu2.hedef = Point.Empty;
                                    tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                                }
                                if (oyuncu1.konum == oyuncu3.hedef)
                                {
                                    oyuncu3.hedef_varmi = false;
                                    oyuncu3.hedef = Point.Empty;
                                    tbx_Chedef.Text = oyuncu3.hedef.ToString();
                                }
                                if (oyuncu1.konum == oyuncu4.hedef)
                                {
                                    oyuncu4.hedef_varmi = false;
                                    oyuncu4.hedef = Point.Empty;
                                    tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                                }
                            }
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
                            tbx_Akonum.Text = oyuncu1.konum.ToString();
                            Thread.Sleep(200); this.Refresh();
                        }
                        if (oyuncu1.konum.Y > oyuncu1.hedef.Y)
                        {
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "";
                            if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 2)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y].ToString();
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 1;
                            }
                            else
                            {
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                            }
                            if (oyuncu1.konum == oyuncu2.konum)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "B";
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            }
                            if (oyuncu1.konum == oyuncu3.konum)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "C";
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            }
                            if (oyuncu1.konum == oyuncu4.konum)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "D";
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            }
                            oyuncu1.konum = new Point(oyuncu1.konum.X, oyuncu1.konum.Y - 1);
                            if (alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] == 1)
                            {
                                buttons[oyuncu1.konum.X, oyuncu1.konum.Y].BackColor = Color.LightGray;
                                oyuncu1.kasaaltin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                                oyuncu1.toplanan_altin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                                Toplamaltin -= altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                                alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                                altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                                tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();

                                if (oyuncu1.konum == oyuncu2.hedef)
                                {
                                    oyuncu2.hedef_varmi = false;
                                    oyuncu2.hedef = Point.Empty;
                                    tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                                }
                                if (oyuncu1.konum == oyuncu3.hedef)
                                {
                                    oyuncu3.hedef_varmi = false;
                                    oyuncu3.hedef = Point.Empty;
                                    tbx_Chedef.Text = oyuncu3.hedef.ToString();
                                }
                                if (oyuncu1.konum == oyuncu4.hedef)
                                {
                                    oyuncu4.hedef_varmi = false;
                                    oyuncu4.hedef = Point.Empty;
                                    tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                                }
                            }
                            alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                            buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
                            tbx_Akonum.Text = oyuncu1.konum.ToString();
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                }
                adim_x = Math.Abs(oyuncu1.konum.X - oyuncu1.hedef.X);
                adim_y = Math.Abs(oyuncu1.konum.Y - oyuncu1.hedef.Y);
                if (adim_x == 0 && adim_y == 0)
                {

                    oyuncu1.kasaaltin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                    oyuncu1.toplanan_altin += altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                    Toplamaltin -= altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y];
                    altinmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 0;
                    alanmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = -1;
                    buttons[oyuncu1.konum.X, oyuncu1.konum.Y].Text = "A";
                    buttons[oyuncu1.konum.X, oyuncu1.konum.Y].BackColor = Color.LightGray;
                    Thread.Sleep(200); this.Refresh();
                    oyuncu1.hedef_varmi = false;
                    oyuncu1.hedef = Point.Empty;
                    tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                    tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();
                    tbx_Akonum.Text = oyuncu1.konum.ToString();

                    if (oyuncu1.konum == oyuncu2.hedef)
                    {
                        oyuncu2.hedef_varmi = false;
                        oyuncu2.hedef = Point.Empty;
                        tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                    }
                    if (oyuncu1.konum == oyuncu3.hedef)
                    {
                        oyuncu3.hedef_varmi = false;
                        oyuncu3.hedef = Point.Empty;
                        tbx_Chedef.Text = oyuncu3.hedef.ToString();
                    }
                    if (oyuncu1.konum == oyuncu4.hedef)
                    {
                        oyuncu4.hedef_varmi = false;
                        oyuncu4.hedef = Point.Empty;
                        tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    }

                }

                oyuncu1.kasaaltin -= oyunayarlari.hamleucreti;
                oyuncu1.harcanan_altin += oyunayarlari.hamleucreti;
                tbx_Abakiye.Text = oyuncu1.kasaaltin.ToString();
                oyuncu1.toplam_adim++;
                oyuncu1.yolmatris[oyuncu1.konum.X, oyuncu1.konum.Y] = 1;
                Aoyuncu_yaz();
            }
        }

        public void BoyuncuHamleyap()
        {
            if (oyuncu2.kasaaltin < oyunayarlari.hamleucreti || Toplamaltin <= 0)
            {
                oyuncu2.durumu = false;
                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "";
                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                oyuncu2.konum = new Point(0, alanmatris.GetUpperBound(1)); oyuncu2.hedef = Point.Empty;
                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                tbx_Bkonum.Text = oyuncu2.konum.ToString();
                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
            }
            if (oyuncu2.durumu == true && Toplamaltin > 0)
            {
                int adim_x = Math.Abs(oyuncu2.konum.X - oyuncu2.hedef.X);
                int adim_y = Math.Abs(oyuncu2.konum.Y - oyuncu2.hedef.Y);

                if (adim_x != 0)
                {
                    if (oyuncu2.konum.X < oyuncu2.hedef.X)
                    {
                        buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "";
                        if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 2)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y].ToString();
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                        }
                        if (oyuncu2.konum == oyuncu1.konum)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "A";
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        }
                        if (oyuncu2.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "C";
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        }
                        if (oyuncu2.konum == oyuncu4.konum)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "D";
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        }
                        oyuncu2.konum = new Point(oyuncu2.konum.X + 1, oyuncu2.konum.Y);
                        if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 1)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].BackColor = Color.LightGray;
                            oyuncu2.kasaaltin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                            oyuncu2.toplanan_altin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                            tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();

                            if (oyuncu2.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu2.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu3.hedef.ToString();
                            }
                            if (oyuncu2.konum == oyuncu4.hedef)
                            {
                                oyuncu4.hedef_varmi = false;
                                oyuncu4.hedef = Point.Empty;
                                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
                        tbx_Bkonum.Text = oyuncu2.konum.ToString();
                        Thread.Sleep(200); this.Refresh();

                    }
                    if (oyuncu2.konum.X > oyuncu2.hedef.X)
                    {
                        buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "";
                        if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 2)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y].ToString();
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                        }
                        if (oyuncu2.konum == oyuncu1.konum)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "A";
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        }
                        if (oyuncu2.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "C";
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        }
                        if (oyuncu2.konum == oyuncu4.konum)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "D";
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        }
                        oyuncu2.konum = new Point(oyuncu2.konum.X - 1, oyuncu2.konum.Y);
                        if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 1)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].BackColor = Color.LightGray;
                            oyuncu2.kasaaltin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                            oyuncu2.toplanan_altin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                            tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();

                            if (oyuncu2.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu2.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu3.hedef.ToString();
                            }
                            if (oyuncu2.konum == oyuncu4.hedef)
                            {
                                oyuncu4.hedef_varmi = false;
                                oyuncu4.hedef = Point.Empty;
                                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                        buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
                        tbx_Bkonum.Text = oyuncu2.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                }
                if (adim_x == 0)
                {
                    if (adim_y != 0)
                    {
                        if (oyuncu2.konum.Y < oyuncu2.hedef.Y)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "";
                            if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 2)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y].ToString();
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 1;
                            }
                            else
                            {
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                            }
                            if (oyuncu2.konum == oyuncu1.konum)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "A";
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            }
                            if (oyuncu2.konum == oyuncu3.konum)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "C";
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            }
                            if (oyuncu2.konum == oyuncu4.konum)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "D";
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            }
                            oyuncu2.konum = new Point(oyuncu2.konum.X, oyuncu2.konum.Y + 1);
                            if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 1)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].BackColor = Color.LightGray;
                                oyuncu2.kasaaltin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                                oyuncu2.toplanan_altin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                                Toplamaltin -= altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                                altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                                tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();

                                if (oyuncu2.konum == oyuncu1.hedef)
                                {
                                    oyuncu1.hedef_varmi = false;
                                    oyuncu1.hedef = Point.Empty;
                                    tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                                }
                                if (oyuncu2.konum == oyuncu3.hedef)
                                {
                                    oyuncu3.hedef_varmi = false;
                                    oyuncu3.hedef = Point.Empty;
                                    tbx_Chedef.Text = oyuncu3.hedef.ToString();
                                }
                                if (oyuncu2.konum == oyuncu4.hedef)
                                {
                                    oyuncu4.hedef_varmi = false;
                                    oyuncu4.hedef = Point.Empty;
                                    tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                                }
                            }
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
                            tbx_Bkonum.Text = oyuncu2.konum.ToString();
                            Thread.Sleep(200); this.Refresh();
                        }
                        if (oyuncu2.konum.Y > oyuncu2.hedef.Y)
                        {
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "";
                            if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 2)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y].ToString();
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 1;
                            }
                            else
                            {
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                            }
                            if (oyuncu2.konum == oyuncu1.konum)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "A";
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            }
                            if (oyuncu2.konum == oyuncu3.konum)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "C";
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            }
                            if (oyuncu2.konum == oyuncu4.konum)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "D";
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            }
                            oyuncu2.konum = new Point(oyuncu2.konum.X, oyuncu2.konum.Y - 1);
                            if (alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] == 1)
                            {
                                buttons[oyuncu2.konum.X, oyuncu2.konum.Y].BackColor = Color.LightGray;
                                oyuncu2.kasaaltin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                                oyuncu2.toplanan_altin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                                Toplamaltin -= altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                                alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                                altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                                tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();

                                if (oyuncu2.konum == oyuncu1.hedef)
                                {
                                    oyuncu1.hedef_varmi = false;
                                    oyuncu1.hedef = Point.Empty;
                                    tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                                }
                                if (oyuncu2.konum == oyuncu3.hedef)
                                {
                                    oyuncu3.hedef_varmi = false;
                                    oyuncu3.hedef = Point.Empty;
                                    tbx_Chedef.Text = oyuncu3.hedef.ToString();
                                }
                                if (oyuncu2.konum == oyuncu4.hedef)
                                {
                                    oyuncu4.hedef_varmi = false;
                                    oyuncu4.hedef = Point.Empty;
                                    tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                                }
                            }
                            alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                            buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
                            tbx_Bkonum.Text = oyuncu2.konum.ToString();
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                }
                adim_x = Math.Abs(oyuncu2.konum.X - oyuncu2.hedef.X);
                adim_y = Math.Abs(oyuncu2.konum.Y - oyuncu2.hedef.Y);
                if (adim_x == 0 && adim_y == 0)
                {

                    oyuncu2.kasaaltin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                    oyuncu2.toplanan_altin += altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                    Toplamaltin -= altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y];
                    altinmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 0;
                    alanmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = -1;
                    buttons[oyuncu2.konum.X, oyuncu2.konum.Y].Text = "B";
                    buttons[oyuncu2.konum.X, oyuncu2.konum.Y].BackColor = Color.LightGray;
                    Thread.Sleep(200); this.Refresh();
                    oyuncu2.hedef_varmi = false;
                    oyuncu2.hedef = Point.Empty;
                    tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                    tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();
                    tbx_Bkonum.Text = oyuncu2.konum.ToString();

                    if (oyuncu2.konum == oyuncu1.hedef)
                    {
                        oyuncu1.hedef_varmi = false;
                        oyuncu1.hedef = Point.Empty;
                        tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                    }
                    if (oyuncu2.konum == oyuncu3.hedef)
                    {
                        oyuncu3.hedef_varmi = false;
                        oyuncu3.hedef = Point.Empty;
                        tbx_Chedef.Text = oyuncu3.hedef.ToString();
                    }
                    if (oyuncu2.konum == oyuncu4.hedef)
                    {
                        oyuncu4.hedef_varmi = false;
                        oyuncu4.hedef = Point.Empty;
                        tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    }

                }

                oyuncu2.kasaaltin -= oyunayarlari.hamleucreti;
                oyuncu2.harcanan_altin += oyunayarlari.hamleucreti;
                tbx_Bbakiye.Text = oyuncu2.kasaaltin.ToString();
                oyuncu2.toplam_adim++;
                oyuncu2.yolmatris[oyuncu2.konum.X, oyuncu2.konum.Y] = 1;
                Boyuncu_yaz();
            }
        }

        public void CoyuncuHamleyap()
        {
            if (oyuncu3.kasaaltin < oyunayarlari.hamleucreti || Toplamaltin <= 0)
            {
                oyuncu3.durumu = false;
                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "";
                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                oyuncu3.konum = new Point(alanmatris.GetUpperBound(0), alanmatris.GetUpperBound(1)); oyuncu3.hedef = Point.Empty;
                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                tbx_Ckonum.Text = oyuncu3.konum.ToString();
                tbx_Chedef.Text = oyuncu3.hedef.ToString();
            }

            if (oyuncu3.durumu == true && Toplamaltin > 0)
            {
                int adim_x = Math.Abs(oyuncu3.konum.X - oyuncu3.hedef.X);
                int adim_y = Math.Abs(oyuncu3.konum.Y - oyuncu3.hedef.Y);

                if (adim_x != 0)
                {
                    if (oyuncu3.konum.X < oyuncu3.hedef.X)
                    {
                        buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "";
                        if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 2)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y].ToString();
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                        }
                        if (oyuncu3.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "B";
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        }
                        if (oyuncu1.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "A";
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        }
                        if (oyuncu3.konum == oyuncu4.konum)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "D";
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        }
                        oyuncu3.konum = new Point(oyuncu3.konum.X + 1, oyuncu3.konum.Y);
                        if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 1)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].BackColor = Color.LightGray;
                            oyuncu3.kasaaltin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                            oyuncu3.toplanan_altin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                            tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();

                            if (oyuncu3.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu3.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu3.konum == oyuncu4.hedef)
                            {
                                oyuncu4.hedef_varmi = false;
                                oyuncu4.hedef = Point.Empty;
                                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
                        tbx_Ckonum.Text = oyuncu3.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                    if (oyuncu3.konum.X > oyuncu3.hedef.X)
                    {
                        buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "";
                        if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 2)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y].ToString();
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                        }
                        if (oyuncu3.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "B";
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        }
                        if (oyuncu3.konum == oyuncu1.konum)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "A";
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        }
                        if (oyuncu3.konum == oyuncu4.konum)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "D";
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        }
                        oyuncu3.konum = new Point(oyuncu3.konum.X - 1, oyuncu3.konum.Y);
                        if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 1)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].BackColor = Color.LightGray;
                            oyuncu3.kasaaltin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                            oyuncu3.toplanan_altin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                            tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();

                            if (oyuncu3.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu3.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu3.konum == oyuncu4.hedef)
                            {
                                oyuncu4.hedef_varmi = false;
                                oyuncu4.hedef = Point.Empty;
                                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                        buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
                        tbx_Ckonum.Text = oyuncu3.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                }
                if (adim_x == 0)
                {
                    if (adim_y != 0)
                    {
                        if (oyuncu3.konum.Y < oyuncu3.hedef.Y)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "";
                            if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 2)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y].ToString();
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 1;
                            }
                            else
                            {
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                            }
                            if (oyuncu3.konum == oyuncu2.konum)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "B";
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            }
                            if (oyuncu3.konum == oyuncu1.konum)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "A";
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            }
                            if (oyuncu3.konum == oyuncu4.konum)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "D";
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            }
                            oyuncu3.konum = new Point(oyuncu3.konum.X, oyuncu3.konum.Y + 1);
                            if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 1)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].BackColor = Color.LightGray;
                                oyuncu3.kasaaltin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                                oyuncu3.toplanan_altin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                                Toplamaltin -= altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                                altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                                tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();

                                if (oyuncu3.konum == oyuncu2.hedef)
                                {
                                    oyuncu2.hedef_varmi = false;
                                    oyuncu2.hedef = Point.Empty;
                                    tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                                }
                                if (oyuncu3.konum == oyuncu1.hedef)
                                {
                                    oyuncu1.hedef_varmi = false;
                                    oyuncu1.hedef = Point.Empty;
                                    tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                                }
                                if (oyuncu3.konum == oyuncu4.hedef)
                                {
                                    oyuncu4.hedef_varmi = false;
                                    oyuncu4.hedef = Point.Empty;
                                    tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                                }
                            }
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
                            tbx_Ckonum.Text = oyuncu3.konum.ToString();
                            Thread.Sleep(200); this.Refresh();
                        }
                        if (oyuncu3.konum.Y > oyuncu3.hedef.Y)
                        {
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "";
                            if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 2)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y].ToString();
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 1;
                            }
                            else
                            {
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                            }
                            if (oyuncu3.konum == oyuncu2.konum)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "B";
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            }
                            if (oyuncu3.konum == oyuncu1.konum)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "A";
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            }
                            if (oyuncu3.konum == oyuncu4.konum)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "D";
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            }
                            oyuncu3.konum = new Point(oyuncu3.konum.X, oyuncu3.konum.Y - 1);
                            if (alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] == 1)
                            {
                                buttons[oyuncu3.konum.X, oyuncu3.konum.Y].BackColor = Color.LightGray;
                                oyuncu3.kasaaltin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                                oyuncu3.toplanan_altin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                                Toplamaltin -= altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                                alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                                altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                                tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();

                                if (oyuncu3.konum == oyuncu2.hedef)
                                {
                                    oyuncu2.hedef_varmi = false;
                                    oyuncu2.hedef = Point.Empty;
                                    tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                                }
                                if (oyuncu3.konum == oyuncu1.hedef)
                                {
                                    oyuncu1.hedef_varmi = false;
                                    oyuncu1.hedef = Point.Empty;
                                    tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                                }
                                if (oyuncu3.konum == oyuncu4.hedef)
                                {
                                    oyuncu4.hedef_varmi = false;
                                    oyuncu4.hedef = Point.Empty;
                                    tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                                }
                            }
                            alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                            buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
                            tbx_Ckonum.Text = oyuncu3.konum.ToString();
                            Thread.Sleep(200); this.Refresh();
                        }
                    }
                }
                adim_x = Math.Abs(oyuncu3.konum.X - oyuncu3.hedef.X);
                adim_y = Math.Abs(oyuncu3.konum.Y - oyuncu3.hedef.Y);

                if (adim_x == 0 && adim_y == 0)
                {
                    oyuncu3.kasaaltin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                    oyuncu3.toplanan_altin += altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                    Toplamaltin -= altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y];
                    altinmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 0;
                    alanmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = -1;
                    buttons[oyuncu3.konum.X, oyuncu3.konum.Y].Text = "C";
                    buttons[oyuncu3.konum.X, oyuncu3.konum.Y].BackColor = Color.LightGray;
                    Thread.Sleep(200); this.Refresh();
                    oyuncu3.hedef_varmi = false;
                    oyuncu3.hedef = Point.Empty;
                    tbx_Chedef.Text = oyuncu3.hedef.ToString();
                    tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();
                    tbx_Ckonum.Text = oyuncu3.konum.ToString();

                    if (oyuncu3.konum == oyuncu2.hedef)
                    {
                        oyuncu2.hedef_varmi = false;
                        oyuncu2.hedef = Point.Empty;
                        tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                    }
                    if (oyuncu3.konum == oyuncu1.hedef)
                    {
                        oyuncu1.hedef_varmi = false;
                        oyuncu1.hedef = Point.Empty;
                        tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                    }
                    if (oyuncu3.konum == oyuncu4.hedef)
                    {
                        oyuncu4.hedef_varmi = false;
                        oyuncu4.hedef = Point.Empty;
                        tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    }
                }

                oyuncu3.kasaaltin -= oyunayarlari.hamleucreti;
                oyuncu3.harcanan_altin += oyunayarlari.hamleucreti;
                tbx_Cbakiye.Text = oyuncu3.kasaaltin.ToString();
                oyuncu3.toplam_adim++;
                oyuncu3.yolmatris[oyuncu3.konum.X, oyuncu3.konum.Y] = 1;
                Coyuncu_yaz();
            }
        }

        public void DoyuncuHamleyap()
        {

            if (oyuncu4.kasaaltin < oyunayarlari.hamleucreti || Toplamaltin <= 0)
            {
                oyuncu4.durumu = false;
                buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "";
                alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                oyuncu4.konum = new Point(alanmatris.GetUpperBound(0), 0); oyuncu4.hedef = Point.Empty;
                buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";
                alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                tbx_Dkonum.Text = oyuncu4.konum.ToString();
                tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                MessageBox.Show("D Oyuncusu Kaybetti");
            }
            if (oyuncu4.durumu == true && Toplamaltin > 0)
            {
                int adim_x = Math.Abs(oyuncu4.konum.X - oyuncu4.hedef.X);
                int adim_y = Math.Abs(oyuncu4.konum.Y - oyuncu4.hedef.Y);

                if (adim_x != 0)
                {
                    if (oyuncu4.konum.X < oyuncu4.hedef.X)
                    {
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "";
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 2)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y].ToString();
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                        }
                        if (oyuncu4.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "B";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "C";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu1.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "A";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        oyuncu4.konum = new Point(oyuncu4.konum.X + 1, oyuncu4.konum.Y);
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 1)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].BackColor = Color.LightGray;
                            oyuncu4.kasaaltin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            oyuncu4.toplanan_altin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                            altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                            tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();

                            if (oyuncu4.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";
                        tbx_Dkonum.Text = oyuncu4.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                    if (oyuncu4.konum.X > oyuncu4.hedef.X)
                    {
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "";
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 2)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y].ToString();
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                        }
                        if (oyuncu4.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "B";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "C";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu1.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "A";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        oyuncu4.konum = new Point(oyuncu4.konum.X - 1, oyuncu4.konum.Y);
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 1)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].BackColor = Color.LightGray;
                            oyuncu4.kasaaltin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            oyuncu4.toplanan_altin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                            altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                            tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();

                            if (oyuncu4.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";
                        tbx_Dkonum.Text = oyuncu4.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                }
                if (adim_x == 0)
                {
                    if (oyuncu4.konum.Y < oyuncu4.hedef.Y)
                    {
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "";
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 2)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y].ToString();
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                        }
                        if (oyuncu4.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "B";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "C";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu1.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "A";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        oyuncu4.konum = new Point(oyuncu4.konum.X, oyuncu4.konum.Y + 1);
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 1)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].BackColor = Color.LightGray;
                            oyuncu4.kasaaltin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            oyuncu4.toplanan_altin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                            altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                            tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();

                            if (oyuncu4.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";
                        tbx_Dkonum.Text = oyuncu4.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                    if (oyuncu4.konum.Y > oyuncu4.hedef.Y)
                    {
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "";
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 2)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y].ToString();
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 1;
                        }
                        else
                        {
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                        }
                        if (oyuncu4.konum == oyuncu2.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "B";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu3.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "C";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        if (oyuncu4.konum == oyuncu1.konum)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "A";
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        }
                        oyuncu4.konum = new Point(oyuncu4.konum.X, oyuncu4.konum.Y - 1);
                        if (alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] == 1)
                        {
                            buttons[oyuncu4.konum.X, oyuncu4.konum.Y].BackColor = Color.LightGray;
                            oyuncu4.kasaaltin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            oyuncu4.toplanan_altin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            Toplamaltin -= altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                            alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                            altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                            tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();

                            if (oyuncu4.konum == oyuncu2.hedef)
                            {
                                oyuncu2.hedef_varmi = false;
                                oyuncu2.hedef = Point.Empty;
                                tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu1.hedef)
                            {
                                oyuncu1.hedef_varmi = false;
                                oyuncu1.hedef = Point.Empty;
                                tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                            }
                            if (oyuncu4.konum == oyuncu3.hedef)
                            {
                                oyuncu3.hedef_varmi = false;
                                oyuncu3.hedef = Point.Empty;
                                tbx_Chedef.Text = oyuncu4.hedef.ToString();
                            }
                        }
                        alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                        buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";
                        tbx_Dkonum.Text = oyuncu4.konum.ToString();
                        Thread.Sleep(200); this.Refresh();
                    }
                }

                adim_x = Math.Abs(oyuncu4.konum.X - oyuncu4.hedef.X);
                adim_y = Math.Abs(oyuncu4.konum.Y - oyuncu4.hedef.Y);


                if (adim_x == 0 && adim_y == 0)
                {
                    oyuncu4.kasaaltin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                    oyuncu4.toplanan_altin += altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                    Toplamaltin -= altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y];
                    altinmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 0;
                    alanmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = -1;
                    buttons[oyuncu4.konum.X, oyuncu4.konum.Y].Text = "D";
                    buttons[oyuncu4.konum.X, oyuncu4.konum.Y].BackColor = Color.LightGray;
                    Thread.Sleep(200); this.Refresh();
                    oyuncu4.hedef_varmi = false;
                    oyuncu4.hedef = Point.Empty;
                    tbx_Dhedef.Text = oyuncu4.hedef.ToString();
                    tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();
                    tbx_Dkonum.Text = oyuncu4.konum.ToString();

                    if (oyuncu4.konum == oyuncu2.hedef)
                    {
                        oyuncu2.hedef_varmi = false;
                        oyuncu2.hedef = Point.Empty;
                        tbx_Bhedef.Text = oyuncu2.hedef.ToString();
                    }
                    if (oyuncu4.konum == oyuncu1.hedef)
                    {
                        oyuncu1.hedef_varmi = false;
                        oyuncu1.hedef = Point.Empty;
                        tbx_Ahedef.Text = oyuncu1.hedef.ToString();
                    }
                    if (oyuncu4.konum == oyuncu3.hedef)
                    {
                        oyuncu3.hedef_varmi = false;
                        oyuncu3.hedef = Point.Empty;
                        tbx_Chedef.Text = oyuncu4.hedef.ToString();
                    }
                }
                oyuncu4.kasaaltin -= oyunayarlari.hamleucreti;
                oyuncu4.harcanan_altin += oyunayarlari.hamleucreti;
                tbx_Dbakiye.Text = oyuncu4.kasaaltin.ToString();
                oyuncu4.toplam_adim++;
                oyuncu4.yolmatris[oyuncu4.konum.X, oyuncu4.konum.Y] = 1;
                Doyuncu_yaz();
            }

        }
        // Dosyaya Yazma

        public void Aoyuncu_yaz()
        {
            StreamWriter sw = new StreamWriter(@"A.txt", true);

            try
            {
                sw.Write("*****A Oyuncu*****");
                sw.WriteLine();
                sw.Write("Konum: {0} ", oyuncu1.konum.ToString());
                sw.Write("Hedef: {0} ", oyuncu1.hedef.ToString());
                sw.WriteLine();
                for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                {
                    for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                    {
                        sw.Write(oyuncu1.yolmatris[i,j].ToString());
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun var" + ex);
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
        }

        public void Boyuncu_yaz()
        {
            StreamWriter sw = new StreamWriter(@"B.txt", true);

            try
            {
                sw.Write("*****B Oyuncu*****");
                sw.WriteLine();
                sw.Write("Konum: {0} ", oyuncu2.konum.ToString());
                sw.Write("Hedef: {0}", oyuncu2.hedef.ToString());
                sw.WriteLine();
                for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                {
                    for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                    {
                        sw.Write(oyuncu2.yolmatris[i, j].ToString());
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun var" + ex);
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
        }
        public void Coyuncu_yaz()
        {
            StreamWriter sw = new StreamWriter(@"C.txt", true);

            try
            {
                sw.Write("*****C Oyuncu*****");
                sw.WriteLine();
                sw.Write("Konum: {0}", oyuncu3.konum.ToString());
                sw.Write("Hedef: {0}", oyuncu3.hedef.ToString());
                sw.WriteLine();
                for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                {
                    for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                    {
                        sw.Write(oyuncu3.yolmatris[i, j].ToString());
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun var" + ex);
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
        }

        public void Doyuncu_yaz()
        {
            StreamWriter sw = new StreamWriter(@"D.txt", true);

            try
            {
                sw.Write("*****D Oyuncu*****");
                sw.WriteLine();
                sw.Write("Konum: {0}", oyuncu4.konum.ToString());
                sw.Write("Hedef: {0}", oyuncu4.hedef.ToString());
                sw.WriteLine();
                for (int i = 0; i < oyunayar.Alanboyut.X; i++)
                {
                    for (int j = 0; j < oyunayar.Alanboyut.Y; j++)
                    {
                        sw.Write(oyuncu4.yolmatris[i, j].ToString());
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun var" + ex);
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
        }
    }
}
