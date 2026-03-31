using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DTO;
using System.Data.SqlClient;
namespace DOAN_WF.DAL
{
    internal class CaTrucDAL
    {
        string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
        public List<CaTrucDTO> LayDSCT()
        {
            List<CaTrucDTO> dsCaTruc = new List<CaTrucDTO>();
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"SELECT MaCa, TenCa FROM CaTruc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CaTrucDTO ct = new CaTrucDTO();
                    ct.MaCa = reader.GetInt32(0);
                    ct.TenCa = reader.GetString(1);
                    dsCaTruc.Add(ct);
                };
            }
            return dsCaTruc;

        }
    }
}
