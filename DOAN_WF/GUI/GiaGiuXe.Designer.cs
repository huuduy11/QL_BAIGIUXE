namespace DOAN_WF.GUI
{
    partial class GiaGiuXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaGiuXe));
            this.btn_dieuchinh = new System.Windows.Forms.Button();
            this.pnl_tieude = new System.Windows.Forms.Panel();
            this.lbl_dieuchinhgiaxe = new System.Windows.Forms.Label();
            this.ptb_icon = new System.Windows.Forms.PictureBox();
            this.myTransparentPanel1 = new DOAN_WF.MyTransparentPanel();
            this.pnl_button = new System.Windows.Forms.Panel();
            this.pnl_khoangcach = new System.Windows.Forms.Panel();
            this.pnl_dgv = new System.Windows.Forms.Panel();
            this.dgv_giatien = new System.Windows.Forms.DataGridView();
            this.pnl_tieude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_icon)).BeginInit();
            this.pnl_button.SuspendLayout();
            this.pnl_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giatien)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dieuchinh
            // 
            this.btn_dieuchinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_dieuchinh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_dieuchinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dieuchinh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_dieuchinh.Image = ((System.Drawing.Image)(resources.GetObject("btn_dieuchinh.Image")));
            this.btn_dieuchinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dieuchinh.Location = new System.Drawing.Point(0, 0);
            this.btn_dieuchinh.Name = "btn_dieuchinh";
            this.btn_dieuchinh.Size = new System.Drawing.Size(185, 54);
            this.btn_dieuchinh.TabIndex = 0;
            this.btn_dieuchinh.Text = "Điều Chỉnh";
            this.btn_dieuchinh.UseVisualStyleBackColor = false;
            this.btn_dieuchinh.Click += new System.EventHandler(this.btn_dieuchinh_Click);
            // 
            // pnl_tieude
            // 
            this.pnl_tieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.pnl_tieude.Controls.Add(this.lbl_dieuchinhgiaxe);
            this.pnl_tieude.Controls.Add(this.ptb_icon);
            this.pnl_tieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_tieude.Location = new System.Drawing.Point(0, 0);
            this.pnl_tieude.Name = "pnl_tieude";
            this.pnl_tieude.Size = new System.Drawing.Size(1175, 34);
            this.pnl_tieude.TabIndex = 9;
            // 
            // lbl_dieuchinhgiaxe
            // 
            this.lbl_dieuchinhgiaxe.AutoSize = true;
            this.lbl_dieuchinhgiaxe.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_dieuchinhgiaxe.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_dieuchinhgiaxe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lbl_dieuchinhgiaxe.Location = new System.Drawing.Point(54, 0);
            this.lbl_dieuchinhgiaxe.Name = "lbl_dieuchinhgiaxe";
            this.lbl_dieuchinhgiaxe.Size = new System.Drawing.Size(250, 32);
            this.lbl_dieuchinhgiaxe.TabIndex = 4;
            this.lbl_dieuchinhgiaxe.Text = "Cài Đặt Giá Giữ Xe";
            this.lbl_dieuchinhgiaxe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptb_icon
            // 
            this.ptb_icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptb_icon.Image = ((System.Drawing.Image)(resources.GetObject("ptb_icon.Image")));
            this.ptb_icon.Location = new System.Drawing.Point(0, 0);
            this.ptb_icon.Name = "ptb_icon";
            this.ptb_icon.Size = new System.Drawing.Size(54, 34);
            this.ptb_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptb_icon.TabIndex = 3;
            this.ptb_icon.TabStop = false;
            // 
            // myTransparentPanel1
            // 
            this.myTransparentPanel1.BackColor = System.Drawing.Color.Transparent;
            this.myTransparentPanel1.Location = new System.Drawing.Point(137, 0);
            this.myTransparentPanel1.Name = "myTransparentPanel1";
            this.myTransparentPanel1.Size = new System.Drawing.Size(8, 8);
            this.myTransparentPanel1.TabIndex = 10;
            // 
            // pnl_button
            // 
            this.pnl_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_button.Controls.Add(this.btn_dieuchinh);
            this.pnl_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_button.Location = new System.Drawing.Point(0, 34);
            this.pnl_button.Name = "pnl_button";
            this.pnl_button.Size = new System.Drawing.Size(1175, 54);
            this.pnl_button.TabIndex = 11;
            // 
            // pnl_khoangcach
            // 
            this.pnl_khoangcach.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnl_khoangcach.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_khoangcach.Location = new System.Drawing.Point(0, 88);
            this.pnl_khoangcach.Name = "pnl_khoangcach";
            this.pnl_khoangcach.Size = new System.Drawing.Size(1175, 18);
            this.pnl_khoangcach.TabIndex = 12;
            // 
            // pnl_dgv
            // 
            this.pnl_dgv.Controls.Add(this.dgv_giatien);
            this.pnl_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_dgv.Location = new System.Drawing.Point(0, 106);
            this.pnl_dgv.Name = "pnl_dgv";
            this.pnl_dgv.Size = new System.Drawing.Size(1175, 599);
            this.pnl_dgv.TabIndex = 13;
            // 
            // dgv_giatien
            // 
            this.dgv_giatien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_giatien.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_giatien.Location = new System.Drawing.Point(1, 1);
            this.dgv_giatien.Name = "dgv_giatien";
            this.dgv_giatien.RowHeadersWidth = 51;
            this.dgv_giatien.RowTemplate.Height = 24;
            this.dgv_giatien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_giatien.Size = new System.Drawing.Size(1173, 590);
            this.dgv_giatien.TabIndex = 9;
            this.dgv_giatien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_giatien_CellContentClick_1);
            // 
            // GiaGiuXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 705);
            this.Controls.Add(this.pnl_dgv);
            this.Controls.Add(this.pnl_khoangcach);
            this.Controls.Add(this.pnl_button);
            this.Controls.Add(this.myTransparentPanel1);
            this.Controls.Add(this.pnl_tieude);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GiaGiuXe";
            this.Load += new System.EventHandler(this.GiaGiuXe_Load);
            this.pnl_tieude.ResumeLayout(false);
            this.pnl_tieude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_icon)).EndInit();
            this.pnl_button.ResumeLayout(false);
            this.pnl_dgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giatien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_dieuchinh;
        private System.Windows.Forms.Panel pnl_tieude;
        private MyTransparentPanel myTransparentPanel1;
        private System.Windows.Forms.PictureBox ptb_icon;
        private System.Windows.Forms.Label lbl_dieuchinhgiaxe;
        private System.Windows.Forms.Panel pnl_button;
        private System.Windows.Forms.Panel pnl_khoangcach;
        private System.Windows.Forms.Panel pnl_dgv;
        private System.Windows.Forms.DataGridView dgv_giatien;
    }
}