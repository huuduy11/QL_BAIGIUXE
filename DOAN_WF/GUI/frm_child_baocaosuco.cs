using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOAN_WF.BUS;
using DOAN_WF.DTO;

namespace DOAN_WF.GUI
{
    public partial class frm_child_baocaosuco : Form
    {
        Child_BaoCaoSuCoBUS bus = new Child_BaoCaoSuCoBUS();
        public frm_child_baocaosuco()
        {
            InitializeComponent();
        }
        private string _maLS;
        public frm_child_baocaosuco(string mals)
        {
            InitializeComponent();
            _maLS = mals;
            lbl_mals.Text = _maLS;
        }
        private void frm_child_baocaosuco_Load(object sender, EventArgs e)
        {

            //lay du lieu do vao combobox
            DataTable dt = bus.TenNV();

            DataRow r = dt.NewRow();
            r["MaNV"] = DBNull.Value;
            r["TenNV"] = "-- Chọn nhân viên --";
            dt.Rows.InsertAt(r, 0);

            cmb_tennv.DataSource = dt;
            cmb_tennv.DisplayMember = "TenNV";
            cmb_tennv.ValueMember = "MaNV";

            cmb_tennv.SelectedIndex = 0;


            cmb_ndsuco.DataSource = bus.NoiDungSuCo();
            cmb_ndsuco.DisplayMember = "LoaiSuCo";
            cmb_ndsuco.ValueMember = "MaSuCo";

            
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void lbl_tenloaithe_Click(object sender, EventArgs e)
        {
            
        }
        
        private void cmb_tennv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tennv.SelectedIndex > 0)
            {
                lbl_laymanv.Text = cmb_tennv.SelectedValue.ToString();
            }
            else
            {
                lbl_laymanv.Text = "";
            }
        }
        
        private void btn_guibaocao_Click(object sender, EventArgs e)
        {
            if (cmb_tennv.SelectedIndex == -1 || cmb_tennv.Text == "-- Chọn nhân viên --")
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_tennv.Focus();
                return;
            }
            try
            {
                SuCoDTO sc = new SuCoDTO(); // 👈 PHẢI CÓ DÒNG NÀY

                //sc.MaLS = maLS;
                sc.MaLS = int.Parse(_maLS);
                sc.LoaiSuCo = cmb_ndsuco.Text;
                sc.MoTa = txt_mota.Text;
                sc.MaNV = int.Parse(lbl_laymanv.Text);
                sc.ThoiGian = DateTime.Now;

                Child_BaoCaoSuCoBUS bus = new Child_BaoCaoSuCoBUS();
                bus.GuiBaoCao(sc);

                MessageBox.Show("Gửi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_mota_Click(object sender, EventArgs e)
        {

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            cmb_tennv.SelectedIndex = -1;
            cmb_tennv.Text = "-- Chọn nhân viên --";

            cmb_ndsuco.SelectedIndex = -1;
            cmb_ndsuco.Text = "";

           
            txt_mota.Clear();

           
            lbl_laymanv.Text = "";

            
            cmb_tennv.Focus();
        }

        private void lbl_mals_Click(object sender, EventArgs e)
        {


        }
    }
}
