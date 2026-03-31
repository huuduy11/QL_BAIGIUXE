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
    public partial class frm_lichsuvaora : Form
    {
        LichSuVaoRaBUS bus = new LichSuVaoRaBUS();
        Child_BaoCaoSuCoBUS buss = new Child_BaoCaoSuCoBUS();
        public frm_lichsuvaora()
        {
            InitializeComponent();
        }


        public void LoadData()
        {
            dtp_tungay.MaxDate = DateTime.Now;
            dtp_denngay.MaxDate = DateTime.Now;
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;
            DataTable dt = new DataTable();
            dt = bus.LayDuLieu(tuNgay, denNgay);
            dgv_table.DataSource = dt;

        }
        public void FormatGrid()
        {
            dgv_table.Columns["MalS"].HeaderText = "Mã LS";
            dgv_table.Columns["TenLoaiXe"].HeaderText = "Tên Loại Xe";
            dgv_table.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgv_table.Columns["BienSo"].HeaderText = "Biển Số";
            dgv_table.Columns["ThoiGianVao"].HeaderText = "Thời Gian Vào";
            dgv_table.Columns["ThoiGianRa"].HeaderText = "Thời Gian Ra";
            dgv_table.Columns["MaThe"].HeaderText = "Mã Thẻ";
            dgv_table.Columns["TenLoaiThe"].HeaderText = "Tên Loại Thẻ";

            dgv_table.EnableHeadersVisualStyles = false;
            dgv_table.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_table.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_table.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // Phân quyên
        private void PhanQuyen()
        {
            // Lấy quyền từ phiên đăng nhập (1: Admin, 2: Quản lý, 3: Nhân viên)
            int quyen = LuuPhienDangNhap.CurrentUser.MaTK;

            if (quyen == 3) // Nếu là nhân viên
            {
                btn_xoa.Enabled = false;
            }
            else // Admin hoặc Quản lý
            {
                btn_xoa.Enabled = true;
            }
        }
        private void txt_nhapbienso_loaixe_Enter(object sender, EventArgs e)
        {
            if (txt_nhapbienso_loaixe.Text == "Nhập Biển số hoặc Loại xe")
            {
                txt_nhapbienso_loaixe.Text = "";

            }
        }

        private void txt_nhapbienso_loaixe_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nhapbienso_loaixe.Text))
            {
                txt_nhapbienso_loaixe.Text = "Nhập Biển số hoặc Loại xe";

            }
        }
        private void dgv_table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgv_table.Rows[e.RowIndex].IsNewRow)
                return;

            if (dgv_table.Columns[e.ColumnIndex].Name == "ThoiGianRa")
            {
                if (e.Value == DBNull.Value || e.Value == null)
                {
                    e.Value = "Đang trong bãi";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            txt_nhapbienso_loaixe.Text = "";
            txt_nhapbienso_loaixe.Focus();
        }

        private void txt_nhapbienso_loaixe_TextChanged(object sender, EventArgs e)
        {
            btn_tim_Click(null, null); //tim kiem tuc thi (go text den dau tim den do)
        }



        public void LichSuVaoRa_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            LoadData();
            FormatGrid();
        }


        private void btn_tracuu_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;
            bool trongBai = chk_trongbai.Checked;
            bool daRa = chk_dara.Checked;
            bool xeThang = chk_xethang.Checked;
            bool vangLai = chk_vanglai.Checked;
            DataTable dt = new DataTable();


            if (!chk_trongbai.Checked && !chk_dara.Checked && !chk_xethang.Checked && !chk_vanglai.Checked)
            {
                dt = bus.LayDuLieu(tuNgay, denNgay);
                dgv_table.DataSource = dt;
            }
            else
            {
                dt = bus.TraCuu(tuNgay, denNgay, trongBai, daRa, xeThang, vangLai);
                dgv_table.DataSource = dt;
            }
            FormatGrid();
        }

        private void chk_trongbai_CheckedChanged(object sender, EventArgs e)
        {
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;
            if (chk_trongbai.Checked)
            {
                chk_dara.Checked = false;

            }
        }

        private void chk_dara_CheckedChanged(object sender, EventArgs e)
        {
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;
            if (chk_dara.Checked)
            {
                chk_trongbai.Checked = false;

            }
        }

        private void chk_xethang_CheckedChanged(object sender, EventArgs e)
        {
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;
            if (chk_xethang.Checked)
            {
                chk_vanglai.Checked = false;
            }
        }

        private void chk_vanglai_CheckedChanged(object sender, EventArgs e)
        {
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;
            if (chk_vanglai.Checked)
            {
                chk_xethang.Checked = false;
            }
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            string locdulieu = txt_nhapbienso_loaixe.Text.Trim(); //lay noi dung vua go vao o txt
            DataTable dt = (DataTable)dgv_table.DataSource; //lay lai toan bo du lieu dang hien tren bang dgv
            dt.DefaultView.RowFilter = string.Format("[BienSo] LIKE '%{0}%' OR [TenLoaiXe] LIKE '%{0}%'", locdulieu);
        }

        private void btn_baocaosuco_Click(object sender, EventArgs e)
        {

            //bcsuco.ShowDialog();
            //OpenChildForm(new frm_child_baocaosuco());
            if (dgv_table.CurrentRow != null)
            {
                string loaiXe = dgv_table.CurrentRow.Cells["TenLoaiXe"].Value.ToString();
                string bienSo = dgv_table.CurrentRow.Cells["BienSo"].Value.ToString();
                string tgvao = dgv_table.CurrentRow.Cells["ThoiGianVao"].Value.ToString();
                string maThe = dgv_table.CurrentRow.Cells["MaThe"].Value.ToString();
                string tenloaithe = dgv_table.CurrentRow.Cells["TenLoaiThe"].Value.ToString();
                string mals = dgv_table.CurrentRow.Cells["MaLS"].Value.ToString();
                frm_child_baocaosuco bcsuco1 = new frm_child_baocaosuco(mals);
                // 3. Truyền dữ liệu sang các TextBox trên Pop-up
                // (Nhớ chỉnh Modifiers của TextBox trên Form Pop-up thành Public)
                //popUp.lblLoaiXe.Text = loaiXe;  // Thay txt bằng lbl
                //popUp.lblBienSo.Text = bienSo;
                bcsuco1.lbl_laymals.Text = mals;
                bcsuco1.lbl_laytenloaixe.Text = loaiXe;
                bcsuco1.lbl_laybienso.Text = bienSo;
                bcsuco1.lbl_laytgvao.Text = tgvao;
                bcsuco1.lbl_laymathe.Text = maThe;
                bcsuco1.lbl_laytenloaithe.Text = tenloaithe;
                // 4. Hiển thị Pop-up ở dạng khóa Form chính (ShowDialog)
                bcsuco1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trên bảng trước!");
            }
        }
    }
}
