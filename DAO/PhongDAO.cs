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
    public class PhongDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<PhongDTO> LayDSPhong()
        {
            string sTruyVan = "select * from Phong";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PhongDTO> lstPhong = new List<DTO.PhongDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhongDTO p = new PhongDTO();
                p.SSoPhong = dt.Rows[i]["SoPhong"].ToString();
                p.SMaLoaiPhong = dt.Rows[i]["MaLoaiPhong"].ToString();
                p.STinhTrang = dt.Rows[i]["TinhTrang"].ToString();
                lstPhong.Add(p);
            }
            DataProvider.DongKetNoi(con);
            return lstPhong;
        }
        // Thêm NV
        public static bool ThemPhong(PhongDTO p)
        {
            string sTruyVan = string.Format(@"insert into Phong values(N'{0}',N'{1}',N'{2}')", p.SSoPhong, p.SMaLoaiPhong, p.STinhTrang);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static PhongDTO TimPhongTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from Phong where SoPhong=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            PhongDTO p = new PhongDTO();
            p.SSoPhong = dt.Rows[0]["SoPhong"].ToString();
            p.SMaLoaiPhong = dt.Rows[0]["MaLoaiPhong"].ToString();
            p.STinhTrang = dt.Rows[0]["TinhTrang"].ToString();
            DataProvider.DongKetNoi(con);
            return p;
        }

        // Cập nhật thông tin NV
        public static bool CapNhatPhong(PhongDTO p)
        {
            string sTruyVan = string.Format(@"update Phong set MaLoaiPhong=N'{0}',
            TinhTrang=N'{1}'where SoPhong=N'{2}'",p.SMaLoaiPhong, p.STinhTrang, p.SSoPhong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool ThayDoiTinhTrangPhong(PhongDTO p)
        {
            string sTruyVan = string.Format(@"update Phong set TinhTrang=N'Có Khách' where SoPhong=N'{0}'", p.SSoPhong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaPhong(PhongDTO p)
        {
            string sTruyVan = string.Format(@"delete from Phong where SoPhong=N'{0}'", p.SSoPhong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
