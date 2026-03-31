using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiaDTO;
using GiaBUS;

namespace DOAN_WF.GUI
{
    public partial class frmCapNhatGia : Form
    {
        GiaXeBUS bus = new GiaXeBUS();

        public int maLoai;
        public string tenLoai;
        public decimal giaNgay, giaDem, giaThem, giaThang;

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Khởi tạo đối tượng DTO và gán dữ liệu
                GiaXeDTO gia = new GiaXeDTO
                {
                    MaLoaiXe = maLoai,
                    GiaLuotDau = decimal.Parse(txt_giangay.Text),
                    GiaThang = decimal.Parse(txt_giathang.Text)
                };

                // 2. Gọi tầng BUS để xử lý lưu trữ
                if (bus.CapNhatGia(gia))
                {
                    MessageBox.Show("Cập nhật bảng giá thành công!", "Thông báo");

                    // 3. Trả về kết quả OK để Form cha load lại dữ liệu
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (FormatException)
            {
                // Xử lý khi người dùng nhập ký tự không phải là số
                MessageBox.Show("Lỗi: Giá tiền phải là con số!", "Nhập liệu sai");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi hệ thống khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        public frmCapNhatGia()
        {
            InitializeComponent();
        }

        private void frmCapNhatGia_Load(object sender, EventArgs e)
        {
            lbl_tenxe.Text = tenLoai;
            txt_giangay.Text = giaNgay.ToString();
            txt_giathang.Text = giaThang.ToString();
        }
    }
}
