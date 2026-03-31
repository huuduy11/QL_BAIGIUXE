using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace DOAN_WF.GUI
{
    public partial class frmChiTietLoaiXe : Form
    {
        LoaiXeBUS bus = new LoaiXeBUS();

        public bool IsAdd { get; set; } = true;
        public int maLoai { get; set; }
        public string tenLoai { get; set; }
        public string nhomXe { get; set; }
        public frmChiTietLoaiXe()
        {
            InitializeComponent();
        }

        private void frmChiTietLoaiXe_Load(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                this.Text = "Thêm mới loại xe";
                cbo_nhomloaixe.SelectedIndex = 0; // Mặc định chọn nhóm đầu tiên
            }
            else
            {
                this.Text = "Cập nhật thông tin";
                textBox1.Text = tenLoai;      // Hiển thị tên cũ cần sửa
                cbo_nhomloaixe.Text = nhomXe; // Hiển thị nhóm xe cũ
            }
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text.Trim();
            string nhom = cbo_nhomloaixe.Text;

            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập tên loại xe!");
                return;
            }

            if (IsAdd)
            {
                if (bus.AddLoaiXe(ten, nhom))
                {
                    MessageBox.Show("Thêm mới thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                // Sửa theo mã đã nhận
                if (bus.UpdateLoaiXe(maLoai, ten, nhom))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
