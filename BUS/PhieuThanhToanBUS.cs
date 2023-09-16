using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class PhieuThanhToanBUS
    {
        //Lấy DS nhân viên
        public static List<PhieuThanhToanDTO> LayDSPhieuThanhToan()
        {
            return PhieuThanhToanDAO.LayDSPhieuThanhToan();
        }

        // Thêm mới NV
        public static bool ThemPhieuThanhToan(PhieuThanhToanDTO ptt)
        {
            return PhieuThanhToanDAO.ThemPhieuThanhToan(ptt);
        }

        // Tìm NV theo mã
        public static PhieuThanhToanDTO TimPhieuThanhToanTheoMa(string ma)
        {
            return PhieuThanhToanDAO.TimPhieuThanhToanTheoMa(ma);
        }

        // Sửa thông tin NV
        public static bool CapNhatPhieuThanhToan(PhieuThanhToanDTO ptt)
        {
            return PhieuThanhToanDAO.CapNhatPhieuThanhToan(ptt);
        }

        // Xóa thông tin NV
        public static bool XoaPhieuThanhToan(PhieuThanhToanDTO ptt)
        {
            return PhieuThanhToanDAO.XoaPhieuThanhToan(ptt);
        }
    }
}
