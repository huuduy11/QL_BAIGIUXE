using DoAn_demo.GUI;
using DOAN_WF.BUS;
using DOAN_WF.DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace DOAN_WF.GUI
{
    public partial class frm_main : Form
    {
        private Form currentFormChild;

        public frm_main()
        {
            InitializeComponent();
        }
        NhanVienBUS nvBUS = new NhanVienBUS();
        bool daXacNhanCa = false; // Biến cờ để theo dõi xem ca đã được xác nhận hay chưa
        private void frm_main_Resize(object sender, EventArgs e)
        {
            if (pnl_overlay.Visible)
            {
                // Overlay luôn phải bám sát kích thước Form
                pnl_overlay.Bounds = this.ClientRectangle;

                // Popup luôn nằm giữa
                pnl_ChonNV.Left = (this.ClientSize.Width - pnl_ChonNV.Width) / 2;
                pnl_ChonNV.Top = (this.ClientSize.Height - pnl_ChonNV.Height) / 2;
            }
        }
        private void frm_main_Load(object sender, EventArgs e)
        {
            PoupChonNV();
            Botronpnl(pnl_ChonNV, 5);
            // Hiển thị quyền đăng nhập
            if (LuuPhienDangNhap.CurrentUser != null)
            {
                lbl_quyendangdangnhap.Text = LuuPhienDangNhap.CurrentUser.Quyen?.TenQuyen ?? "Không xác định";
            }
            // Phân Quyền
            SetupMenuUI();
            // MẶC ĐỊNH: Mở form Nhập Xuất Xe ngay khi load xong Form Main
            btn_hethong_Click(null, null);
            //
        }
        private void Botronpnl(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            // Tạo 4 cung bo góc
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90); // Góc trên trái
            path.AddArc(pnl.Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90); // Góc trên phải
            path.AddArc(pnl.Width - (radius * 2), pnl.Height - (radius * 2), radius * 2, radius * 2, 0, 90); // Góc dưới phải
            path.AddArc(0, pnl.Height - (radius * 2), radius * 2, radius * 2, 90, 90); // Góc dưới trái
            path.CloseFigure();
            pnl.Region = new Region(path); // Gán vùng bo góc cho panel
        }
        public void PoupChonNV()
        {
            cbo_nhanvien_popup.DataSource = nvBUS.LayDanhSachNhanVien();
            cbo_nhanvien_popup.DisplayMember = "TenNV";
            cbo_nhanvien_popup.ValueMember = "MaNV";
            pnl_overlay.Parent = this;
            pnl_overlay.Dock = DockStyle.None; // Tắt Dock để tự chỉnh Size
            pnl_overlay.Bounds = this.ClientRectangle; // Lấy toàn bộ diện tích bên trong Form
            pnl_overlay.Visible = true;
            pnl_overlay.BringToFront(); // Đưa lớp mờ lên trên tất cả các panel bãi xe

            // 3. Đưa Popup lên trên cùng của lớp mờ
            pnl_ChonNV.Parent = this;
            pnl_ChonNV.BringToFront();

            // Căn giữa lại khung trắng
            pnl_ChonNV.Left = (this.ClientSize.Width - pnl_ChonNV.Width) / 2;
            pnl_ChonNV.Top = (this.ClientSize.Height - pnl_ChonNV.Height) / 2;
        }
        private void btn_XacNhanCa_Click(object sender, EventArgs e)
        {
            if (cbo_nhanvien_popup.SelectedValue != null)
            {
                // 1. Gán MaNV thực tế vào phiên làm việc toàn cục
                int maNV = (int)cbo_nhanvien_popup.SelectedValue;
                string tenNV = cbo_nhanvien_popup.Text;

                LuuPhienDangNhap.CurrentUser.MaNV = maNV;
                LuuPhienDangNhap.CurrentUser.TenNV = tenNV;

                // 2. Đánh dấu đã xác nhận và đóng Popup
                daXacNhanCa = true;
                pnl_overlay.Visible = false;
                pnl_ChonNV.Visible = false;

                // 3. Hiển thị thông báo chào hỏi
                MessageBox.Show($"Chào {tenNV}! Hệ thống đã ghi nhận bạn trực ca này.", "Thông báo");
            }
        }
        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 1. Kiểm tra nếu người dùng nhấn nút X đỏ hoặc Alt+F4
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Nếu chưa xác nhận ca, hỏi người dùng
                if (!daXacNhanCa)
                {
                    DialogResult result = MessageBox.Show("Bạn chưa chọn nhân viên trực ca. Bạn có muốn thoát hẳn chương trình không?",
                                                          "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // THOÁT HẲN: Đây là chỗ quan trọng để không bị lỗi file bị khóa (Locked)
                        daXacNhanCa = true; // Bật cờ để thoát kiểm tra
                        Application.ExitThread(); // Ngắt tất cả các luồng đang chạy
                        Environment.Exit(0);      // Đảm bảo tiến trình biến mất khỏi Task Manager
                    }
                    else if (result == DialogResult.No)
                    {
                        // QUAY LẠI LOGIN: Giải phóng Main và mở lại Login mới từ đầu
                        daXacNhanCa = true;
                        this.Dispose();           // Giải phóng tài nguyên Form Main ngay lập tức
                        Application.Restart();    // Khởi động lại app (sẽ tự hiện Form Login sạch)
                    }
                    else
                    {
                        // HỦY: Không đóng Form nữa, ở lại Form Main
                        e.Cancel = true;
                    }
                }
                else
                {
                    // Nếu đã xác nhận ca rồi mà vẫn nhấn X thì thoát sạch sẽ
                    Environment.Exit(0);
                }
            }
        }
        private void SetupMenuUI()
        {

            pnl_quanlysub.Visible = true;
            pnl_danhmuc.Visible = true;
            pnl_baocaotongquat.Visible = true;
        }

        // --- HÀM MỞ FORM CON ---
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null) currentFormChild.Close();

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            pnl_right.Controls.Clear();          // Xóa các form cũ đang hiện trong panel
            pnl_right.Controls.Add(childForm);   // Thêm form mới vào panel
            pnl_right.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // --- XỬ LÝ CÁC NÚT MENU ---

        // Giả sử nút "Hệ thống" hoặc "Ra vào xe" của bạn là btn_hethong
        private void btn_hethong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_nhapxuatxe());
        }

        private void btn_quanlynhansu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_quanlynhansu());

        }

        private void btn_danhmuc_Click(object sender, EventArgs e)
        {
            pnl_danhmuc.Visible = !pnl_danhmuc.Visible;
            btn_danhmuc.Image = pnl_danhmuc.Visible ? Properties.Resources.up_arrow : Properties.Resources.down_arrow;
        }

        private void btn_baocaotongquat_Click(object sender, EventArgs e)
        {
            pnl_baocaotongquat.Visible = !pnl_baocaotongquat.Visible;
            btn_baocaotongquat.Image = pnl_baocaotongquat.Visible ? Properties.Resources.up_arrow : Properties.Resources.down_arrow;
        }

        private void btn_quanly_Click_1(object sender, EventArgs e)
        {
            pnl_quanlysub.Visible = !pnl_quanlysub.Visible;
            btn_quanly.Image = pnl_quanlysub.Visible ? Properties.Resources.up_arrow : Properties.Resources.down_arrow;
        }

        

        private void btn_nhapxuatbai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_nhapxuatxe());
        }

        private void btn_lichsuravao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_lichsuvaora());
        }

        private void btn_dangxuat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xác nhận đăng xuất?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LuuPhienDangNhap.CurrentUser = null;
                daXacNhanCa = true; // Bật cờ để FormClosing không hỏi nữa

                // Chỉ cần Restart, nó sẽ tự đóng các Form hiện tại và chạy lại Main()
                Application.Restart();
            }
        }
       
        private void btn_suco_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_suco());
        }

        private void btn_qldoanhthu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_qldoanhthu());
        }

        private void btn_qlxethang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_quanlyxethang());
        }

        private void btn_giagiuxe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GiaGiuXe());
        }

        private void btn_danhmucloaixe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoaiXeGui());
        }

        
    }
}