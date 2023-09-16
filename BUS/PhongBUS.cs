using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class PhongBUS
    {
        //Lấy DS nhân viên
        public static List<PhongDTO> LayDSPhong()
        {
            return PhongDAO.LayDSPhong();
        }

        // Thêm mới NV
        public static bool ThemPhong(PhongDTO p)
        {
            return PhongDAO.ThemPhong(p);
        }

        // Tìm NV theo mã
        public static PhongDTO TimPhongTheoMa(string ma)
        {
            return PhongDAO.TimPhongTheoMa(ma);
        }

        // Sửa thông tin NV
        public static bool CapNhatPhong(PhongDTO p)
        {
            return PhongDAO.CapNhatPhong(p);
        }
        public static bool ThayDoiTrangThaiPhong(PhongDTO p)
        {
            return PhongDAO.ThayDoiTinhTrangPhong(p);
        }


        // Xóa thông tin NV
        public static bool XoaPhong(PhongDTO p)
        {
            return PhongDAO.XoaPhong(p);
        }
    }
}
