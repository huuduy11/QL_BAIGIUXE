using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOAN_WF.DTO;
namespace DOAN_WF.DAL
{
    internal class QuyenDAL
    {
        string strConn = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
        public List <QuyenDTO>LayDSQuyen()
        {
            List<QuyenDTO> dsQuyen = new List<QuyenDTO>();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = "SELECT MaQuyen, TenQuyen FROM Quyen";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    QuyenDTO q = new QuyenDTO
                    {
                        MaQuyen = reader.GetInt32(0),
                        TenQuyen = reader.GetString(1)
                    };
                    dsQuyen.Add(q);
                }
            }
            return dsQuyen;
        }
    }
}
