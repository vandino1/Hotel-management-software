using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class LoaiPhongBUS
    {
        //Lấy DS nhân viên
        public static List<LoaiPhongDTO> LayDSLoaiPhong()
        {
            return LoaiPhongDAO.LayDSLoaiPhong();
        }

        // Thêm mới NV
        public static bool ThemLoaiPhong(LoaiPhongDTO lp)
        {
            return LoaiPhongDAO.ThemLoaiPhong(lp);
        }

        // Tìm NV theo mã
        public static LoaiPhongDTO TimLoaiPhongTheoMa(string ma)
        {
            return LoaiPhongDAO.TimLoaiPhongTheoMa(ma);
        }

        // Sửa thông tin NV
        public static bool CapNhatLoaiPhong(LoaiPhongDTO lp)
        {
            return LoaiPhongDAO.CapNhatLoaiPhong(lp);
        }

        // Xóa thông tin NV
        public static bool XoaLoaiPhong(LoaiPhongDTO lp)
        {
            return LoaiPhongDAO.XoaLoaiPhong(lp);
        }
    }
}
