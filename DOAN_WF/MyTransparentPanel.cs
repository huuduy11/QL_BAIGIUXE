using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace DOAN_WF
{
    public class MyTransparentPanel: Panel
    {
        public MyTransparentPanel()
        {
           
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Opaque, false);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Vẽ một lớp màu đen mờ phủ lên trên
            using (var brush = new SolidBrush(Color.FromArgb(5, Color.White))) // Chỉnh số 100 để tăng/giảm độ mờ
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT: Cho phép nhìn xuyên thấu
                return cp;
            }
        }
    }
}

