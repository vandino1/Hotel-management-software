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
    public class TrangBiPhongDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<TrangBiPhongDTO> LayDSTrangBiPhong()
        {
            string sTruyVan = "select * from TrangTBPhong";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TrangBiPhongDTO> lstTrangBiPhong = new List<DTO.TrangBiPhongDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TrangBiPhongDTO tbp = new TrangBiPhongDTO();
                tbp.SMaTrangBi = dt.Rows[i]["MaTrangBi"].ToString();
                tbp.SSoPhong = dt.Rows[i]["SoPhong"].ToString();
                tbp.SMATB = dt.Rows[i]["MATB"].ToString();
                tbp.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());

                lstTrangBiPhong.Add(tbp);
            }
            DataProvider.DongKetNoi(con);
            return lstTrangBiPhong;
        }
        // Thêm NV
        public static bool ThemTrangBiPhong(TrangBiPhongDTO tbp)
        {
            string sTruyVan = string.Format(@"insert into TrangTBPhong values
(N'{0}',N'{1}',N'{2}',N'{3}')", tbp.SMaTrangBi, tbp.SSoPhong, tbp.SMATB, tbp.ISoLuong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static TrangBiPhongDTO TimTrangBiPhongTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from TrangTBPhong where MaTrangBi=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            TrangBiPhongDTO tbp = new TrangBiPhongDTO();
            tbp.SMaTrangBi = dt.Rows[0]["MaTrangBi"].ToString();
            tbp.SSoPhong = dt.Rows[0]["SoPhong"].ToString();
            tbp.SMATB = dt.Rows[0]["MATB"].ToString();
            tbp.ISoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());

            DataProvider.DongKetNoi(con);
            return tbp;

        }

        // Cập nhật thông tin NV
        public static bool CapNhatTrangBiPhong(TrangBiPhongDTO tbp)
        {
            string sTruyVan = string.Format(@"update TrangTBPhong set SoPhong=N'{0}',
            MATB=N'{1}',SoLuong=N'{2}' where MaTrangBi=N'{3}'",
                tbp.SSoPhong, tbp.SMATB, tbp.ISoLuong, tbp.SMaTrangBi);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaTrangBiPhong(TrangBiPhongDTO tbp)
        {
            string sTruyVan = string.Format(@"delete from TrangTBPhong where MaTrangBi=N'{0}'", tbp.SMaTrangBi);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
