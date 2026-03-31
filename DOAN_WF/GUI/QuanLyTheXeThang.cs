using DoAn_demo;
using DOAN_WF.BUS;
using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_WF.GUI
{
    public partial class frm_quanlyxethang : Form
    {
        int maTheCu = -1;
        LoaiXeBUS LoaiXeBUS = new LoaiXeBUS();
        TheXeBUS TheXeBUS = new TheXeBUS();
        ThongTinXeThangBUS ThongTinXeThangBUS = new ThongTinXeThangBUS();

        public frm_quanlyxethang()
        {
            InitializeComponent();
        }

        private void frm_quanlyxethang_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            LoadLoaiXe();
            LoadTheXe();
            txt_madk.Enabled = false;
            LoadData();
            RefreshALL();

        }
        private void PhanQuyen()
        {
            // Lấy quyền từ phiên đăng nhập (1: Admin, 2: Quản lý, 3: Nhân viên)
            int quyen = LuuPhienDangNhap.CurrentUser.MaTK;

            if (quyen == 3) // Nếu là nhân viên
            {
               btn_them.Enabled = false;
               btn_dieuchinh.Enabled = false;
               btn_xoa.Enabled = false;
            }
            else 
            {
               btn_them.Enabled = true;
               btn_dieuchinh.Enabled = true;
               btn_xoa.Enabled = true;

            }
        }
        public void LoadLoaiXe()
        {
            cbo_loaixe.DataSource = LoaiXeBUS.Laydanhsachloaixe();
            cbo_loaixe.DisplayMember = "TenLoaiXe";
            cbo_loaixe.ValueMember = "MaLoaiXe";
        }
        private void LoadTheXe()
        {
            DataTable dt = ThongTinXeThangBUS.LayDanhSachTheThang();
            cbo_mathe.DataSource = dt;
            cbo_mathe.DisplayMember = "MaThe";
            cbo_mathe.ValueMember = "MaThe";
        }
        void LoadData()
        {
            DataTable dt = ThongTinXeThangBUS.LayDSXeThang();
            dgv_thongtinxethang.DataSource = dt;
            dgv_thongtinxethang.Columns["MaDK"].HeaderText = "Mã ĐK";
            dgv_thongtinxethang.Columns["MaThe"].HeaderText = "Mã Thẻ";
            dgv_thongtinxethang.Columns["BienSo"].HeaderText = "Biển Số";
            dgv_thongtinxethang.Columns["MauSac"].HeaderText = "Màu Sắc";
            dgv_thongtinxethang.Columns["HoTenChuXe"].HeaderText = "Chủ Xe";
            dgv_thongtinxethang.Columns["SDT"].HeaderText = "SĐT";
            dgv_thongtinxethang.Columns["TenLoaiXe"].HeaderText = "Loại Xe";
            dgv_thongtinxethang.Columns["MaLoaiXe"].Visible = false; // Ẩn cột MaLoaiXe không cần thiết
            dgv_thongtinxethang.Columns["NgayDangKy"].HeaderText = "Ngày ĐK";
            dgv_thongtinxethang.Columns["NgayHetHan"].HeaderText = "Hết Hạn";
            dgv_thongtinxethang.Columns["TrangThaiActive"].Visible = false; // Ẩn
            if (!dt.Columns.Contains("Trạng Thái"))
            {
                dt.Columns.Add("Trạng Thái", typeof(string));
            }

            foreach (DataRow dr in dt.Rows)
            {
                // Chuyển đổi về số để so sánh cho chính xác
                int status = 0;
                if (dr["TrangThaiActive"] != DBNull.Value)
                {
                    status = Convert.ToInt32(dr["TrangThaiActive"]);
                }

                if (status == 1)
                    dr["Trạng Thái"] = "Active";
                else
                    dr["Trạng Thái"] = "InActive";
            }

            dgv_thongtinxethang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_thongtinxethang.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_thongtinxethang.Columns["NgayHetHan"].DefaultCellStyle.Format = "dd/MM/yyyy";

        }
        private void dgv_thongtinxethang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào dòng hợp lệ (không phải header)
            if (e.RowIndex >= 0 && dgv_thongtinxethang.Rows[e.RowIndex].Cells["MaDK"].Value != null)
            {
                try
                {
                    DataGridViewRow row = dgv_thongtinxethang.Rows[e.RowIndex];

                    // Dùng hàm bổ trợ để tránh lỗi Null (.ToString() an toàn)
                    txt_madk.Text = row.Cells["MaDK"].Value?.ToString() ?? "";
                    txt_bienso.Text = row.Cells["BienSo"].Value?.ToString() ?? "";
                    txt_hotenchuxe.Text = row.Cells["HoTenChuXe"].Value?.ToString() ?? "";
                    txt_sdt.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                    txt_mausac.Text = row.Cells["MauSac"].Value?.ToString() ?? "";
                    // Xử lý MaThe an toàn
                    if (row.Cells["MaThe"].Value != null && row.Cells["MaThe"].Value != DBNull.Value)
                    {
                        maTheCu = Convert.ToInt32(row.Cells["MaThe"].Value);

                        // TỐI ƯU: Chỉ nạp lại ComboBox nếu thực sự cần thiết, 
                        // hoặc tốt nhất nên nạp sẵn danh sách thẻ từ lúc Load Form.
                        cbo_mathe.DataSource = ThongTinXeThangBUS.LayTheTrongVaTheDangChon(maTheCu);
                        cbo_mathe.DisplayMember = "MaThe"; // Phải có dòng này
                        cbo_mathe.ValueMember = "MaThe";   // Phải có dòng này
                        cbo_mathe.SelectedValue = maTheCu;
                    }

                    // Xử lý Ngày tháng (Tránh lỗi nếu ô ngày tháng bị trống)
                    if (row.Cells["NgayDangKy"].Value != DBNull.Value)
                        dtp_ngaydangky.Value = Convert.ToDateTime(row.Cells["NgayDangKy"].Value);

                    if (row.Cells["NgayHetHan"].Value != DBNull.Value)
                        dtp_ngayhethan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);

                    // Xử lý Loại xe
                    if (row.Cells["MaLoaiXe"].Value != null)
                        cbo_loaixe.SelectedValue = row.Cells["MaLoaiXe"].Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message);
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo_mathe.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn mã thẻ tháng!");
                    return;
                }
                if (Convert.ToInt32(cbo_mathe.SelectedValue)==maTheCu)
                {
                    MessageBox.Show("Mã thẻ đã được sử dụng. Vui lòng chọn mã thẻ khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }    
                if (dtp_ngayhethan.Value < dtp_ngaydangky.Value)
                {
                    MessageBox.Show("Ngày hết hạn không nhỏ hơn ngày đăng ký!", "Thông báo lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng hàm, không thực hiện lưu vào Database nữa
                }
                ThongTinXeThangDTO xe = new ThongTinXeThangDTO
                {
                    BienSo = txt_bienso.Text,
                    MauSac = txt_mausac.Text,
                    MaLoaiXe = (int)cbo_loaixe.SelectedValue,
                    HoTenChuXe = txt_hotenchuxe.Text,
                    SDT = txt_sdt.Text,
                    MaThe = (int)cbo_mathe.SelectedValue, // Lấy từ ComboBox
                    NgayDangKy = dtp_ngaydangky.Value,
                    NgayHetHan = dtp_ngayhethan.Value
                };

                if (ThongTinXeThangBUS.ThemXeDKT(xe))
                {
                    MessageBox.Show("Đăng ký xe tháng thành công!");
                    RefreshALL();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            RefreshALL();
        }

        private void btn_dieuchinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo_mathe.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn mã thẻ để điêu chỉnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 1. Tạo DTO với dữ liệu mới từ Form
                ThongTinXeThangDTO xe = new ThongTinXeThangDTO
                {
                    MaDK = int.Parse(txt_madk.Text),
                    BienSo = txt_bienso.Text,
                    MauSac = txt_mausac.Text,
                    MaLoaiXe = (int)cbo_loaixe.SelectedValue,
                    HoTenChuXe = txt_hotenchuxe.Text,
                    SDT = txt_sdt.Text,
                    MaThe = (int)cbo_mathe.SelectedValue, // Đây là mã thẻ MỚI người dùng chọn
                    NgayHetHan = dtp_ngayhethan.Value
                };

                // 2. Gọi BUS và truyền thêm maTheCu
                if (ThongTinXeThangBUS.SuaXeDKT(xe, maTheCu))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    RefreshALL(); // Hàm load lại DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào chưa (thường qua txt_madk)
            if (string.IsNullOrEmpty(txt_madk.Text))
            {
                MessageBox.Show("Vui lòng chọn xe tháng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hiện hộp thoại xác nhận để tránh bấm nhầm
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa xe này? Thẻ xe sẽ được trả về trạng thái 'Trống'.",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // 3. Lấy thông tin từ Form (đã nạp từ CellClick)
                    int maDK = int.Parse(txt_madk.Text);

                    // Lấy MaThe từ ComboBox hoặc từ biến maTheCu đã lưu lúc CellClick
                    int maThe = Convert.ToInt32(cbo_mathe.SelectedValue);

                    // 4. Gọi xuống tầng BUS
                    if (ThongTinXeThangBUS.XoaXeThang(maDK, maThe))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshALL();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void RefreshALL()
        {
            // 1. Xóa trống các TextBox
            txt_madk.Clear();
            txt_bienso.Clear();
            txt_hotenchuxe.Clear();
            txt_sdt.Clear();
            txt_mausac.Clear();

            // 2. Đặt lại ngày tháng về mặc định (Ngày hiện tại và 1 tháng sau)
            dtp_ngaydangky.Value = DateTime.Now;
            dtp_ngayhethan.MinDate = DateTime.Parse("1753-01-01");
            dtp_ngayhethan.Value = DateTime.Now.AddMonths(1);

            // Sau đó mới khóa MinDate theo ngày đăng ký hiện tại
            dtp_ngayhethan.MinDate = dtp_ngaydangky.Value;

            // 3. Reset các ComboBox
            // Với Loại xe: Chọn mục đầu tiên hoặc để trống
            if (cbo_loaixe.Items.Count > 0)
                cbo_loaixe.SelectedIndex = 0;

            // Với Mã thẻ: Quan trọng nhất là chỉ hiện thẻ đang "Trống" để đăng ký mới
            LoadLoaiXe();
            LoadTheXe(); 

            // 4. Reset biến lưu trữ tạm thời
            maTheCu = -1;

            // 5. Tải lại dữ liệu mới nhất lên DataGridView (để cập nhật Trạng thái/Tên loại xe)
            LoadData();
        }

        private void txt_bienso_TextChanged(object sender, EventArgs e)
        {
            txt_bienso.CharacterCasing = CharacterCasing.Upper;
            
        }
        private void txt_bienso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ

            }
        }
        
    }

}
