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
    public class NhanVienDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<NhanVienDTO> LayDSNhanVien()
        {
            string sTruyVan = "select * from NhanVien";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVienDTO> lstNhanVien = new List<DTO.NhanVienDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.SMaNV = dt.Rows[i]["MANV"].ToString();
                nv.SHoNV = dt.Rows[i]["HoNV"].ToString();
                nv.STen = dt.Rows[i]["TenNV"].ToString();
                nv.SGioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                nv.DTNgaySinh1 = DateTime.Parse(dt.Rows[i]["Ngaysinh"].ToString());
                nv.SCMMND = dt.Rows[i]["CMND"].ToString();
                nv.SSDT = dt.Rows[i]["SDT"].ToString();
                nv.SDiaChi = dt.Rows[i]["DiaChi"].ToString();
                nv.SMaCV = dt.Rows[i]["MACV"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
        // Thêm NV
        public static bool ThemNhanVien(NhanVienDTO nv)
        {
            string sTruyVan = string.Format(@"insert into NhanVien values(N'{0}',
                N'{1}',N'{2}',N'{3}','{4}',N'{5}',N'{6}',N'{7}',N'{8}')", nv.SMaNV, nv.SHoNV, nv.STen,
                nv.SGioiTinh, nv.DTNgaySinh1, nv.SCMMND, nv.SSDT, nv.SDiaChi, nv.SMaCV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static NhanVienDTO TimNhanVienTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from NhanVien where MANV=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            NhanVienDTO nv = new NhanVienDTO();
            nv.SMaNV = dt.Rows[0]["MANV"].ToString();
            nv.SHoNV = dt.Rows[0]["HoNV"].ToString();
            nv.STen = dt.Rows[0]["TenNV"].ToString();
            nv.SGioiTinh = dt.Rows[0]["GioiTinh"].ToString();
            nv.DTNgaySinh1 = DateTime.Parse(dt.Rows[0]["Ngaysinh"].ToString());
            nv.SCMMND = dt.Rows[0]["CMND"].ToString();
            nv.SSDT = dt.Rows[0]["SDT"].ToString();
            nv.SDiaChi = dt.Rows[0]["DiaChi"].ToString();
            nv.SMaCV = dt.Rows[0]["MACV"].ToString();
            DataProvider.DongKetNoi(con);
            return nv;
        }

        // Cập nhật thông tin NV
        public static bool CapNhatNhanVien(NhanVienDTO nv)
        {
        string sTruyVan = string.Format(@"update NhanVien set HoNV=N'{0}',
            TenNV=N'{1}',GioiTinh=N'{2}',Ngaysinh='{3}',CMND='{4}',SDT='{5}',DiaChi=N'{6}',MACV='{7}' where MANV=N'{8}'",
            nv.SHoNV, nv.STen, nv.SGioiTinh, nv.DTNgaySinh1, nv.SCMMND, nv.SSDT, nv.SDiaChi, nv.SMaCV, nv.SMaNV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaNhanVien(NhanVienDTO nv)
        {
            string sTruyVan = string.Format(@"delete from NhanVien where MANV=N'{0}'", nv.SMaNV);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
