using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class ChucVuDAO
    {
        static SqlConnection con;
        public static List<ChucVuDTO> LayChucVu()
        {
            string sTruyVan = "select * from ChucVu";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ChucVuDTO> lstChucVu = new List<ChucVuDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChucVuDTO cv = new ChucVuDTO();
                cv.SMaCV = dt.Rows[i]["MACV"].ToString();
                cv.STenCV = dt.Rows[i]["TENCV"].ToString();
                cv.SSDT = dt.Rows[i]["SDT"].ToString();
                lstChucVu.Add(cv);
            }
            DataProvider.DongKetNoi(con);
            return lstChucVu;
        }
        public static bool ThemChucVu(ChucVuDTO cv)
        {
            string sTruyVan = string.Format(@"insert into ChucVu values(N'{0}',N'{1}',N'{2}')", cv.SMaCV, cv.STenCV, cv.SSDT);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static ChucVuDTO TimChucVuTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from ChucVu where MACV=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            ChucVuDTO cv = new ChucVuDTO();
            cv.SMaCV = dt.Rows[0]["MACV"].ToString();
            cv.STenCV = dt.Rows[0]["TenCV"].ToString();
            cv.SSDT = dt.Rows[0]["SDT"].ToString();
           
            DataProvider.DongKetNoi(con);
            return cv;
        }

        // Cập nhật thông tin ChucVu
        public static bool CapNhatChucVu(ChucVuDTO cv)
        {
            string sTruyVan = string.Format(@"update ChucVu set TenCV=N'{0}',
            SDT=N'{1}'where MACV=N'{2}'",
                   cv.STenCV, cv.SSDT, cv.SMaCV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaChucVu(ChucVuDTO cv)
        {
            string sTruyVan = string.Format(@"delete from ChucVu where MACV=N'{0}'", cv.SMaCV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
