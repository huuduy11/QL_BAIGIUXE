using DoAn_demo.BUS;
using DoAn_demo.DAL;
using DoAn_demo.DTO;
using DOAN_WF.DTO;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static DoAn_demo.DTO.BaoCaoDoanhThuDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace DoAn_demo.GUI
{
    public partial class frm_qldoanhthu : Form
    {
        BaoCaoBUS bus = new BaoCaoBUS();

        public frm_qldoanhthu()
        {
            InitializeComponent();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            //this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
        }
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private void pnl_tongdoanhthu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dtp_tungay_ValueChanged(object sender, EventArgs e)
        {
            LoadBaoCao(cmb_catruc.Text);
        }
        private void cmb_catruc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PhanQuyen()
        {
            // Lấy quyền từ phiên đăng nhập (1: Admin, 2: Quản lý, 3: Nhân viên)
            int quyen = LuuPhienDangNhap.CurrentUser.MaTK;

            if (quyen == 3) // Nếu là nhân viên
            {
                btn_inbaocao.Enabled = false; // Vô hiệu hóa nút in báo cáo
            }
            else // Admin hoặc Quản lý
            {
                // Hiển thị tất cả
                btn_inbaocao.Enabled = true;
            }
        }
        void LoadBaoCao(string caTruc = "Tất cả")
        {
            dgv_table.Columns.Clear();
            dgv_table.Columns.Add("MaLoaiXe", "Mã Loại Xe");
            dgv_table.Columns.Add("TenLoaiXe", "Tên Loại Xe");
            dgv_table.Columns.Add("LuotVaoThang", "Lượt Vào Tháng");
            dgv_table.Columns.Add("LuotRaThang", "Lượt Ra Tháng");
            dgv_table.Columns.Add("XeThang", "Xe Tháng");

            dgv_table.Columns.Add("LuotVaoVangLai", "Lượt Vào Vãng Lai");
            dgv_table.Columns.Add("LuotRaVangLai", "Lượt Ra Vãng Lai");


            dgv_table.Columns.Add("XeVangLai", "Xe Vãng Lai ");

            dgv_table.Columns.Add("TongLuotVao", "Tổng Lượt Vào");
            dgv_table.Columns.Add("TongLuotRa", "Tổng Lượt Ra");

            dgv_table.Columns.Add("TongDoanhThu", "Tổng Doanh Thu");

            dgv_table.Columns[0].DataPropertyName = "MaLoaiXe";
            dgv_table.Columns[1].DataPropertyName = "TenLoaiXe";

            dgv_table.Columns[2].DataPropertyName = "LuotVaoThang";
            dgv_table.Columns[3].DataPropertyName = "LuotRaThang";
            dgv_table.Columns[4].DataPropertyName = "XeThang";

            dgv_table.Columns[5].DataPropertyName = "LuotVaoVangLai";
            dgv_table.Columns[6].DataPropertyName = "LuotRaVangLai";
            dgv_table.Columns[7].DataPropertyName = "XeVangLai";

            dgv_table.Columns[8].DataPropertyName = "TongLuotVao";
            dgv_table.Columns[9].DataPropertyName = "TongLuotRa";
            dgv_table.Columns[10].DataPropertyName = "TongDoanhThu";

            dgv_table.Columns[4].DefaultCellStyle.Format = "N0";
            dgv_table.Columns[7].DefaultCellStyle.Format = "N0";
            dgv_table.Columns[10].DefaultCellStyle.Format = "N0";

            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;

            DataTable dt;


            int? maCa = null;

            // xử lý ca
            if (caTruc == "Ca ngày")
                maCa = 1;
            else if (caTruc == "Ca đêm")
                maCa = 2;
            decimal tongDoanhThu = 0;

            dt = bus.LocTheoCa(tuNgay, denNgay, maCa);
            foreach (DataRow row in dt.Rows)
            {
                tongDoanhThu += Convert.ToDecimal(row["TongDoanhThu"]);
            }


            lbl_tongdoanhthu.Text = "Tổng doanh thu ("
               + tuNgay.ToString("dd/MM/yyyy") + " - "
               + denNgay.ToString("dd/MM/yyyy") + "): "
               + tongDoanhThu.ToString("N0")
               + " VND";
            lbl_tongdoanhthu.ForeColor = Color.Red;


            dgv_table.DataSource = dt;
            ThemDongTong(dt);

            VeBieuDo(dt);
        }

        DataTable ThemDongTong(DataTable dt)
        {
            decimal tongDoanhThu = 0;
            int tongVao = 0;
            int tongRa = 0;
            if (dt.Rows.Count > 0)
            {
                var last = dt.Rows[dt.Rows.Count - 1];
                if (last["TenLoaiXe"]?.ToString() == "TỔNG")
                    dt.Rows.Remove(last);
            }
            foreach (DataRow row in dt.Rows)
            {
                //Doanh thu
                if (dt.Columns.Contains("TongDoanhThu") && row["TongDoanhThu"] != DBNull.Value)
                    tongDoanhThu += Convert.ToDecimal(row["TongDoanhThu"]);

                //Số lượt vào
                if (dt.Columns.Contains("TongLuotVao") && row["TongLuotVao"] != DBNull.Value)
                    tongVao += Convert.ToInt32(row["TongLuotVao"]);

                //Số lượt ra
                if (dt.Columns.Contains("TongLuotRa") && row["TongLuotRa"] != DBNull.Value)
                    tongRa += Convert.ToInt32(row["TongLuotRa"]);
            }

            DataRow tongRow = dt.NewRow();
            tongRow["TenLoaiXe"] = "TỔNG";
            tongRow["TongDoanhThu"] = tongDoanhThu;

            tongRow["TongLuotVao"] = tongVao;
            tongRow["TongLuotRa"] = tongRa;

            dt.Rows.Add(tongRow);

            return dt;
        }
        void ToMauDongTong()
        {
            if (dgv_table.Rows.Count == 0) return;

            int lastRow = dgv_table.Rows.Count - 1;
            var row = dgv_table.Rows[lastRow];

            //chỉ xử lý nếu là dòng TỔNG
            if (row.Cells["TenLoaiXe"].Value?.ToString() != "TỔNG")
                return;

            // in đậm chữ TỔNG
            row.Cells["TenLoaiXe"].Style.Font = new Font(dgv_table.Font, FontStyle.Bold);
            row.Cells["TenLoaiXe"].Style.ForeColor = Color.Red;

            // tô màu từng ô
            if (dgv_table.Columns.Contains("DoanhThu"))
                row.Cells["DoanhThu"].Style.ForeColor = Color.Red;

            if (dgv_table.Columns.Contains("TongLuotVao"))
                row.Cells["TongLuotVao"].Style.ForeColor = Color.Red;

            if (dgv_table.Columns.Contains("TongLuotRa"))
                row.Cells["TongLuotRa"].Style.ForeColor = Color.Red;
        }
        void VeBieuDo(DataTable dt)
        {
            chartCot.Series.Clear();
            chartTron.Series.Clear();

            Series pie = new Series("TongDoanh thu");
            pie.ChartType = SeriesChartType.Pie;

            bool hasLuot = dt.Columns.Contains("TongLuotVao");

            Series vao = null;
            Series ra = null;

            if (hasLuot)
            {
                vao = new Series("Lượt vào");
                vao.ChartType = SeriesChartType.Column;

                ra = new Series("Lượt ra");
                ra.ChartType = SeriesChartType.Column;
            }

            foreach (DataRow row in dt.Rows)
            {
                string loaixe = row["TenLoaiXe"]?.ToString();
                if (loaixe == "TỔNG")
                    continue;

                decimal doanhthu = 0;

                // xét trường hợp tên cột 
                if (dt.Columns.Contains("TongDoanhThu") && row["TongDoanhThu"] != DBNull.Value)
                    doanhthu = Convert.ToDecimal(row["TongDoanhThu"]);

                pie.Points.AddXY(loaixe, doanhthu);

                if (hasLuot)
                {
                    int luotVao = row["TongLuotVao"] != DBNull.Value
                        ? Convert.ToInt32(row["TongLuotVao"])
                        : 0;

                    int luotRa = row["TongLuotRa"] != DBNull.Value
                        ? Convert.ToInt32(row["TongLuotRa"])
                        : 0;

                    vao.Points.AddXY(loaixe, luotVao);
                    ra.Points.AddXY(loaixe, luotRa);
                }
            }

            pie.IsValueShownAsLabel = true;
            chartTron.Series.Add(pie);

            chartTron.Titles.Clear();
            chartTron.Titles.Add("TỶ LỆ DOANH THU");

            chartCot.Titles.Clear();

            if (hasLuot)
            {
                vao.IsValueShownAsLabel = true;
                ra.IsValueShownAsLabel = true;

                chartCot.Series.Add(vao);
                chartCot.Series.Add(ra);

                chartCot.Titles.Add("SỐ LƯỢT XA VÀO/RA");
            }
        }
        private void frm_qldoanhthu_Load_1(object sender, EventArgs e)
        {

            PhanQuyen();
            lbl_bctongquat.Visible = true;
            lbl_doanhthuvethang.Visible = false;

            dgv_table.Visible = true;

            dgv_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DateTime today = DateTime.Today;

            dtp_tungay.Value = today;
            dtp_denngay.Value = today;

            // tạo dữ liệu combobox
            cmb_catruc.Items.Clear();
            cmb_catruc.Items.Add("Tất cả");
            cmb_catruc.Items.Add("Ca ngày");
            cmb_catruc.Items.Add("Ca đêm");
            cmb_catruc.SelectedIndex = 0;
            LoadBaoCao();
            ToMauDongTong();
        }

        private void btn_baocaotongquat_Click_1(object sender, EventArgs e)
        {
            cmb_catruc.Visible = true;
            lbl_bctongquat.Visible = true;
            lbl_doanhthuvethang.Visible = false;
            dgv_table.Visible = true;

            dgv_table.AutoGenerateColumns = false;
            dgv_table.Columns.Clear();


            int? maCa = null;


            LoadBaoCao(cmb_catruc.Text);
            ToMauDongTong();
        }

        private void btn_doanhthuvethang_Click(object sender, EventArgs e)
        {
            dgv_table.Columns.Clear();

            cmb_catruc.Visible = false;
            lbl_bctongquat.Visible = false;
            lbl_doanhthuvethang.Visible = true;
            dgv_table.Visible = true;

            // tạo cột cho datagridview
            dgv_table.Columns.Add("MaLoaiXe", "Mã Loại Xe");
            dgv_table.Columns.Add("TenLoaiXe", "Tên Loại Xe");
            dgv_table.Columns.Add("TongLuotVao", "Số Lượt Vào");
            dgv_table.Columns.Add("TongLuotRa", "Số Lượt Ra");
            dgv_table.Columns.Add("TongDoanhThu", "Giá Theo Tháng ");


            dgv_table.Columns[0].DataPropertyName = "MaLoaiXe";
            dgv_table.Columns[1].DataPropertyName = "TenLoaiXe";
            dgv_table.Columns[2].DataPropertyName = "TongLuotVao";
            dgv_table.Columns[3].DataPropertyName = "TongLuotRa";
            dgv_table.Columns[4].DataPropertyName = "TongDoanhThu";
            dgv_table.Columns[4].DefaultCellStyle.Format = "N0";

            // 2. Lấy dữ liệu từ BUS/DAL
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;
            DataTable dt = bus.DoanhThuVeThang(tuNgay, denNgay);

            // 3. Gán DataSource và định dạng cột
            dgv_table.DataSource = dt;
            if (dgv_table.Columns.Contains("TongDoanhThu"))
            {
                dgv_table.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
                dgv_table.Columns["TongDoanhThu"].HeaderText = "Doanh Thu Vé Tháng";
            }

            // 4. TÍNH TỔNG DOANH THU (Dùng logic của bạn)
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["TongDoanhThu"] != DBNull.Value)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongDoanhThu"]);
                }
            }

            // 5. Hiển thị lên Label giao diện
            lbl_tongdoanhthu.Text = string.Format("Tổng doanh thu ({0:dd/MM/yyyy} - {1:dd/MM/yyyy}): {2:N0} VND",
                                                   tuNgay, denNgay, tongDoanhThu);
            lbl_tongdoanhthu.ForeColor = Color.Red;

            // 6. Các hàm vẽ biểu đồ và dòng tổng phụ
            ThemDongTong(dt);
            ToMauDongTong();
            VeBieuDo(dt);



        }

        private void btn_xuatexcel_Click(object sender, EventArgs e)
        {

        }

        private void btn_inbaocao_Click(object sender, EventArgs e)
        {
            // 1. Lấy ngày
            DateTime tuNgay = dtp_tungay.Value.Date;
            DateTime denNgay = dtp_denngay.Value.Date;

            // 2. Lấy mã ca
            int? maCa = cmb_catruc.SelectedValue != null ? Convert.ToInt32(cmb_catruc.SelectedValue) : (int?)null;

            // 3. Lấy dữ liệu từ DAL
            BaoCaoDAL dal = new BaoCaoDAL();
            DataTable dt = dal.LocTheoCa(tuNgay, denNgay, maCa);

            //  ĐOẠN TÍNH TỔNG TIỀN ĐỂ HIỂN THỊ LÊN TIÊU ĐỀ 
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dt.Rows)
            {
                // Chú ý: "TongDoanhThu" phải khớp với tên cột trong câu SQL (AS TongDoanhThu)
                if (row["TongDoanhThu"] != DBNull.Value)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongDoanhThu"]);
                }
            }

            // 4. Mở form report
            frm_baocao f = new frm_baocao();

            // 5. Set ReportPath
            f.rpt_baocao.LocalReport.ReportPath = @"rpt_baocaodoanhthu.rdlc";

            // 6. Set DataSource
            f.rpt_baocao.LocalReport.DataSources.Clear();
            f.rpt_baocao.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            );

            // 7. Set Parameter (SỬA Ở ĐÂY)
            // Nối chuỗi gồm: Ngày bắt đầu - Ngày kết thúc | Tổng doanh thu: (Số tiền định dạng N0)
            string textHienThi = string.Format("{0:dd/MM/yyyy} - {1:dd/MM/yyyy} | Tổng doanh thu: {2:N0} VND",
                                                tuNgay, denNgay, tongDoanhThu);

            ReportParameter p = new ReportParameter("TongDoanhThuText", textHienThi);
            f.rpt_baocao.LocalReport.SetParameters(new ReportParameter[] { p });

            // 8. Show form và refresh
            // Nên Refresh trước khi ShowDialog để tránh lỗi hiển thị
            f.rpt_baocao.RefreshReport();
            f.ShowDialog();
        }
    }
}
