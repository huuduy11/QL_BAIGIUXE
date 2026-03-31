namespace DOAN_WF.GUI
{
    partial class frm_lichsuvaora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_lichsuvaora));
            this.pnl_table = new System.Windows.Forms.Panel();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.pnl_timkiem = new System.Windows.Forms.Panel();
            this.txt_nhapbienso_loaixe = new System.Windows.Forms.TextBox();
            this.btn_baocaosuco = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_tim = new System.Windows.Forms.Button();
            this.pnl_fullbutton = new System.Windows.Forms.Panel();
            this.btn_xuatecxel = new System.Windows.Forms.Button();
            this.btn_tracuu = new System.Windows.Forms.Button();
            this.chk_dara = new System.Windows.Forms.CheckBox();
            this.chk_vanglai = new System.Windows.Forms.CheckBox();
            this.chk_xethang = new System.Windows.Forms.CheckBox();
            this.chk_trongbai = new System.Windows.Forms.CheckBox();
            this.dtp_denngay = new System.Windows.Forms.DateTimePicker();
            this.dtp_tungay = new System.Windows.Forms.DateTimePicker();
            this.lbl_denngay = new System.Windows.Forms.Label();
            this.lbl_tungay = new System.Windows.Forms.Label();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lbl_lichsuvaora = new System.Windows.Forms.Label();
            this.ptb_lichsuvaora = new System.Windows.Forms.PictureBox();
            this.btn_X_lichsuvaora = new System.Windows.Forms.Button();
            this.pnl_table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.pnl_timkiem.SuspendLayout();
            this.pnl_fullbutton.SuspendLayout();
            this.pnl_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_lichsuvaora)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_table
            // 
            this.pnl_table.Controls.Add(this.dgv_table);
            this.pnl_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_table.Location = new System.Drawing.Point(0, 229);
            this.pnl_table.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pnl_table.Name = "pnl_table";
            this.pnl_table.Size = new System.Drawing.Size(1640, 434);
            this.pnl_table.TabIndex = 7;
            // 
            // dgv_table
            // 
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_table.Location = new System.Drawing.Point(0, 0);
            this.dgv_table.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.RowHeadersWidth = 51;
            this.dgv_table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_table.Size = new System.Drawing.Size(1640, 434);
            this.dgv_table.TabIndex = 0;
          
            this.dgv_table.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_table_CellFormatting);
            // 
            // pnl_timkiem
            // 
            this.pnl_timkiem.Controls.Add(this.txt_nhapbienso_loaixe);
            this.pnl_timkiem.Controls.Add(this.btn_baocaosuco);
            this.pnl_timkiem.Controls.Add(this.btn_xoa);
            this.pnl_timkiem.Controls.Add(this.btn_tim);
            this.pnl_timkiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_timkiem.Location = new System.Drawing.Point(0, 178);
            this.pnl_timkiem.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pnl_timkiem.Name = "pnl_timkiem";
            this.pnl_timkiem.Size = new System.Drawing.Size(1640, 51);
            this.pnl_timkiem.TabIndex = 6;
            // 
            // txt_nhapbienso_loaixe
            // 
            this.txt_nhapbienso_loaixe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nhapbienso_loaixe.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txt_nhapbienso_loaixe.Location = new System.Drawing.Point(18, 8);
            this.txt_nhapbienso_loaixe.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_nhapbienso_loaixe.Multiline = true;
            this.txt_nhapbienso_loaixe.Name = "txt_nhapbienso_loaixe";
            this.txt_nhapbienso_loaixe.Size = new System.Drawing.Size(484, 36);
            this.txt_nhapbienso_loaixe.TabIndex = 0;
            this.txt_nhapbienso_loaixe.Text = "Nhập Biển số hoặc Loại xe";
            this.txt_nhapbienso_loaixe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_nhapbienso_loaixe.TextChanged += new System.EventHandler(this.txt_nhapbienso_loaixe_TextChanged);
            this.txt_nhapbienso_loaixe.Enter += new System.EventHandler(this.txt_nhapbienso_loaixe_Enter);
            this.txt_nhapbienso_loaixe.Leave += new System.EventHandler(this.txt_nhapbienso_loaixe_Leave);
            // 
            // btn_baocaosuco
            // 
            this.btn_baocaosuco.BackColor = System.Drawing.Color.IndianRed;
            this.btn_baocaosuco.FlatAppearance.BorderSize = 0;
            this.btn_baocaosuco.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btn_baocaosuco.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_baocaosuco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_baocaosuco.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_baocaosuco.ForeColor = System.Drawing.Color.White;
            this.btn_baocaosuco.Location = new System.Drawing.Point(1080, 6);
            this.btn_baocaosuco.Name = "btn_baocaosuco";
            this.btn_baocaosuco.Size = new System.Drawing.Size(148, 38);
            this.btn_baocaosuco.TabIndex = 4;
            this.btn_baocaosuco.Text = "Báo Cáo Sự Cố";
            this.btn_baocaosuco.UseVisualStyleBackColor = false;
            this.btn_baocaosuco.Click += new System.EventHandler(this.btn_baocaosuco_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_xoa.FlatAppearance.BorderSize = 0;
            this.btn_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_xoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_xoa.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_xoa.Location = new System.Drawing.Point(716, 8);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(121, 34);
            this.btn_xoa.TabIndex = 3;
            this.btn_xoa.Text = "Làm Mới";
            this.btn_xoa.UseVisualStyleBackColor = false;
            // 
            // btn_tim
            // 
            this.btn_tim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_tim.FlatAppearance.BorderSize = 0;
            this.btn_tim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_tim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_tim.ForeColor = System.Drawing.Color.White;
            this.btn_tim.Location = new System.Drawing.Point(541, 10);
            this.btn_tim.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_tim.Name = "btn_tim";
            this.btn_tim.Size = new System.Drawing.Size(121, 34);
            this.btn_tim.TabIndex = 3;
            this.btn_tim.Text = "Tìm";
            this.btn_tim.UseVisualStyleBackColor = false;
            // 
            // pnl_fullbutton
            // 
            this.pnl_fullbutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_fullbutton.Controls.Add(this.btn_xuatecxel);
            this.pnl_fullbutton.Controls.Add(this.btn_tracuu);
            this.pnl_fullbutton.Controls.Add(this.chk_dara);
            this.pnl_fullbutton.Controls.Add(this.chk_vanglai);
            this.pnl_fullbutton.Controls.Add(this.chk_xethang);
            this.pnl_fullbutton.Controls.Add(this.chk_trongbai);
            this.pnl_fullbutton.Controls.Add(this.dtp_denngay);
            this.pnl_fullbutton.Controls.Add(this.dtp_tungay);
            this.pnl_fullbutton.Controls.Add(this.lbl_denngay);
            this.pnl_fullbutton.Controls.Add(this.lbl_tungay);
            this.pnl_fullbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_fullbutton.Location = new System.Drawing.Point(0, 47);
            this.pnl_fullbutton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pnl_fullbutton.Name = "pnl_fullbutton";
            this.pnl_fullbutton.Size = new System.Drawing.Size(1640, 131);
            this.pnl_fullbutton.TabIndex = 5;
            // 
            // btn_xuatecxel
            // 
            this.btn_xuatecxel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_xuatecxel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_xuatecxel.FlatAppearance.BorderSize = 0;
            this.btn_xuatecxel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btn_xuatecxel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_xuatecxel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_xuatecxel.ForeColor = System.Drawing.Color.White;
            this.btn_xuatecxel.Image = ((System.Drawing.Image)(resources.GetObject("btn_xuatecxel.Image")));
            this.btn_xuatecxel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xuatecxel.Location = new System.Drawing.Point(1080, 33);
            this.btn_xuatecxel.Name = "btn_xuatecxel";
            this.btn_xuatecxel.Size = new System.Drawing.Size(137, 38);
            this.btn_xuatecxel.TabIndex = 5;
            this.btn_xuatecxel.Text = "Xuất Ecxel";
            this.btn_xuatecxel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xuatecxel.UseVisualStyleBackColor = false;
            // 
            // btn_tracuu
            // 
            this.btn_tracuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(131)))), ((int)(((byte)(217)))));
            this.btn_tracuu.FlatAppearance.BorderSize = 0;
            this.btn_tracuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_tracuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_tracuu.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btn_tracuu.Image = ((System.Drawing.Image)(resources.GetObject("btn_tracuu.Image")));
            this.btn_tracuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tracuu.Location = new System.Drawing.Point(938, 35);
            this.btn_tracuu.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_tracuu.Name = "btn_tracuu";
            this.btn_tracuu.Size = new System.Drawing.Size(111, 36);
            this.btn_tracuu.TabIndex = 3;
            this.btn_tracuu.Text = "Tra Cứu";
            this.btn_tracuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_tracuu.UseVisualStyleBackColor = false;
            this.btn_tracuu.Click += new System.EventHandler(this.btn_tracuu_Click);
            // 
            // chk_dara
            // 
            this.chk_dara.AutoSize = true;
            this.chk_dara.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chk_dara.Location = new System.Drawing.Point(602, 66);
            this.chk_dara.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_dara.Name = "chk_dara";
            this.chk_dara.Size = new System.Drawing.Size(85, 27);
            this.chk_dara.TabIndex = 2;
            this.chk_dara.Text = "Đã Ra";
            this.chk_dara.UseVisualStyleBackColor = true;
            this.chk_dara.CheckedChanged += new System.EventHandler(this.chk_dara_CheckedChanged);
            // 
            // chk_vanglai
            // 
            this.chk_vanglai.AutoSize = true;
            this.chk_vanglai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chk_vanglai.Location = new System.Drawing.Point(781, 66);
            this.chk_vanglai.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_vanglai.Name = "chk_vanglai";
            this.chk_vanglai.Size = new System.Drawing.Size(109, 27);
            this.chk_vanglai.TabIndex = 2;
            this.chk_vanglai.Text = "Vãng Lai";
            this.chk_vanglai.UseVisualStyleBackColor = true;
            this.chk_vanglai.CheckedChanged += new System.EventHandler(this.chk_vanglai_CheckedChanged);
            // 
            // chk_xethang
            // 
            this.chk_xethang.AutoSize = true;
            this.chk_xethang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chk_xethang.Location = new System.Drawing.Point(781, 25);
            this.chk_xethang.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_xethang.Name = "chk_xethang";
            this.chk_xethang.Size = new System.Drawing.Size(113, 27);
            this.chk_xethang.TabIndex = 2;
            this.chk_xethang.Text = "Xe Tháng";
            this.chk_xethang.UseVisualStyleBackColor = true;
            this.chk_xethang.CheckedChanged += new System.EventHandler(this.chk_xethang_CheckedChanged);
            // 
            // chk_trongbai
            // 
            this.chk_trongbai.AutoSize = true;
            this.chk_trongbai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chk_trongbai.Location = new System.Drawing.Point(602, 26);
            this.chk_trongbai.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_trongbai.Name = "chk_trongbai";
            this.chk_trongbai.Size = new System.Drawing.Size(115, 27);
            this.chk_trongbai.TabIndex = 2;
            this.chk_trongbai.Text = "Trong Bãi";
            this.chk_trongbai.UseVisualStyleBackColor = true;
            this.chk_trongbai.CheckedChanged += new System.EventHandler(this.chk_trongbai_CheckedChanged);
            // 
            // dtp_denngay
            // 
            this.dtp_denngay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtp_denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_denngay.Location = new System.Drawing.Point(140, 74);
            this.dtp_denngay.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.dtp_denngay.Name = "dtp_denngay";
            this.dtp_denngay.Size = new System.Drawing.Size(359, 30);
            this.dtp_denngay.TabIndex = 1;
            // 
            // dtp_tungay
            // 
            this.dtp_tungay.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtp_tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_tungay.Location = new System.Drawing.Point(140, 22);
            this.dtp_tungay.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.dtp_tungay.Name = "dtp_tungay";
            this.dtp_tungay.Size = new System.Drawing.Size(359, 30);
            this.dtp_tungay.TabIndex = 1;
            // 
            // lbl_denngay
            // 
            this.lbl_denngay.AutoSize = true;
            this.lbl_denngay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_denngay.Location = new System.Drawing.Point(33, 74);
            this.lbl_denngay.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_denngay.Name = "lbl_denngay";
            this.lbl_denngay.Size = new System.Drawing.Size(96, 23);
            this.lbl_denngay.TabIndex = 0;
            this.lbl_denngay.Text = "Đến ngày:";
            // 
            // lbl_tungay
            // 
            this.lbl_tungay.AutoSize = true;
            this.lbl_tungay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_tungay.Location = new System.Drawing.Point(33, 22);
            this.lbl_tungay.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_tungay.Name = "lbl_tungay";
            this.lbl_tungay.Size = new System.Drawing.Size(87, 23);
            this.lbl_tungay.TabIndex = 0;
            this.lbl_tungay.Text = "Từ ngày:";
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.pnl_top.Controls.Add(this.lbl_lichsuvaora);
            this.pnl_top.Controls.Add(this.ptb_lichsuvaora);
            this.pnl_top.Controls.Add(this.btn_X_lichsuvaora);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1640, 47);
            this.pnl_top.TabIndex = 4;
            // 
            // lbl_lichsuvaora
            // 
            this.lbl_lichsuvaora.AutoSize = true;
            this.lbl_lichsuvaora.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_lichsuvaora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.lbl_lichsuvaora.Location = new System.Drawing.Point(92, 12);
            this.lbl_lichsuvaora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_lichsuvaora.Name = "lbl_lichsuvaora";
            this.lbl_lichsuvaora.Size = new System.Drawing.Size(204, 32);
            this.lbl_lichsuvaora.TabIndex = 2;
            this.lbl_lichsuvaora.Text = "Lịch Sử Vào Ra";
            // 
            // ptb_lichsuvaora
            // 
            this.ptb_lichsuvaora.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptb_lichsuvaora.Image = ((System.Drawing.Image)(resources.GetObject("ptb_lichsuvaora.Image")));
            this.ptb_lichsuvaora.Location = new System.Drawing.Point(0, 0);
            this.ptb_lichsuvaora.Margin = new System.Windows.Forms.Padding(4);
            this.ptb_lichsuvaora.Name = "ptb_lichsuvaora";
            this.ptb_lichsuvaora.Size = new System.Drawing.Size(84, 47);
            this.ptb_lichsuvaora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptb_lichsuvaora.TabIndex = 1;
            this.ptb_lichsuvaora.TabStop = false;
            // 
            // btn_X_lichsuvaora
            // 
            this.btn_X_lichsuvaora.Location = new System.Drawing.Point(1745, 0);
            this.btn_X_lichsuvaora.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_X_lichsuvaora.Name = "btn_X_lichsuvaora";
            this.btn_X_lichsuvaora.Size = new System.Drawing.Size(77, 37);
            this.btn_X_lichsuvaora.TabIndex = 0;
            this.btn_X_lichsuvaora.Text = "X";
            this.btn_X_lichsuvaora.UseVisualStyleBackColor = true;
            // 
            // frm_lichsuvaora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1640, 663);
            this.Controls.Add(this.pnl_table);
            this.Controls.Add(this.pnl_timkiem);
            this.Controls.Add(this.pnl_fullbutton);
            this.Controls.Add(this.pnl_top);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_lichsuvaora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LichSuVaoRa_Load);
            this.pnl_table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.pnl_timkiem.ResumeLayout(false);
            this.pnl_timkiem.PerformLayout();
            this.pnl_fullbutton.ResumeLayout(false);
            this.pnl_fullbutton.PerformLayout();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_lichsuvaora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_table;
        private System.Windows.Forms.Panel pnl_timkiem;
        private System.Windows.Forms.TextBox txt_nhapbienso_loaixe;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_tim;
        private System.Windows.Forms.Panel pnl_fullbutton;
        private System.Windows.Forms.Button btn_tracuu;
        private System.Windows.Forms.CheckBox chk_dara;
        private System.Windows.Forms.CheckBox chk_vanglai;
        private System.Windows.Forms.CheckBox chk_xethang;
        private System.Windows.Forms.CheckBox chk_trongbai;
        private System.Windows.Forms.DateTimePicker dtp_denngay;
        private System.Windows.Forms.DateTimePicker dtp_tungay;
        private System.Windows.Forms.Label lbl_denngay;
        private System.Windows.Forms.Label lbl_tungay;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Button btn_X_lichsuvaora;
        private System.Windows.Forms.PictureBox ptb_lichsuvaora;
        private System.Windows.Forms.Label lbl_lichsuvaora;
        private System.Windows.Forms.Button btn_baocaosuco;
        private System.Windows.Forms.Button btn_xuatecxel;
        public System.Windows.Forms.DataGridView dgv_table;
    }
}