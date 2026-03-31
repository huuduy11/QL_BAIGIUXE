using DOAN_WF.BUS;
using DOAN_WF.DTO;
using DOAN_WF.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace DOAN_WF.GUI
{
    public partial class frm_quanlynhansu : Form
    {
        // khởi tạo các nghiệp vụ
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        CaTrucBUS caTrucBUS = new CaTrucBUS();
        QuyenBUS quyenBUS = new QuyenBUS();
        public frm_quanlynhansu()
        {
            InitializeComponent();
        }
        // Hàm form load
        private void frm_quanlynhansu_Load(object sender, EventArgs e)
        {
            LoadCaTruc();
            LoadNhanVien();
            LoadQuyen();
            PhanQuyen();
            int quyen = LuuPhienDangNhap.CurrentUser.MaQuyen;

        }
        // Phân quyền 
        private void PhanQuyen()
        {
            // Lấy quyền từ phiên đăng nhập (1: Admin, 2: Quản lý, 3: Nhân viên)
            int quyen = LuuPhienDangNhap.CurrentUser.MaTK;

            if (quyen == 3) // Nếu là nhân viên
            {
                btn_themnv.Enabled = false;
                btn_dieuchinh.Enabled = false;
                btn_xoa.Enabled = false;
                txt_manv.Enabled = false;
                txt_tenNV.Enabled = false;
            }
            else // Admin hoặc Quản lý
            {
                // Hiển thị tất cả
                txt_manv.Enabled = true;
                txt_tenNV.Enabled = true;
                btn_themnv.Enabled = true;
                btn_dieuchinh.Enabled = true;
                btn_xoa.Enabled = true;
            }
        }
        public void LoadQuyen()
        {
            List<QuyenDTO> dsQuyen = quyenBUS.LayDanhSachQuyen();
            cbo_chucvu.DisplayMember = "TenQuyen";
            cbo_chucvu.ValueMember = "MaQuyen";
            cbo_chucvu.DataSource = dsQuyen;
        }
        public void LoadCaTruc()
        {
    
            List <CaTrucDTO> dscatruc =caTrucBUS.LayDanhSachCaTruc();
            cbo_calam.DisplayMember = "TenCa";
            cbo_calam.ValueMember = "MaCa";
            cbo_calam.DataSource = dscatruc;
        }
        private void LoadNhanVien()
        {
            // Lấy danh sách nhân viên từ BUS
            var dsNhanVien = nhanVienBUS.LayDanhSachNhanVien();
            dgv_thongtinNV.DataSource = dsNhanVien.Select(nv => new
            {
                nv.MaNV,
                nv.TenNV,
                Quyen = nv.Quyen.TenQuyen,// Lấy trực tiếp tên quyền để hiện thị
                nv.TenCa
            }).ToList();
            dgv_thongtinNV.RowHeadersVisible = true;
            dgv_thongtinNV.TopLeftHeaderCell.Value = "STT";
            dgv_thongtinNV.Columns["MaNV"].HeaderText = "Mã NV";
            dgv_thongtinNV.Columns["TenNV"].HeaderText = "Tên NV";
            dgv_thongtinNV.Columns["Quyen"].HeaderText = "Quyền";
            dgv_thongtinNV.Columns["TenCa"].HeaderText = "Tên Ca";
            dgv_thongtinNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự giãn đều

        }

        private void dgv_thongtinNV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strSTT = (e.RowIndex + 1).ToString();

            // Định dạng chữ cho STT
            using (SolidBrush brush = new SolidBrush(dgv_thongtinNV.RowHeadersDefaultCellStyle.ForeColor))
            {
                // Tính toán vị trí để vẽ chữ vào giữa Row Header
                e.Graphics.DrawString(strSTT, e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
        // Xử lý sự kiện khi click vào một dòng trong DataGridView hiện lệnh để hiển thị thông tin chi tiết của nhân viên đó lên các TextBox và ComboBox tương ứng
        private void dgv_thongtinNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_manv.Text = dgv_thongtinNV.CurrentRow.Cells["MaNV"].Value.ToString();
            txt_tenNV.Text = dgv_thongtinNV.CurrentRow.Cells["TenNV"].Value.ToString();
            cbo_chucvu.Text = dgv_thongtinNV.CurrentRow.Cells["Quyen"].Value.ToString();
            cbo_calam.Text = dgv_thongtinNV.CurrentRow.Cells["TenCa"].Value.ToString();

        }

        

        private void btn_themnv_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra trống (Validation)
            if (string.IsNullOrWhiteSpace(txt_manv.Text) || string.IsNullOrWhiteSpace(txt_tenNV.Text))
            {
                MessageBox.Show("Mã nhân viên và tên nhân viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng số cho Mã NV
            if (!int.TryParse(txt_manv.Text, out int maNV))
            {
                MessageBox.Show("Mã nhân viên phải là số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra trùng mã (Gọi xuống lớp BUS)
            // Giả sử bạn viết thêm hàm KiemTraTrungMa trong NhanVienBUS
            if (nhanVienBUS.KiemTraMaNV(maNV))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LamMoi();
                return;
            }

            try
            {
                // 4. Gán dữ liệu vào DTO
                NhanVienDTO nv = new NhanVienDTO
                {
                    MaNV = maNV,
                    TenNV = txt_tenNV.Text.Trim(),
                    MaCa = (int)cbo_calam.SelectedValue,
                    MaTK = (int)cbo_chucvu.SelectedValue,
                    MaQuyen = (int)cbo_chucvu.SelectedValue //
                };

                // 5. Thực hiện thêm
                if (nhanVienBUS.ThemNhanVien(nv))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                    LoadNhanVien();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống");
            }
        }
        private void btn_dieuchinh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text) || string.IsNullOrEmpty(txt_tenNV.Text))
            {
                MessageBox.Show("Mã nhân viên và tên nhân viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txt_manv.Text, out int maNV))
            {
                MessageBox.Show("Mã nhân viên phải là số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!nhanVienBUS.KiemTraMaNV(maNV))
            {
                MessageBox.Show("Mã nhân viên này không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn điều chỉnh thông tin nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    NhanVienDTO nv = new NhanVienDTO
                    {
                        MaNV = maNV,
                        TenNV = txt_tenNV.Text.Trim(),
                        // Sửa lại: Không gán trực tiếp MaTK từ combo chức vụ
                        MaQuyen = (int)cbo_chucvu.SelectedValue,
                        MaCa = (int)cbo_calam.SelectedValue
                    };
                    if (nhanVienBUS.CapNhatNhanVien(nv))
                    {
                        MessageBox.Show("Đã điều chỉnh thông tin nhân viên!");
                        LoadNhanVien();
                        LamMoi();
                    }
                    else
                    {
                        MessageBox.Show("Điều chỉnh thất bại!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống");
                }
            }


        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_manv.Text)) return;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int maNV = int.Parse(txt_manv.Text);

                if (nhanVienBUS.XoaNhanVien(maNV))
                {
                    MessageBox.Show("Đã xóa nhân viên!");
                    LamMoi();
                    LoadNhanVien(); // Load lại danh sách
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Có thể nhân viên này đang có dữ liệu trong lịch sử vào ra.");
                }
            }
        }
        private void LamMoi()
        {
            txt_manv.Clear();
            txt_tenNV.Clear();
            cbo_chucvu.SelectedValue = 3;
            cbo_calam.SelectedItem = "Ca Sáng";
        }

        private void btn_lamoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadNhanVien();
        }

      
    }
}
