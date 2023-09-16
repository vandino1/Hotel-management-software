using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DKPhongDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<DKPhongDTO> LayDSDKPhong()
        {
            string sTruyVan = "select * from DangKyPhong";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DKPhongDTO> lstDKPhong = new List<DTO.DKPhongDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DKPhongDTO dkp = new DKPhongDTO();
                dkp.SMADK = dt.Rows[i]["MADK"].ToString();
                dkp.DTNgayDK1 = DateTime.Parse(dt.Rows[i]["NgayDK"].ToString());
                dkp.SMAKH = dt.Rows[i]["MAKH"].ToString();
                dkp.DTNgayDen1 = DateTime.Parse(dt.Rows[i]["NgayDen"].ToString());
                dkp.DTNgayDi1 = DateTime.Parse(dt.Rows[i]["NgayDi"].ToString());
                dkp.SSoPhong = dt.Rows[i]["SoPhong"].ToString();
                dkp.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());               
                lstDKPhong.Add(dkp);
            }
            DataProvider.DongKetNoi(con);
            return lstDKPhong;
        }
        // Thêm NV
        public static bool ThemDKPhong(DKPhongDTO dkp)
        {
            string sTruyVan = string.Format(@"insert into DangKyPhong values
(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')",
dkp.SMADK, dkp.DTNgayDK1, dkp.SMAKH, dkp.DTNgayDen1, dkp.DTNgayDi1, dkp.SSoPhong, dkp.ISoLuong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static DKPhongDTO TimDKPhongTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from DangKyPhong where MADK=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            DKPhongDTO dkp = new DKPhongDTO();
            dkp.SMADK = dt.Rows[0]["MADK"].ToString();
            dkp.DTNgayDK1 = DateTime.Parse(dt.Rows[0]["NgayDK"].ToString());
            dkp.SMAKH = dt.Rows[0]["MAKH"].ToString();
            dkp.DTNgayDen1 = DateTime.Parse(dt.Rows[0]["NgayDen"].ToString());
            dkp.DTNgayDi1 = DateTime.Parse(dt.Rows[0]["NgayDi"].ToString());
            dkp.SSoPhong = dt.Rows[0]["SoPhong"].ToString();
            dkp.ISoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());         

            DataProvider.DongKetNoi(con);
            return dkp;
        }

        // Cập nhật thông tin NV
        public static bool CapNhatDKPhong(DKPhongDTO dkp)
        {
        string sTruyVan = string.Format(@"update DangKyPhong set NgayDK=N'{0}',
        MAKH=N'{1}',NgayDen=N'{2}',NgayDi=N'{3}',SoPhong=N'{4}',SoLuong=N'{5}'where MADK=N'{6}'",
        dkp.DTNgayDK1, dkp.SMAKH, dkp.DTNgayDen1, dkp.DTNgayDi1, dkp.SSoPhong, dkp.ISoLuong, dkp.SMADK);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaDKPhong(DKPhongDTO dkp)
        {
            string sTruyVan = string.Format(@"delete from DangKyPhong where MADK=N'{0}'", dkp.SMADK);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
