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
    public class ThietBiDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<ThietBiDTO> LayDSThietBi()
        {
            string sTruyVan = "select * from ThietBi";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ThietBiDTO> lstThietBi = new List<DTO.ThietBiDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ThietBiDTO tb = new ThietBiDTO();
                tb.SMATB = dt.Rows[i]["MATB"].ToString();
                tb.STenTB = dt.Rows[i]["TenTB"].ToString();
                tb.ISoLuong1 = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                tb.SDonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                tb.SHangSanXuat = dt.Rows[i]["HangSanXuat"].ToString();
                tb.DTNamSX1 = DateTime.Parse(dt.Rows[i]["NamSX"].ToString());

                lstThietBi.Add(tb);
            }
            DataProvider.DongKetNoi(con);
            return lstThietBi;
        }
        // Thêm NV
        public static bool ThemThietBi(ThietBiDTO tb)
        {
            string sTruyVan = string.Format(@"insert into ThietBi values
(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')", tb.SMATB, tb.STenTB, tb.ISoLuong1, tb.SDonViTinh, tb.SHangSanXuat, tb.DTNamSX1);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static ThietBiDTO TimThietBiTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from ThietBi where MATB=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            ThietBiDTO tb = new ThietBiDTO();
            tb.SMATB = dt.Rows[0]["MATB"].ToString();
            tb.STenTB = dt.Rows[0]["TenTB"].ToString();
            tb.ISoLuong1 = int.Parse(dt.Rows[0]["SoLuong"].ToString());
            tb.SDonViTinh = dt.Rows[0]["DonViTinh"].ToString();
            tb.SHangSanXuat = dt.Rows[0]["HangSanXuat"].ToString();
            tb.DTNamSX1 = DateTime.Parse(dt.Rows[0]["NamSX"].ToString());



            DataProvider.DongKetNoi(con);
            return tb;

        }

        // Cập nhật thông tin NV
        public static bool CapNhatThietBi(ThietBiDTO tb)
        {
            string sTruyVan = string.Format(@"update ThietBi set TenTB=N'{0}',
            SoLuong=N'{1}',DonViTinh=N'{2}',HangSanXuat=N'{3}',NamSX=N'{4}' where MATB=N'{5}'",
                tb.STenTB,  tb.ISoLuong1, tb.SDonViTinh, tb.SHangSanXuat, tb.DTNamSX1, tb.SMATB);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaThietBi(ThietBiDTO tb)
        {
            string sTruyVan = string.Format(@"delete from ThietBi where MATB=N'{0}'", tb.SMATB);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
