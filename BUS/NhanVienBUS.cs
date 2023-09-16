using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhanVienBUS
    {
        //Lấy DS nhân viên
        public static List<NhanVienDTO> LayDSNhanVien()
        {
            return NhanVienDAO.LayDSNhanVien();
        }
        // Thêm mới NV
        public static bool ThemNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAO.ThemNhanVien(nv);
        }
        // Sửa thông tin NV
        public static bool CapNhatNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAO.CapNhatNhanVien(nv);
        }
        // Xóa thông tin NV
        public static bool XoaNhanVien(NhanVienDTO nv)
        {
            return NhanVienDAO.XoaNhanVien(nv);
        }
        // Tìm NV theo mã
        public static NhanVienDTO TimNhanVienTheoMa(string ma)
        {
            return NhanVienDAO.TimNhanVienTheoMa(ma);
        }
    }
}
