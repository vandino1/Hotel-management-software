using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class KhachHangBUS
    {
        //Lấy DS
        public static List<KhachHangDTO> LayDSKhachHang()
        {
            return KhachHangDAO.LayDSKhachHang();
        }
        // Thêm mới 
        public static bool ThemKhachHang(KhachHangDTO kh)
        {
            return KhachHangDAO.ThemKhachHang(kh);
        }
        // Sửa thông tin
        public static bool CapNhatKhachHang(KhachHangDTO kh)
        {
            return KhachHangDAO.CapNhatKhachHang(kh);
        }
        // Xóa thông tin 
        public static bool XoaKhachHang(KhachHangDTO kh)
        {
            return KhachHangDAO.XoaKhachHang(kh);
        }
        // Tìm NV theo mã
        public static KhachHangDTO TimKhachHangTheoMa(string ma)
        {
            return KhachHangDAO.TimKhachHangTheoMa(ma);
        }
    }
}
