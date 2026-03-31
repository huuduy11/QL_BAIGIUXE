using DOAN_WF.BUS;
using DOAN_WF.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DOAN_WF.DAL;  
namespace DOAN_WF.GUI
{
    public partial class frm_nhapxuatxe : Form
    {
        // Khởi tạo các lớp nghiệp vụ (BUS)
        LoaiTheBUS LoaiTheBUS = new LoaiTheBUS();
        LoaiXeBUS LoaiXeBUS = new LoaiXeBUS();
        TheXeBUS TheXeBUS = new TheXeBUS();
        ThongTinXeVaoBUS ThongTinXeVaoBUS = new ThongTinXeVaoBUS();
        ThongTinXeRaBUS ThongTinXeRaBUS = new ThongTinXeRaBUS();
        ThongTinXeThangBUS xeThangBUS = new ThongTinXeThangBUS();
        public frm_nhapxuatxe()
        {
            InitializeComponent();
        }

        private void frm_nhapxuatxe_Load(object sender, EventArgs e)
        {
            StartTimers();
            RefreshData();
            btn_xuatbai.BackColor = SystemColors.Control;
            btn_xuatbai.Enabled = false;
            lbl_thoigianvao.Text= DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lbl_thoigianra.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            LoadDGV();

        }

        // --- NHÓM HÀM LOAD DỮ LIỆU ---
        private void StartTimers()
        {
            timer_capnhatthoigianvao.Start();
            timer_thgianra.Start();

        }
        public void Loadloaithe()
        {
            cmb_loaithe.DataSource = LoaiTheBUS.Laydanhsachloaithe();
            cmb_loaithe.DisplayMember = "TenLoaiThe";
            cmb_loaithe.ValueMember = "MaLoaiThe";

            // Thêm dòng này để kích hoạt sự kiện nhảy số ngay khi load
            cmb_loaithe_SelectedIndexChanged_1(null, null);
        }
        public void Loadloaixe()
        {
            cmb_loaixevao.DataSource = LoaiXeBUS.Laydanhsachloaixe();
            cmb_loaixevao.DisplayMember = "TenLoaiXe";
            cmb_loaixevao.ValueMember = "MaLoaiXe";
        }
        private void LoadDGV()
        {
            var data = ThongTinXeVaoBUS.LayThongTinXeVao();

            dgv_thongtinxevao.DataSource = data.Select(item => new

            {

                item.MaThe,
                // Nếu MaLoaiThe là 1 thì hiện "Vãng lai", ngược lại hiện "Thẻ tháng"
                LoaiThe = item.MaLoaiThe == 1 ? "Vãng lai" : "Thẻ tháng",
                item.BienSoVao,
                LoaiXe = item.TenLoaiXe,
                GioVao = item.ThoiGianVao,
                NhanVien = item.TenNV,
                TrangThai = item.TrangThaiTrongBai ? "Trong bãi" : "Đã ra"

            }).ToList();
            dgv_thongtinxevao.RowHeadersVisible = true;
            dgv_thongtinxevao.TopLeftHeaderCell.Value = "STT";
            dgv_thongtinxevao.Columns["LoaiThe"].HeaderText = "Loại Thẻ";
            dgv_thongtinxevao.Columns["MaThe"].HeaderText = "Mã Thẻ";
            dgv_thongtinxevao.Columns["BienSoVao"].HeaderText = "Biển Số";
            dgv_thongtinxevao.Columns["LoaiXe"].HeaderText = "Loại Xe";
            dgv_thongtinxevao.Columns["GioVao"].HeaderText = "Giờ Vào";
            dgv_thongtinxevao.Columns["NhanVien"].HeaderText = "NV Trực Ca";
            dgv_thongtinxevao.Columns["TrangThai"].HeaderText = "Trạng Thái";

            // định dạng lại cột thời gian và cho dễ nhìn

            dgv_thongtinxevao.Columns["GioVao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            dgv_thongtinxevao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự giãn đều
        }

       // Sự kiện chính

        private void btn_nhapbai_Click_1(object sender, EventArgs e)
        {
            // 1. Kiểm tra biển số trống

            if (string.IsNullOrEmpty(txt_biensovao.Text))
            {
                MessageBox.Show("Vui lòng nhập biển số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int loaiTheChon = (int)cmb_loaithe.SelectedValue;
                int maTheNhap = int.Parse(txt_mathevao.Text);

                // 2. CHẶN ĐẦU VÀO: KIỂM TRA RIÊNG CHO THẺ THÁNG (Phải làm trước khi Nhập bài)
                if (loaiTheChon == 2) // ID 2 là Thẻ tháng
                {
                    if (TheXeBUS.IsTheThangDangTrongBai(maTheNhap))
                    {
                        MessageBox.Show("Thẻ tháng này hiện đã có xe trong bãi!",
                                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Chặn đứng thao tác nhập bãi
                    }
                    if (!TheXeBUS.KiemTraTheThangHopLe(maTheNhap))
                    {
                        MessageBox.Show("Mã thẻ này không tồn tại hoặc chưa được đăng ký trong danh sách thẻ tháng!",
                                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_biensovao.Clear();
                        txt_mathevao.Clear();
                        txt_mathevao.Focus();
                        return; // DỪNG LẠI NGAY TẠI ĐÂY, không chạy code phía dưới nữa
                    }
                }

                // 3. Nếu mọi thứ OK thì mới bắt đầu xử lý nhập bãi
                LichSuVaoRaDTO xeVao = new LichSuVaoRaDTO();
                xeVao.MaThe = maTheNhap;
                xeVao.BienSoVao = txt_biensovao.Text.Trim().ToUpper();
                xeVao.MaLoaiXe = (int)cmb_loaixevao.SelectedValue;
                xeVao.MaNV = LuuPhienDangNhap.CurrentUser.MaNV;

                if (ThongTinXeVaoBUS.NhapBai(xeVao))
                {
                    // Cập nhật trạng thái thẻ
                    TheXeBUS.CapNhatTrangThaiThe(xeVao.MaThe, "Đang sử dụng");

                    MessageBox.Show("Xe vào bãi thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật UI
                    lbl_soluongthevanglaiconlai.Text = ThongTinXeVaoBUS.DemTheVangLaiTrong().ToString();
                    RefreshData();
                    LoadDGV();

                    // Tự động nhảy mã thẻ vãng lai tiếp theo (nếu là loại vãng lai)
                    if (loaiTheChon == 1)
                    {
                        int maMoi = TheXeBUS.LayMaTheVangLaiTĐ(1);
                        txt_mathevao.Text = maMoi != 0 ? maMoi.ToString() : "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_xuatbai_Click_1(object sender, EventArgs e)
        {
            //  Kiểm tra đầu vào an toàn

            if (!int.TryParse(txt_mathera.Text, out int maThe))

            {

                MessageBox.Show("Mã thẻ không hợp lệ!");
                return;

            }
            //  Lấy số tiền an toàn (loại bỏ mọi ký tự không phải số trừ dấu phẩy/chấm thập phân)

            string cleanAmount = new string(lbl_tongtien.Text.Where(c => char.IsDigit(c)).ToArray());

            decimal.TryParse(cleanAmount, out decimal tien);

            string bsRa = txt_biensora.Text.Trim();

            if (ThongTinXeRaBUS.XacNhanXeRa(maThe, bsRa, tien))

            {

                MessageBox.Show("Xe đã ra khỏi bãi!");

                LoadDGV();

                btn_xuatbai.Enabled = false;

                btn_xuatbai.BackColor = SystemColors.Control; // Đổi màu về mặc định để rõ ràng hơn

                // Xóa trắng để tránh nhầm với xe sau
                lbl_thoigianvaoxuat.Text = "";
                txt_mathera.Clear();
                txt_mathevao.Clear();
                txt_biensovao.Clear();
                txt_biensora.Clear();
                lbl_thongbao.Text = "";
                lbl_loaixera2.Text = "";
                lbl_tongtien.Text = "";
                lbl_soluongthevanglaiconlai.Text = ThongTinXeVaoBUS.DemTheVangLaiTrong().ToString();
            }

        }
        // --- CÁC SỰ KIỆN KHÁC ---
        private void cmb_loaithe_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn gì thì thoát

            if (cmb_loaithe.SelectedValue == null || !(cmb_loaithe.SelectedValue is int)) return;



            int maLoaiThe = (int)cmb_loaithe.SelectedValue;



            if (maLoaiThe == 1) // Giả sử 1 là ID của Thẻ Vãng Lai trong DB

            {

                int maTuDong = TheXeBUS.LayMaTheVangLaiTĐ(maLoaiThe);



                if (maTuDong != 0)

                {

                    txt_mathevao.Text = maTuDong.ToString();

                    txt_mathevao.ReadOnly = true; // Khóa lại, không cho sửa mã vãng lai

                    txt_mathevao.BackColor = Color.WhiteSmoke;

                    txt_mathevao.Cursor = Cursors.No; // Đổi con trỏ chuột để rõ ràng hơn

                }

                else

                {

                    txt_mathevao.Text = "";

                    MessageBox.Show("Hết thẻ vãng lai trống!");

                }

            }

            else // Thẻ Tháng nếu id=2 

            {

                txt_mathevao.ReadOnly = false; // Mở khóa để tự nhập mã thẻ tháng

                txt_mathevao.BackColor = Color.White;

                txt_mathevao.Cursor = Cursors.Default;

                txt_mathevao.Text = "";

                txt_mathevao.Focus();

            }
        }
        

        private void txt_mathera_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!int.TryParse(txt_mathera.Text, out int maThe)) return;

                DataTable dt = ThongTinXeRaBUS.LayDuLieuXuat(maThe,"");

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    txt_biensora.Text = r["BienSoVao"].ToString();
                    lbl_loaixera2.Text = r["TenLoaiXe"].ToString();

                    DateTime vao = (DateTime)r["ThoiGianVao"];
                    lbl_thoigianvaoxuat.Text = vao.ToString("dd/MM/yyyy HH:mm:ss");
                    lbl_thoigianra.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    // --- ĐOẠN SỬA QUAN TRỌNG NHẤT ---
                    if (r["TenLoaiThe"].ToString() == "Thẻ tháng")
                    {
                        lbl_tongtien.Text = "0 VND";
                    }
                    else
                    {
                        // Lấy đơn giá GiaTheoGio từ bảng LoaiXe (thông qua câu Join trong DAL)
                        decimal donGia = Convert.ToDecimal(r["GiaTheoGio"]);
                        // Gọi BUS tính tiền dựa trên đơn giá
                        decimal thanhTien = ThongTinXeRaBUS.TinhTienGuiXe(vao, DateTime.Now, donGia);
                        lbl_tongtien.Text = thanhTien.ToString("N0") + " VND";
                    }
                    // -------------------------------

                    btn_xuatbai.Enabled = true;
                    btn_xuatbai.BackColor = Color.Red;
                    btn_xuatbai.Focus();
                }
                else
                {
                    MessageBox.Show("Thẻ không có trong bãi!");
                    btn_xuatbai.Enabled = false;
                }
            }
        }
        private void txt_biensora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string bienSoRa = txt_biensora.Text.Trim();
                if (string.IsNullOrEmpty(bienSoRa)) return;

                // Gọi BUS
                DataTable dt = ThongTinXeRaBUS.LayDuLieuXuat(0, bienSoRa);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];

                    // 1. Cập nhật các TextBox/Label
                    txt_mathera.Text = r["MaThe"].ToString(); // Đảm bảo cột MaThe có trong câu SELECT
                    lbl_loaixera2.Text = r["TenLoaiXe"].ToString();

                    // 2. Xử lý thời gian (Dùng Convert để an toàn hơn)
                    DateTime vao = Convert.ToDateTime(r["ThoiGianVao"]);
                    lbl_thoigianvaoxuat.Text = vao.ToString("dd/MM/yyyy HH:mm:ss");
                    lbl_thoigianra.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    // 3. Tính tiền
                    if (r["TenLoaiThe"].ToString() == "Thẻ tháng")
                    {
                        lbl_tongtien.Text = "0 VND";
                    }
                    else
                    {
                        decimal donGia = Convert.ToDecimal(r["GiaTheoGio"]);
                        decimal thanhTien = ThongTinXeRaBUS.TinhTienGuiXe(vao, DateTime.Now, donGia);
                        lbl_tongtien.Text = thanhTien.ToString("N0") + " VND";
                    }

                    // 4. Trạng thái nút bấm
                    btn_xuatbai.Enabled = true;
                    btn_xuatbai.BackColor = Color.Red;
                    btn_xuatbai.Focus();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy xe này trong bãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btn_xuatbai.Enabled = false;
                    btn_xuatbai.BackColor = Color.Gray;
                    txt_biensora.Focus();
                    txt_biensora.SelectAll();
                }
            }
        }
        private void timer_capnhatthoigianvao_Tick_1(object sender, EventArgs e)
        {
            lbl_thoigianvao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void timer_thgianra_Tick(object sender, EventArgs e)
        {
            lbl_thoigianra.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        private void RefreshData()
        {
            Loadloaithe();
            Loadloaixe();
            LoadDGV();
            lbl_soluongthevanglaiconlai.Text = ThongTinXeVaoBUS.DemTheVangLaiTrong().ToString();
            txt_biensovao.Clear();
            txt_biensovao.Focus();
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txt_mathevao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn không cho nhập ký tự khác số
            }
        }

        private void txt_mathera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn không cho nhập ký tự khác số
            }
        }
        // Lấy số thứ tự 
        private void dgv_thongtinxevao_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string stt = (dgv_thongtinxevao.Rows.Count - e.RowIndex).ToString();

            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(stt, dgv_thongtinxevao.Font, brush,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txt_biensovao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
               
            }
        }

        private void txt_biensovao_TextChanged(object sender, EventArgs e)
        {
            txt_biensovao.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_biensora_TextChanged(object sender, EventArgs e)
        {
            txt_biensora.CharacterCasing = CharacterCasing.Upper;
        }

        private void dgv_thongtinxevao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_mathera.Text = dgv_thongtinxevao.CurrentRow.Cells["MaThe"].Value.ToString();
            txt_biensora.Text= dgv_thongtinxevao.CurrentRow.Cells["BienSoVao"].Value.ToString();
            if (!int.TryParse(txt_mathera.Text, out int maThe)) return;
            DataTable dt = ThongTinXeRaBUS.LayDuLieuXuat(maThe,"");

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                txt_biensora.Text = r["BienSoVao"].ToString();
                lbl_loaixera2.Text = r["TenLoaiXe"].ToString();

                DateTime vao = (DateTime)r["ThoiGianVao"];
                lbl_thoigianvaoxuat.Text = vao.ToString("dd/MM/yyyy HH:mm:ss");
                lbl_thoigianra.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                // --- ĐOẠN SỬA QUAN TRỌNG NHẤT ---
                if (r["TenLoaiThe"].ToString() == "Thẻ tháng")
                {
                    lbl_tongtien.Text = "0 VND";
                }
                else
                {
                    // Lấy đơn giá GiaTheoGio từ bảng LoaiXe (thông qua câu Join trong DAL)
                    decimal donGia = Convert.ToDecimal(r["GiaTheoGio"]);
                    // Gọi BUS tính tiền dựa trên đơn giá
                    decimal thanhTien = ThongTinXeRaBUS.TinhTienGuiXe(vao, DateTime.Now, donGia);
                    lbl_tongtien.Text = thanhTien.ToString("N0") + " VND";
                }
                // -------------------------------

                btn_xuatbai.Enabled = true;
                btn_xuatbai.BackColor = Color.Red;
                btn_xuatbai.Focus();
            }
            else
            {
                MessageBox.Show("Thẻ không có trong bãi!");
                btn_xuatbai.Enabled = false;
            }

        }

        private void txt_mathevao_TextChanged(object sender, EventArgs e)
        {
            // 1. Kiểm tra nếu đang chọn loại thẻ là "Thẻ tháng" (giả sử ID là 2)
            // Kiểm tra loại thẻ
            if (cmb_loaithe.SelectedValue != null && (int)cmb_loaithe.SelectedValue == 2)
            {
                string input = txt_mathevao.Text.Trim();

                // Chỉ xử lý khi nhập ĐỦ 3 số
                if (input.Length == 3)
                {
                    if (int.TryParse(input, out int maTheInt))
                    {
                        // Kiểm tra vùng mã thẻ 800 - 820 như bạn muốn
                        if (maTheInt < 800 || maTheInt > 820)
                        {
                            lbl_thongbao.Text = "Mã thẻ tháng phải từ 800!";
                            lbl_thongbao.ForeColor = Color.Red;
                            return;
                        }

                        DataTable dt = xeThangBUS.LayTenLoaiXeThang(maTheInt);

                        if (dt.Rows.Count > 0)
                        {
                            txt_biensovao.Text = dt.Rows[0]["BienSo"].ToString();
                            cmb_loaixevao.Text = dt.Rows[0]["TenLoaiXe"].ToString();

                            DateTime ngayHetHan = Convert.ToDateTime(dt.Rows[0]["NgayHetHan"]);
                            if (ngayHetHan < DateTime.Now)
                            {
                                lbl_thongbao.Text = "THẺ HẾT HẠN (" + ngayHetHan.ToString("dd/MM/yyyy") + ")";
                                lbl_thongbao.ForeColor = Color.Red;
                                btn_nhapbai.Enabled = false; // Khóa nút nhập bãi cho chắc
                            }
                            else
                            {
                                lbl_thongbao.Text = "Thẻ hợp lệ. Mời vào!";
                                lbl_thongbao.ForeColor = Color.Green;
                                btn_nhapbai.Enabled = true;

                                // Tự động nhảy con trỏ sang nút Nhập bãi hoặc ô khác
                                btn_nhapbai.Focus();
                            }
                        }
                        else
                        {
                           
                            lbl_thongbao.Text = "Mã thẻ chưa đăng ký xe tháng!";
                            lbl_thongbao.ForeColor = Color.Orange;
                            txt_mathevao.Clear();
                            txt_mathevao.Focus();
                        }
                    }
                }
                else
                {
                    // Nếu chưa nhập đủ 3 số thì xóa thông tin cũ đang hiện
                    
                    lbl_thongbao.Text = "Đang nhập mã thẻ...";
                    lbl_thongbao.ForeColor = Color.Black;
                }
            }
        }
      
        private void txt_mathevao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Tránh tiếng "beep" mặc định của Windows khi nhấn Enter
                e.SuppressKeyPress = true;

                int loaiTheChon = (int)cmb_loaithe.SelectedValue;

                // Nếu là Thẻ tháng (ID = 2)
                if (loaiTheChon == 2)
                {
                    if (int.TryParse(txt_mathevao.Text, out int maThe))
                    {
                        // Gọi xuống BUS để lấy biển số đã đăng ký của thẻ này
                        // Bạn cần viết thêm hàm LayBienSoXeThang trong TheXeBUS
                        string bienSo = TheXeBUS.LayBienSoXeThang(maThe);

                        if (!string.IsNullOrEmpty(bienSo))
                        {
                            txt_biensovao.Text = bienSo;
                            // Sau khi tự điền biển số, gọi luôn hàm Nhập bãi
                            btn_nhapbai_Click_1(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Mã thẻ này không tồn tại hoặc chưa được đăng ký trong danh sách thẻ tháng!",
                            "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else // Nếu là thẻ vãng lai thì Enter sẽ nhảy sang ô biển số
                {
                    txt_biensovao.Focus();
                }
            }
        }
    }
}