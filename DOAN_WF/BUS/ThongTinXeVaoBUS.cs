using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DAL;
using System.Windows.Forms;

namespace DOAN_WF.BUS
{
    internal class ThongTinXeVaoBUS
    {
        LichSuVaoDAL lsrv = new LichSuVaoDAL();
        public List<LichSuVaoRaDTO> LayThongTinXeVao()
        {
            try
            {
                return lsrv.Laydulieuxedavao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin xe vào: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<LichSuVaoRaDTO>();
            }
        }
        public bool NhapBai(LichSuVaoRaDTO lichsuvaoradto)
        {
            try
            {
                return lsrv.ChoXeIntoBai(lichsuvaoradto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập bài: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        // Hàm đếm số lượng thẻ vãng lai còn trống trong bãi để hiển thị
        public int DemTheVangLaiTrong()
        {
            try
            {
                return lsrv.DemTheVangLaiTrong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đếm thẻ vãng lai trống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        
    }
}
