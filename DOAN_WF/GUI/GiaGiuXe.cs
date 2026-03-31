using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiaBUS;
using GiaDAL;

namespace DOAN_WF.GUI
{
    public partial class GiaGiuXe : Form
    {
        GiaXeBUS bus = new GiaXeBUS();
        

        public GiaGiuXe()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ tầng BUS
                DataTable dt = bus.GetAllGia();
                dgv_giatien.DataSource = dt;
                dgv_giatien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgv_giatien.GridColor = Color.FromArgb(224, 224, 224);
                if (dgv_giatien.Columns.Count > 0)
                {

                    // Ẩn các cột không cần thiết cho người dùng thấy
                    if (dgv_giatien.Columns.Contains("MaLoaiXe")) dgv_giatien.Columns["MaLoaiXe"].Visible = false;
                    if (dgv_giatien.Columns.Contains("NhomXe")) dgv_giatien.Columns["NhomXe"].Visible = false;

                    // Giãn đều các cột full màn hình
                    dgv_giatien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Đổi tên tiêu đề cột (Dùng if để tránh lỗi NullReferenceException)
                    if (dgv_giatien.Columns.Contains("TenLoaiXe"))
                        dgv_giatien.Columns["TenLoaiXe"].HeaderText = "Tên Loại Xe";

                    if (dgv_giatien.Columns.Contains("GiaTheoGio"))
                    {
                        dgv_giatien.Columns["GiaTheoGio"].HeaderText = "Giá Theo Giờ (VNĐ)";
                        dgv_giatien.Columns["GiaTheoGio"].DefaultCellStyle.Format = "N0"; // Hiện 5,000
                    }

                    if (dgv_giatien.Columns.Contains("GiaTheoThang"))
                    {
                        dgv_giatien.Columns["GiaTheoThang"].HeaderText = "Giá Theo Tháng (VNĐ)";
                        dgv_giatien.Columns["GiaTheoThang"].DefaultCellStyle.Format = "N0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            dgv_giatien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void GiaGiuXe_Load(object sender, EventArgs e)
        {
            LoadData(); // Bạn thiếu dòng này nên bảng bị trống
        }

        private void btn_dieuchinh_Click(object sender, EventArgs e)
        {
            if (dgv_giatien.CurrentRow != null)
            {
                frmCapNhatGia f = new frmCapNhatGia();
                // Lấy dữ liệu từ dòng đang chọn
                f.maLoai = Convert.ToInt32(dgv_giatien.CurrentRow.Cells["MaLoaiXe"].Value);
                f.tenLoai = dgv_giatien.CurrentRow.Cells["TenLoaiXe"].Value.ToString();
                f.giaNgay = Convert.ToDecimal(dgv_giatien.CurrentRow.Cells["GiaTheoGio"].Value);
                f.giaThang = Convert.ToDecimal(dgv_giatien.CurrentRow.Cells["GiaTheoThang"].Value);

                if (f.ShowDialog() == DialogResult.OK) // Nếu form sửa trả về OK
                {
                    LoadData(); // Load lại bảng ngay lập tức
                }
            }
        }

        private void dgv_giatien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_giatien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
