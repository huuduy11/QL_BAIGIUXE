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
    public partial class LoaiXeGui : Form
    {
        LoaiXeBUS bus = new LoaiXeBUS();
        
        public LoaiXeGui()
        {
            InitializeComponent();
            dgv_loaixe.AutoGenerateColumns = false;
        }
        private void LoadDataGrid()
        {
            dgv_loaixe.DataSource = bus.GetAllLoaiXe();
            dgv_loaixe.GridColor = Color.FromArgb(224, 224, 224);
        }

        private void LoaiXeGui_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
            dgv_loaixe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
        }

        private void btn_taomoi_Click(object sender, EventArgs e)
        {
            frmChiTietLoaiXe f = new frmChiTietLoaiXe();
            f.IsAdd = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDataGrid();
            }
        }

        private void btn_dieuchinh_Click(object sender, EventArgs e)
        {
            if (dgv_loaixe.CurrentRow != null)
            {
                frmChiTietLoaiXe f = new frmChiTietLoaiXe();
                f.IsAdd = false;
                // Truyền dữ liệu sang form chi tiết
                f.maLoai = Convert.ToInt32(dgv_loaixe.CurrentRow.Cells[0].Value);
                f.tenLoai = dgv_loaixe.CurrentRow.Cells[1].Value.ToString();
                f.nhomXe = dgv_loaixe.CurrentRow.Cells[2].Value.ToString();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDataGrid();
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_loaixe.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int ma = Convert.ToInt32(dgv_loaixe.CurrentRow.Cells[0].Value);
                    if (bus.DeleteLoaiXe(ma))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadDataGrid();
                    }
                }
            }
        }

        private void dgv_loaixe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
