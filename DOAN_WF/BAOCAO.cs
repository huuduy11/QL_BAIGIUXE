using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_demo
{
    public partial class frm_baocao : Form
    {
        public frm_baocao()
        {
            InitializeComponent();
        }

        private void BAOCAO_Load(object sender, EventArgs e)
        {

            this.rpt_baocao.RefreshReport();
        }
    }
}
