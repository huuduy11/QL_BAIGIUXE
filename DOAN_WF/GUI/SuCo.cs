using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOAN_WF.BUS;
namespace DOAN_WF.GUI
{
    public partial class frm_suco : Form
    {
        SuCoBUS bus = new SuCoBUS();
        public frm_suco()
        {
            InitializeComponent();
        }

        string ChuanHoaTrangThai(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            input = input.Trim().ToLower();

            // bỏ dấu để so sánh
            string khongDau = RemoveDiacritics(input);

            if (khongDau.Contains("da"))
                return "Đã xử lý";

            if (khongDau.Contains("chua"))
                return "Chưa xử lý";

            return "Chưa xử lý"; // mặc định luôn (khỏi bắt nhập lại)
        }

        string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                if (Char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        void FormatGrid()
        {
            dgv_thongtinsuco.Columns["MaSuCo"].HeaderText = "Mã Sự Cố";
            dgv_thongtinsuco.Columns["MalS"].HeaderText = "Mã LS";
            dgv_thongtinsuco.Columns["LoaiSuCo"].HeaderText = "Loại Sự Cố";
            dgv_thongtinsuco.Columns["MoTa"].HeaderText = "Mô Tả";
            dgv_thongtinsuco.Columns["ThoiGian"].HeaderText = "Thời Gian";
            dgv_thongtinsuco.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgv_thongtinsuco.Columns["TrangThaiXuLy"].HeaderText = "Trạng Thái Xử Lý";

            dgv_thongtinsuco.EnableHeadersVisualStyles = false;
            dgv_thongtinsuco.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_thongtinsuco.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_thongtinsuco.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_thongtinsuco.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv_thongtinsuco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void LoadTrangThai()
        {

            DataTable dt = bus.TrangThaiXuLy();

            DataRow row = dt.NewRow();
            row["TrangThaiXuLy"] = "Tất cả";
            dt.Rows.InsertAt(row, 0);

            cmb_trangthai.DataSource = dt;
            cmb_trangthai.DisplayMember = "TrangThaiXuLy";
        }
        bool isLoaded = false;
        private void frm_suco_Load(object sender, EventArgs e)
        {
            LoadTrangThai();
            LoadDGV();
            Child_BaoCaoSuCoBUS buss = new Child_BaoCaoSuCoBUS();
            dgv_thongtinsuco.DataSource = buss.GetDanhSachSuCo();
            FormatGrid();

            isLoaded = true;// bật cho phép lọc
            cmb_trangthai_SelectedIndexChanged(null, null);
        }
        private void LoadDGV()
        {
            DataTable dt = bus.Thongtinsuco();
            dgv_thongtinsuco.DataSource = dt;
            dgv_thongtinsuco.Columns["MaSuCo"].HeaderText = "Mã Sự Cố";
            dgv_thongtinsuco.Columns["MalS"].HeaderText = "Mã LS";
            dgv_thongtinsuco.Columns["LoaiSuCo"].HeaderText = "Loại Sự Cố";
            dgv_thongtinsuco.Columns["MoTa"].HeaderText = "Mô Tả";
            dgv_thongtinsuco.Columns["ThoiGian"].HeaderText = "Thời Gian";
            dgv_thongtinsuco.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgv_thongtinsuco.Columns["TrangThaiXuLy"].HeaderText = "Trạng Thái Xử Lý";

            dgv_thongtinsuco.EnableHeadersVisualStyles = false;
            dgv_thongtinsuco.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_thongtinsuco.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_thongtinsuco.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_thongtinsuco.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv_thongtinsuco.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void btn_tracuu_Click(object sender, EventArgs e)
        {

        }

        private void dgv_thongtinsuco_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgv_thongtinsuco.Columns[e.ColumnIndex].Name == "TrangThaiXuLy")
            {
                if (dgv_thongtinsuco.Rows[e.RowIndex].Cells["TrangThaiXuLy"].Value == null)
                    return;

                int maSuCo = int.Parse(dgv_thongtinsuco.Rows[e.RowIndex].Cells["MaSuCo"].Value.ToString());
                string input = dgv_thongtinsuco.Rows[e.RowIndex].Cells["TrangThaiXuLy"].Value.ToString();
                string trangThai = ChuanHoaTrangThai(input);

                // tự sửa lại trên grid
                dgv_thongtinsuco.Rows[e.RowIndex].Cells["TrangThaiXuLy"].Value = trangThai;

                Child_BaoCaoSuCoBUS bus = new Child_BaoCaoSuCoBUS();
                bus.CapNhatTrangThai(maSuCo, trangThai);


            }
        }

        private void cmb_trangthai_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!isLoaded) return; // chặn lúc đang load

            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date.AddDays(1).AddSeconds(-1);
            string trangThai = cmb_trangthai.Text.Trim();
            dgv_thongtinsuco.DataSource = bus.TraCuu(tuNgay, denNgay, trangThai);
        }

        private void dgv_thongtinsuco_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
