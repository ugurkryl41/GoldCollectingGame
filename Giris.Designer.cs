namespace MyGame4
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.btn_yenioyun = new System.Windows.Forms.Button();
            this.btn_ayarlar = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_yenioyun
            // 
            this.btn_yenioyun.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_yenioyun.Location = new System.Drawing.Point(288, 131);
            this.btn_yenioyun.Name = "btn_yenioyun";
            this.btn_yenioyun.Size = new System.Drawing.Size(161, 52);
            this.btn_yenioyun.TabIndex = 0;
            this.btn_yenioyun.Text = "Yeni Oyun";
            this.btn_yenioyun.UseVisualStyleBackColor = false;
            this.btn_yenioyun.Click += new System.EventHandler(this.btn_yenioyun_Click);
            // 
            // btn_ayarlar
            // 
            this.btn_ayarlar.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_ayarlar.Location = new System.Drawing.Point(288, 203);
            this.btn_ayarlar.Name = "btn_ayarlar";
            this.btn_ayarlar.Size = new System.Drawing.Size(161, 52);
            this.btn_ayarlar.TabIndex = 1;
            this.btn_ayarlar.Text = "Ayarlar";
            this.btn_ayarlar.UseVisualStyleBackColor = false;
            this.btn_ayarlar.Click += new System.EventHandler(this.btn_ayarlar_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_exit.Location = new System.Drawing.Point(288, 275);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(161, 52);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Oyundan Çık";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(743, 532);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_ayarlar);
            this.Controls.Add(this.btn_yenioyun);
            this.Name = "Giris";
            this.Text = "Altın Toplama Oyunu";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_yenioyun;
        private System.Windows.Forms.Button btn_ayarlar;
        private System.Windows.Forms.Button btn_exit;
    }
}

