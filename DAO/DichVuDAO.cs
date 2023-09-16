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
    public class DichVuDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<DichVuDTO> LayDSDichVu()
        {
            string sTruyVan = "select * from DichVu";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<DichVuDTO> lstDichVu = new List<DTO.DichVuDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DichVuDTO dv = new DichVuDTO();
                dv.SMaDV = dt.Rows[i]["MADV"].ToString();
                dv.STenDV = dt.Rows[i]["TenDV"].ToString();
                dv.SDonViTinh = dt.Rows[i]["DonViTinh"].ToString();
                dv.IDonGia = int.Parse(dt.Rows[i]["DonGia"].ToString());
                dv.SGhiChu = dt.Rows[i]["GhiChu"].ToString();

                lstDichVu.Add(dv);
            }
            DataProvider.DongKetNoi(con);
            return lstDichVu;
        }
        // Thêm NV
        public static bool ThemDichVu(DichVuDTO dv)
        {
            string sTruyVan = string.Format(@"insert into DichVu values(N'{0}',
               N'{1}',N'{2}',N'{3}',N'{4}')", dv.SMaDV, dv.STenDV, dv.SDonViTinh, dv.IDonGia, dv.SGhiChu);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static DichVuDTO TimDichVuTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from DichVu where MADV=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            DichVuDTO dv = new DichVuDTO();
            dv.SMaDV = dt.Rows[0]["MADV"].ToString();
            dv.STenDV = dt.Rows[0]["TenDV"].ToString();
            dv.SDonViTinh = dt.Rows[0]["DonViTinh"].ToString();
            dv.IDonGia = int.Parse(dt.Rows[0]["DonGia"].ToString());
            dv.SGhiChu = dt.Rows[0]["GhiChu"].ToString();

            DataProvider.DongKetNoi(con);
            return dv;

        }

        // Cập nhật thông tin NV
        public static bool CapNhatDichVu(DichVuDTO dv)
        {
            string sTruyVan = string.Format(@"update DichVu set TenDV=N'{0}',
            DonViTinh=N'{1}',DonGia=N'{2}',GhiChu=N'{3}' where MADV=N'{4}'",
                dv.STenDV, dv.SDonViTinh, dv.IDonGia, dv.SGhiChu, dv.SMaDV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaDichVu(DichVuDTO dv)
        {
            string sTruyVan = string.Format(@"delete from DichVu where MADV=N'{0}'", dv.SMaDV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
