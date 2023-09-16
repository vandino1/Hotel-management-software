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
    public class KhachHangDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả khách hàng
        public static List<KhachHangDTO> LayDSKhachHang()
        {
            string sTruyVan = "select * from KhachHang";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<KhachHangDTO> lstKhachHang = new List<DTO.KhachHangDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.SMaKH= dt.Rows[i]["MAKH"].ToString();
                kh.SHoKH = dt.Rows[i]["HoKH"].ToString();
                kh.STen = dt.Rows[i]["TenKH"].ToString();
                kh.SGioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                kh.DTNgaySinh1 = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                kh.SDiaChi = dt.Rows[i]["DiaChi"].ToString();
                kh.SSDT = dt.Rows[i]["SDT"].ToString();
                kh.SCMMND = dt.Rows[i]["CMND"].ToString();           
                kh.SQuocTich = dt.Rows[i]["QuocTich"].ToString();
                lstKhachHang.Add(kh);
            }
            DataProvider.DongKetNoi(con);
            return lstKhachHang;
        }
        // Thêm NV
        public static bool ThemKhachHang(KhachHangDTO kh)
        {
            string sTruyVan = string.Format(@"insert into KhachHang values(N'{0}',
                N'{1}',N'{2}',N'{3}','{4}',N'{5}',N'{6}',N'{7}',N'{8}')", kh.SMaKH, kh.SHoKH, kh.STen,
                kh.SGioiTinh, kh.DTNgaySinh1, kh.SDiaChi, kh.SSDT, kh.SCMMND, kh.SQuocTich);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static KhachHangDTO TimKhachHangTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from KhachHang where MAKH=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            KhachHangDTO kh = new KhachHangDTO();
            kh.SMaKH = dt.Rows[0]["MAKH"].ToString();
            kh.SHoKH = dt.Rows[0]["HoKH"].ToString();
            kh.STen = dt.Rows[0]["TenKH"].ToString();
            kh.SGioiTinh = dt.Rows[0]["GioiTinh"].ToString();
            kh.DTNgaySinh1 = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            kh.SDiaChi = dt.Rows[0]["DiaChi"].ToString();
            kh.SSDT = dt.Rows[0]["SDT"].ToString();
            kh.SCMMND = dt.Rows[0]["CMND"].ToString();
            kh.SQuocTich = dt.Rows[0]["QuocTich"].ToString();
            DataProvider.DongKetNoi(con);
            return kh;
        }

        // Cập nhật thông tin NV
        public static bool CapNhatKhachHang(KhachHangDTO kh)
        {
            string sTruyVan = string.Format(@"update KhachHang set HoKH=N'{0}',
            TenKH=N'{1}',GioiTinh=N'{2}',Ngaysinh='{3}',DiaChi=N'{4}',SDT='{5}',CMND='{6}',QuocTich=N'{7}' where MAKH=N'{8}'",
                kh.SHoKH, kh.STen, kh.SGioiTinh, kh.DTNgaySinh1, kh.SDiaChi, kh.SSDT, kh.SCMMND, kh.SQuocTich, kh.SMaKH);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaKhachHang(KhachHangDTO kh)
        {
            string sTruyVan = string.Format(@"delete from KhachHang where MAKH=N'{0}'", kh.SMaKH);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
