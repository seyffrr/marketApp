namespace market
{
    partial class KasiyerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KasiyerPanel));
            this.btn_et = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bts_sut = new System.Windows.Forms.Button();
            this.btn_baklagil = new System.Windows.Forms.Button();
            this.btn_meyveSebze = new System.Windows.Forms.Button();
            this.btn_cikis = new System.Windows.Forms.Button();
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btn_et
            // 
            this.btn_et.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_et.ImageIndex = 2;
            this.btn_et.ImageList = this.ımageList1;
            this.btn_et.Location = new System.Drawing.Point(30, 30);
            this.btn_et.Name = "btn_et";
            this.btn_et.Size = new System.Drawing.Size(149, 152);
            this.btn_et.TabIndex = 0;
            this.btn_et.UseVisualStyleBackColor = true;
            this.btn_et.Click += new System.EventHandler(this.btn_et_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "exit.png");
            this.ımageList1.Images.SetKeyName(1, "baklagil.ico");
            this.ımageList1.Images.SetKeyName(2, "et.ico");
            this.ımageList1.Images.SetKeyName(3, "meyveAndsebze.ico");
            this.ımageList1.Images.SetKeyName(4, "süt.ico");
            // 
            // bts_sut
            // 
            this.bts_sut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bts_sut.ImageIndex = 4;
            this.bts_sut.ImageList = this.ımageList1;
            this.bts_sut.Location = new System.Drawing.Point(213, 30);
            this.bts_sut.Name = "bts_sut";
            this.bts_sut.Size = new System.Drawing.Size(149, 152);
            this.bts_sut.TabIndex = 1;
            this.bts_sut.UseVisualStyleBackColor = true;
            // 
            // btn_baklagil
            // 
            this.btn_baklagil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_baklagil.ImageKey = "baklagil.ico";
            this.btn_baklagil.ImageList = this.ımageList1;
            this.btn_baklagil.Location = new System.Drawing.Point(30, 226);
            this.btn_baklagil.Name = "btn_baklagil";
            this.btn_baklagil.Size = new System.Drawing.Size(149, 152);
            this.btn_baklagil.TabIndex = 2;
            this.btn_baklagil.UseVisualStyleBackColor = true;
            // 
            // btn_meyveSebze
            // 
            this.btn_meyveSebze.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_meyveSebze.ImageIndex = 3;
            this.btn_meyveSebze.ImageList = this.ımageList1;
            this.btn_meyveSebze.Location = new System.Drawing.Point(213, 226);
            this.btn_meyveSebze.Name = "btn_meyveSebze";
            this.btn_meyveSebze.Size = new System.Drawing.Size(149, 152);
            this.btn_meyveSebze.TabIndex = 3;
            this.btn_meyveSebze.UseVisualStyleBackColor = true;
            this.btn_meyveSebze.Click += new System.EventHandler(this.btn_meyveSebze_Click);
            // 
            // btn_cikis
            // 
            this.btn_cikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_cikis.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_cikis.ImageKey = "exit.png";
            this.btn_cikis.ImageList = this.ımageList2;
            this.btn_cikis.Location = new System.Drawing.Point(270, 412);
            this.btn_cikis.Name = "btn_cikis";
            this.btn_cikis.Size = new System.Drawing.Size(92, 27);
            this.btn_cikis.TabIndex = 4;
            this.btn_cikis.Text = "Çıkış Yap";
            this.btn_cikis.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_cikis.UseVisualStyleBackColor = true;
            this.btn_cikis.Click += new System.EventHandler(this.btn_cikis_Click);
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "exit.png");
            // 
            // KasiyerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 452);
            this.Controls.Add(this.btn_cikis);
            this.Controls.Add(this.btn_meyveSebze);
            this.Controls.Add(this.btn_baklagil);
            this.Controls.Add(this.bts_sut);
            this.Controls.Add(this.btn_et);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KasiyerPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KasiyerPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_et;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button bts_sut;
        private System.Windows.Forms.Button btn_baklagil;
        private System.Windows.Forms.Button btn_meyveSebze;
        private System.Windows.Forms.Button btn_cikis;
        private System.Windows.Forms.ImageList ımageList2;
    }
}