namespace market
{
    partial class SifreDegistirme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreDegistirme));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txt_guvenlikCevabi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBox_guvenlikSorusu = new System.Windows.Forms.ComboBox();
            this.txt_kullaniciAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            this.grpBox_mailAlani = new System.Windows.Forms.GroupBox();
            this.btn_onayla = new System.Windows.Forms.Button();
            this.txt_dogrulamaKodu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_dogrulamaGonder = new System.Windows.Forms.Button();
            this.txt_emailAdres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpBox_sifreDegistirmeAlani = new System.Windows.Forms.GroupBox();
            this.btn_degistir = new System.Windows.Forms.Button();
            this.txt_yeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_yeniSifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpBox_mailAlani.SuspendLayout();
            this.grpBox_sifreDegistirmeAlani.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_guvenlikCevabi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbBox_guvenlikSorusu);
            this.groupBox1.Controls.Add(this.txt_kullaniciAdi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Güvenlik Sorusu İle Değiştir";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageKey = "cikis.ico";
            this.button2.ImageList = this.ımageList1;
            this.button2.Location = new System.Drawing.Point(196, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Çıkış";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "cikis.ico");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Sorgula";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_guvenlikCevabi
            // 
            this.txt_guvenlikCevabi.Location = new System.Drawing.Point(110, 120);
            this.txt_guvenlikCevabi.Name = "txt_guvenlikCevabi";
            this.txt_guvenlikCevabi.PasswordChar = '*';
            this.txt_guvenlikCevabi.Size = new System.Drawing.Size(143, 20);
            this.txt_guvenlikCevabi.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Güvenlik Cevabı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Güvenlik Sorusu:";
            // 
            // cmbBox_guvenlikSorusu
            // 
            this.cmbBox_guvenlikSorusu.FormattingEnabled = true;
            this.cmbBox_guvenlikSorusu.Location = new System.Drawing.Point(110, 77);
            this.cmbBox_guvenlikSorusu.Name = "cmbBox_guvenlikSorusu";
            this.cmbBox_guvenlikSorusu.Size = new System.Drawing.Size(143, 21);
            this.cmbBox_guvenlikSorusu.TabIndex = 1;
            // 
            // txt_kullaniciAdi
            // 
            this.txt_kullaniciAdi.Location = new System.Drawing.Point(110, 30);
            this.txt_kullaniciAdi.Name = "txt_kullaniciAdi";
            this.txt_kullaniciAdi.Size = new System.Drawing.Size(143, 20);
            this.txt_kullaniciAdi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // grpBox_mailAlani
            // 
            this.grpBox_mailAlani.Controls.Add(this.btn_onayla);
            this.grpBox_mailAlani.Controls.Add(this.txt_dogrulamaKodu);
            this.grpBox_mailAlani.Controls.Add(this.label5);
            this.grpBox_mailAlani.Controls.Add(this.btn_dogrulamaGonder);
            this.grpBox_mailAlani.Controls.Add(this.txt_emailAdres);
            this.grpBox_mailAlani.Controls.Add(this.label4);
            this.grpBox_mailAlani.Location = new System.Drawing.Point(324, 12);
            this.grpBox_mailAlani.Name = "grpBox_mailAlani";
            this.grpBox_mailAlani.Size = new System.Drawing.Size(323, 160);
            this.grpBox_mailAlani.TabIndex = 1;
            this.grpBox_mailAlani.TabStop = false;
            this.grpBox_mailAlani.Text = "Mail Alanı";
            // 
            // btn_onayla
            // 
            this.btn_onayla.Location = new System.Drawing.Point(203, 104);
            this.btn_onayla.Name = "btn_onayla";
            this.btn_onayla.Size = new System.Drawing.Size(104, 23);
            this.btn_onayla.TabIndex = 7;
            this.btn_onayla.Text = "Onayla";
            this.btn_onayla.UseVisualStyleBackColor = true;
            this.btn_onayla.Click += new System.EventHandler(this.btn_onayla_Click);
            // 
            // txt_dogrulamaKodu
            // 
            this.txt_dogrulamaKodu.Location = new System.Drawing.Point(115, 106);
            this.txt_dogrulamaKodu.Name = "txt_dogrulamaKodu";
            this.txt_dogrulamaKodu.Size = new System.Drawing.Size(82, 20);
            this.txt_dogrulamaKodu.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Doğrulama Kodu";
            // 
            // btn_dogrulamaGonder
            // 
            this.btn_dogrulamaGonder.Location = new System.Drawing.Point(163, 67);
            this.btn_dogrulamaGonder.Name = "btn_dogrulamaGonder";
            this.btn_dogrulamaGonder.Size = new System.Drawing.Size(144, 23);
            this.btn_dogrulamaGonder.TabIndex = 4;
            this.btn_dogrulamaGonder.Text = "Doğrulama Kodu Gönder";
            this.btn_dogrulamaGonder.UseVisualStyleBackColor = true;
            this.btn_dogrulamaGonder.Click += new System.EventHandler(this.btn_dogrulamaGonder_Click);
            // 
            // txt_emailAdres
            // 
            this.txt_emailAdres.Location = new System.Drawing.Point(115, 30);
            this.txt_emailAdres.Name = "txt_emailAdres";
            this.txt_emailAdres.Size = new System.Drawing.Size(192, 20);
            this.txt_emailAdres.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "E-Mail Adresiniz:";
            // 
            // grpBox_sifreDegistirmeAlani
            // 
            this.grpBox_sifreDegistirmeAlani.Controls.Add(this.btn_degistir);
            this.grpBox_sifreDegistirmeAlani.Controls.Add(this.txt_yeniSifreTekrar);
            this.grpBox_sifreDegistirmeAlani.Controls.Add(this.label7);
            this.grpBox_sifreDegistirmeAlani.Controls.Add(this.txt_yeniSifre);
            this.grpBox_sifreDegistirmeAlani.Controls.Add(this.label6);
            this.grpBox_sifreDegistirmeAlani.Location = new System.Drawing.Point(324, 178);
            this.grpBox_sifreDegistirmeAlani.Name = "grpBox_sifreDegistirmeAlani";
            this.grpBox_sifreDegistirmeAlani.Size = new System.Drawing.Size(323, 108);
            this.grpBox_sifreDegistirmeAlani.TabIndex = 5;
            this.grpBox_sifreDegistirmeAlani.TabStop = false;
            this.grpBox_sifreDegistirmeAlani.Text = "Şifre Değiştirme Alanı";
            // 
            // btn_degistir
            // 
            this.btn_degistir.Location = new System.Drawing.Point(203, 78);
            this.btn_degistir.Name = "btn_degistir";
            this.btn_degistir.Size = new System.Drawing.Size(104, 23);
            this.btn_degistir.TabIndex = 8;
            this.btn_degistir.Text = "Değiştir";
            this.btn_degistir.UseVisualStyleBackColor = true;
            this.btn_degistir.Click += new System.EventHandler(this.btn_degistir_Click);
            // 
            // txt_yeniSifreTekrar
            // 
            this.txt_yeniSifreTekrar.Location = new System.Drawing.Point(115, 52);
            this.txt_yeniSifreTekrar.Name = "txt_yeniSifreTekrar";
            this.txt_yeniSifreTekrar.PasswordChar = '*';
            this.txt_yeniSifreTekrar.Size = new System.Drawing.Size(192, 20);
            this.txt_yeniSifreTekrar.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Yeni Şifre Tekrar";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txt_yeniSifre
            // 
            this.txt_yeniSifre.Location = new System.Drawing.Point(115, 26);
            this.txt_yeniSifre.Name = "txt_yeniSifre";
            this.txt_yeniSifre.PasswordChar = '*';
            this.txt_yeniSifre.Size = new System.Drawing.Size(192, 20);
            this.txt_yeniSifre.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Yeni Şifre";
            // 
            // SifreDegistirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 295);
            this.Controls.Add(this.grpBox_sifreDegistirmeAlani);
            this.Controls.Add(this.grpBox_mailAlani);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SifreDegistirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SifreDegistirme";
            this.Load += new System.EventHandler(this.SifreDegistirme_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBox_mailAlani.ResumeLayout(false);
            this.grpBox_mailAlani.PerformLayout();
            this.grpBox_sifreDegistirmeAlani.ResumeLayout(false);
            this.grpBox_sifreDegistirmeAlani.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBox_guvenlikSorusu;
        private System.Windows.Forms.TextBox txt_kullaniciAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_guvenlikCevabi;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpBox_mailAlani;
        private System.Windows.Forms.Button btn_dogrulamaGonder;
        private System.Windows.Forms.TextBox txt_emailAdres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpBox_sifreDegistirmeAlani;
        private System.Windows.Forms.Button btn_onayla;
        private System.Windows.Forms.TextBox txt_dogrulamaKodu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_yeniSifreTekrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_yeniSifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_degistir;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button button2;
    }
}