namespace DOAN_WF.GUI
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.panel_login = new System.Windows.Forms.Panel();
            this.panel_login2 = new System.Windows.Forms.Panel();
            this.panel_matkhau = new System.Windows.Forms.Panel();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ckb_hienmatkhau = new System.Windows.Forms.CheckBox();
            this.panel_tendangnhap = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_tendangnhap = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.llbl_quenmatkhau = new System.Windows.Forms.LinkLabel();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel_login.SuspendLayout();
            this.panel_login2.SuspendLayout();
            this.panel_matkhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_tendangnhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_login
            // 
            this.panel_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_login.BackgroundImage")));
            this.panel_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_login.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_login.Controls.Add(this.panel_login2);
            this.panel_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_login.Location = new System.Drawing.Point(0, 0);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(1200, 658);
            this.panel_login.TabIndex = 0;
            // 
            // panel_login2
            // 
            this.panel_login2.BackColor = System.Drawing.Color.White;
            this.panel_login2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_login2.Controls.Add(this.panel_matkhau);
            this.panel_login2.Controls.Add(this.ckb_hienmatkhau);
            this.panel_login2.Controls.Add(this.panel_tendangnhap);
            this.panel_login2.Controls.Add(this.btn_dangnhap);
            this.panel_login2.Controls.Add(this.llbl_quenmatkhau);
            this.panel_login2.Controls.Add(this.pictureBox_logo);
            this.panel_login2.Location = new System.Drawing.Point(453, 137);
            this.panel_login2.Name = "panel_login2";
            this.panel_login2.Size = new System.Drawing.Size(333, 400);
            this.panel_login2.TabIndex = 0;
            // 
            // panel_matkhau
            // 
            this.panel_matkhau.BackColor = System.Drawing.Color.White;
            this.panel_matkhau.Controls.Add(this.txt_matkhau);
            this.panel_matkhau.Controls.Add(this.panel4);
            this.panel_matkhau.Controls.Add(this.pictureBox2);
            this.panel_matkhau.Location = new System.Drawing.Point(3, 200);
            this.panel_matkhau.Name = "panel_matkhau";
            this.panel_matkhau.Size = new System.Drawing.Size(319, 46);
            this.panel_matkhau.TabIndex = 2;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_matkhau.Location = new System.Drawing.Point(50, 13);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.PasswordChar = '*';
            this.txt_matkhau.Size = new System.Drawing.Size(254, 23);
            this.txt_matkhau.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.panel4.Location = new System.Drawing.Point(47, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 1);
            this.panel4.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // ckb_hienmatkhau
            // 
            this.ckb_hienmatkhau.AutoSize = true;
            this.ckb_hienmatkhau.BackColor = System.Drawing.Color.Transparent;
            this.ckb_hienmatkhau.Location = new System.Drawing.Point(185, 266);
            this.ckb_hienmatkhau.Name = "ckb_hienmatkhau";
            this.ckb_hienmatkhau.Size = new System.Drawing.Size(144, 26);
            this.ckb_hienmatkhau.TabIndex = 3;
            this.ckb_hienmatkhau.Text = "Hiện mật khẩu";
            this.ckb_hienmatkhau.UseVisualStyleBackColor = false;
            this.ckb_hienmatkhau.CheckedChanged += new System.EventHandler(this.ckb_ghinholansau_CheckedChanged);
            // 
            // panel_tendangnhap
            // 
            this.panel_tendangnhap.BackColor = System.Drawing.Color.White;
            this.panel_tendangnhap.Controls.Add(this.pictureBox1);
            this.panel_tendangnhap.Controls.Add(this.txt_tendangnhap);
            this.panel_tendangnhap.Controls.Add(this.panel2);
            this.panel_tendangnhap.Location = new System.Drawing.Point(3, 148);
            this.panel_tendangnhap.Name = "panel_tendangnhap";
            this.panel_tendangnhap.Size = new System.Drawing.Size(319, 46);
            this.panel_tendangnhap.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txt_tendangnhap
            // 
            this.txt_tendangnhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_tendangnhap.Location = new System.Drawing.Point(52, 14);
            this.txt_tendangnhap.Name = "txt_tendangnhap";
            this.txt_tendangnhap.Size = new System.Drawing.Size(254, 23);
            this.txt_tendangnhap.TabIndex = 0;
            this.txt_tendangnhap.Tag = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.panel2.Location = new System.Drawing.Point(47, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 1);
            this.panel2.TabIndex = 4;
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_dangnhap.FlatAppearance.BorderSize = 0;
            this.btn_dangnhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btn_dangnhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btn_dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dangnhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_dangnhap.ForeColor = System.Drawing.Color.White;
            this.btn_dangnhap.Location = new System.Drawing.Point(52, 298);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(241, 44);
            this.btn_dangnhap.TabIndex = 4;
            this.btn_dangnhap.Text = "Đăng Nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = false;
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click_1);
            // 
            // llbl_quenmatkhau
            // 
            this.llbl_quenmatkhau.AutoSize = true;
            this.llbl_quenmatkhau.BackColor = System.Drawing.Color.Transparent;
            this.llbl_quenmatkhau.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.llbl_quenmatkhau.Location = new System.Drawing.Point(124, 357);
            this.llbl_quenmatkhau.Name = "llbl_quenmatkhau";
            this.llbl_quenmatkhau.Size = new System.Drawing.Size(134, 22);
            this.llbl_quenmatkhau.TabIndex = 5;
            this.llbl_quenmatkhau.TabStop = true;
            this.llbl_quenmatkhau.Text = "Quên mật khẩu?";
            this.llbl_quenmatkhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_quenmatkhau_LinkClicked);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(75, 13);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(183, 129);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 2;
            this.pictureBox_logo.TabStop = false;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1200, 658);
            this.Controls.Add(this.panel_login);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_login_Load);
            this.VisibleChanged += new System.EventHandler(this.frm_login_VisibleChanged);
            this.Resize += new System.EventHandler(this.frm_login_Resize);
            this.panel_login.ResumeLayout(false);
            this.panel_login2.ResumeLayout(false);
            this.panel_login2.PerformLayout();
            this.panel_matkhau.ResumeLayout(false);
            this.panel_matkhau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_tendangnhap.ResumeLayout(false);
            this.panel_tendangnhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Panel panel_login2;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Panel panel_tendangnhap;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_matkhau;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckb_hienmatkhau;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.LinkLabel llbl_quenmatkhau;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.TextBox txt_tendangnhap;
    }
}