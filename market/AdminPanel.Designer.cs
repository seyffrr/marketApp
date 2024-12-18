namespace market
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_cikis = new System.Windows.Forms.Button();
            this.btn_urunler = new System.Windows.Forms.Button();
            this.btn_kullanici = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "Hopstarter-Sleek-Xp-Basic-User-Group.ico");
            this.ımageList1.Images.SetKeyName(1, "iconfinder_Shipping8_62597.ico");
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "cikis.ico");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(32, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcılar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(216, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürünler";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(106, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "HOŞGELDİNİZ";
            // 
            // btn_cikis
            // 
            this.btn_cikis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_cikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cikis.ImageKey = "cikis.ico";
            this.btn_cikis.ImageList = this.ımageList2;
            this.btn_cikis.Location = new System.Drawing.Point(219, 221);
            this.btn_cikis.Name = "btn_cikis";
            this.btn_cikis.Size = new System.Drawing.Size(89, 35);
            this.btn_cikis.TabIndex = 0;
            this.btn_cikis.Text = "Çıkış";
            this.btn_cikis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cikis.UseVisualStyleBackColor = true;
            this.btn_cikis.Click += new System.EventHandler(this.btn_cikis_Click);
            // 
            // btn_urunler
            // 
            this.btn_urunler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_urunler.ImageKey = "iconfinder_Shipping8_62597.ico";
            this.btn_urunler.ImageList = this.ımageList1;
            this.btn_urunler.Location = new System.Drawing.Point(176, 61);
            this.btn_urunler.Name = "btn_urunler";
            this.btn_urunler.Size = new System.Drawing.Size(132, 122);
            this.btn_urunler.TabIndex = 0;
            this.btn_urunler.UseVisualStyleBackColor = true;
            this.btn_urunler.Click += new System.EventHandler(this.btn_urunler_Click);
            // 
            // btn_kullanici
            // 
            this.btn_kullanici.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_kullanici.ImageKey = "Hopstarter-Sleek-Xp-Basic-User-Group.ico";
            this.btn_kullanici.ImageList = this.ımageList1;
            this.btn_kullanici.Location = new System.Drawing.Point(12, 61);
            this.btn_kullanici.Name = "btn_kullanici";
            this.btn_kullanici.Size = new System.Drawing.Size(132, 122);
            this.btn_kullanici.TabIndex = 0;
            this.btn_kullanici.UseVisualStyleBackColor = true;
            this.btn_kullanici.Click += new System.EventHandler(this.btn_kullanici_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 268);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cikis);
            this.Controls.Add(this.btn_urunler);
            this.Controls.Add(this.btn_kullanici);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_kullanici;
        private System.Windows.Forms.Button btn_urunler;
        private System.Windows.Forms.Button btn_cikis;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}