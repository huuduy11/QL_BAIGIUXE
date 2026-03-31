namespace DOAN_WF.GUI
{
    partial class frmCapNhatGia
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_capnhatbanggia = new System.Windows.Forms.TextBox();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_capnhat = new System.Windows.Forms.Button();
            this.lbl_tenxe = new System.Windows.Forms.Label();
            this.txt_giathang = new System.Windows.Forms.TextBox();
            this.txt_giangay = new System.Windows.Forms.TextBox();
            this.lbl_giathang = new System.Windows.Forms.Label();
            this.lbl_giangay = new System.Windows.Forms.Label();
            this.lbl_capnhatbanggia = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txt_capnhatbanggia);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 27);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // txt_capnhatbanggia
            // 
            this.txt_capnhatbanggia.Location = new System.Drawing.Point(3, 3);
            this.txt_capnhatbanggia.Name = "txt_capnhatbanggia";
            this.txt_capnhatbanggia.Size = new System.Drawing.Size(785, 22);
            this.txt_capnhatbanggia.TabIndex = 0;
            this.txt_capnhatbanggia.Text = "Cập Nhật Bảng Giá";
            // 
            // btn_thoat
            // 
            this.btn_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(362, 192);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(120, 41);
            this.btn_thoat.TabIndex = 28;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_capnhat
            // 
            this.btn_capnhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capnhat.Location = new System.Drawing.Point(226, 192);
            this.btn_capnhat.Name = "btn_capnhat";
            this.btn_capnhat.Size = new System.Drawing.Size(120, 41);
            this.btn_capnhat.TabIndex = 29;
            this.btn_capnhat.Text = "Cập Nhật";
            this.btn_capnhat.UseVisualStyleBackColor = true;
            this.btn_capnhat.Click += new System.EventHandler(this.btn_capnhat_Click);
            // 
            // lbl_tenxe
            // 
            this.lbl_tenxe.AutoSize = true;
            this.lbl_tenxe.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_tenxe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tenxe.Location = new System.Drawing.Point(398, 51);
            this.lbl_tenxe.Name = "lbl_tenxe";
            this.lbl_tenxe.Size = new System.Drawing.Size(77, 25);
            this.lbl_tenxe.TabIndex = 27;
            this.lbl_tenxe.Text = "Tên Xe";
            // 
            // txt_giathang
            // 
            this.txt_giathang.Location = new System.Drawing.Point(338, 144);
            this.txt_giathang.Name = "txt_giathang";
            this.txt_giathang.Size = new System.Drawing.Size(224, 22);
            this.txt_giathang.TabIndex = 26;
            // 
            // txt_giangay
            // 
            this.txt_giangay.Location = new System.Drawing.Point(338, 107);
            this.txt_giangay.Name = "txt_giangay";
            this.txt_giangay.Size = new System.Drawing.Size(224, 22);
            this.txt_giangay.TabIndex = 25;
            // 
            // lbl_giathang
            // 
            this.lbl_giathang.AutoSize = true;
            this.lbl_giathang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_giathang.Location = new System.Drawing.Point(222, 144);
            this.lbl_giathang.Name = "lbl_giathang";
            this.lbl_giathang.Size = new System.Drawing.Size(96, 20);
            this.lbl_giathang.TabIndex = 24;
            this.lbl_giathang.Text = "Giá Tháng :";
            // 
            // lbl_giangay
            // 
            this.lbl_giangay.AutoSize = true;
            this.lbl_giangay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_giangay.Location = new System.Drawing.Point(230, 109);
            this.lbl_giangay.Name = "lbl_giangay";
            this.lbl_giangay.Size = new System.Drawing.Size(88, 20);
            this.lbl_giangay.TabIndex = 23;
            this.lbl_giangay.Text = "Giá Ngày :";
            // 
            // lbl_capnhatbanggia
            // 
            this.lbl_capnhatbanggia.AutoSize = true;
            this.lbl_capnhatbanggia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_capnhatbanggia.Location = new System.Drawing.Point(200, 51);
            this.lbl_capnhatbanggia.Name = "lbl_capnhatbanggia";
            this.lbl_capnhatbanggia.Size = new System.Drawing.Size(192, 25);
            this.lbl_capnhatbanggia.TabIndex = 22;
            this.lbl_capnhatbanggia.Text = "Cập Nhật Bảng Giá :";
            // 
            // frmCapNhatGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 251);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_capnhat);
            this.Controls.Add(this.lbl_tenxe);
            this.Controls.Add(this.txt_giathang);
            this.Controls.Add(this.txt_giangay);
            this.Controls.Add(this.lbl_giathang);
            this.Controls.Add(this.lbl_giangay);
            this.Controls.Add(this.lbl_capnhatbanggia);
            this.Name = "frmCapNhatGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCapNhatGia";
            this.Load += new System.EventHandler(this.frmCapNhatGia_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txt_capnhatbanggia;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_capnhat;
        private System.Windows.Forms.Label lbl_tenxe;
        private System.Windows.Forms.TextBox txt_giathang;
        private System.Windows.Forms.TextBox txt_giangay;
        private System.Windows.Forms.Label lbl_giathang;
        private System.Windows.Forms.Label lbl_giangay;
        private System.Windows.Forms.Label lbl_capnhatbanggia;
    }
}