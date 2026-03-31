using DOAN_WF.BUS;
using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_WF.GUI
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        NhanVienBUS busNV = new NhanVienBUS();
        private void frm_login_Load(object sender, EventArgs e)
        { 
            txt_tendangnhap.Focus(); 
            BoGocPanel(panel_login2,30); 
            AcceptButton = btn_dangnhap; 
        }
        private void BoGocPanel(Panel p, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(p.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(p.Width - radius, p.Height - radius, radius, radius, 20, 90);
            path.AddArc(0, p.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            p.Region = new Region(path);
        }
        private void frm_login_Resize(object sender, EventArgs e)
        {
            panel_login2.Left = (this.ClientSize.Width - panel_login2.Width) / 2;
            panel_login2.Top = (this.ClientSize.Height - panel_login2.Height) / 2;
        }
        private void llbl_quenmatkhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để lấy lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_dangnhap_Click_1(object sender, EventArgs e)
        {

            if (busNV.DangNhap(txt_tendangnhap.Text, txt_matkhau.Text))
            {
                frm_main main = new frm_main();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        private void ckb_ghinholansau_CheckedChanged(object sender, EventArgs e)
                      // hiện mk
        {
            if (ckb_hienmatkhau.Checked)
            {
                txt_matkhau.PasswordChar = '\0';
            }
            else
            {
                txt_matkhau.PasswordChar = '*';
            }
        }
        private void Xoathongtin()
        {
            txt_tendangnhap.Clear();
            txt_matkhau.Clear();
        }

        private void frm_login_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Xoathongtin();
            }
        }
    }
    
}
