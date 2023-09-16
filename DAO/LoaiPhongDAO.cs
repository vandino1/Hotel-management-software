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
    public class LoaiPhongDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<LoaiPhongDTO> LayDSLoaiPhong()
        {
            string sTruyVan = "select * from LoaiPhong";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<LoaiPhongDTO> lstLoaiPhong = new List<DTO.LoaiPhongDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LoaiPhongDTO lp = new LoaiPhongDTO();
                lp.SMaLoaiPhong = dt.Rows[i]["MaLoaiPhong"].ToString();
                lp.STenLoaiPhong = dt.Rows[i]["TenLoaiPhong"].ToString();
                lp.IDonGia = int.Parse(dt.Rows[i]["DonGia"].ToString());
                lp.SDonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                lstLoaiPhong.Add(lp);
            }
            DataProvider.DongKetNoi(con);
            return lstLoaiPhong;
        }
        // Thêm NV
        public static bool ThemLoaiPhong(LoaiPhongDTO lp)
        {
            string sTruyVan = string.Format(@"insert into LoaiPhong values(N'{0}',
               N'{1}',N'{2}',N'{3}')", lp.SMaLoaiPhong, lp.STenLoaiPhong, lp.IDonGia, lp.SDonViTinh);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static LoaiPhongDTO TimLoaiPhongTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from LoaiPhong where MaLoaiPhong=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            LoaiPhongDTO lp = new LoaiPhongDTO();
            lp.SMaLoaiPhong = dt.Rows[0]["MaLoaiPhong"].ToString();
            lp.STenLoaiPhong = dt.Rows[0]["TenLoaiPhong"].ToString();
            lp.IDonGia = int.Parse(dt.Rows[0]["DonGia"].ToString());
            lp.SDonViTinh = dt.Rows[0]["DonViTinh"].ToString();
            DataProvider.DongKetNoi(con);
            return lp;
        
        }

        // Cập nhật thông tin NV
        public static bool CapNhatLoaiPhong(LoaiPhongDTO lp)
        {
            string sTruyVan = string.Format(@"update LoaiPhong set TenLoaiPhong=N'{0}',
            DonGia=N'{1}',DonViTinh=N'{2}' where MaLoaiPhong=N'{3}'",
                lp.STenLoaiPhong, lp.IDonGia, lp.SDonViTinh, lp.SMaLoaiPhong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaLoaiPhong(LoaiPhongDTO lp)
        {
            string sTruyVan = string.Format(@"delete from LoaiPhong where MaLoaiPhong=N'{0}'", lp.SMaLoaiPhong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
