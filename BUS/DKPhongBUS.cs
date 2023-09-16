using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class DKPhongBUS
    {
        //Lấy DS nhân viên
        public static List<DKPhongDTO> LayDSDKPhong()
        {
            return DKPhongDAO.LayDSDKPhong();
        }

        // Thêm mới NV
        public static bool ThemDKPhong(DKPhongDTO dkp)
        {
            return DKPhongDAO.ThemDKPhong(dkp);
        }

        // Tìm NV theo mã
        public static DKPhongDTO TimDKPhongTheoMa(string ma)
        {
            return DKPhongDAO.TimDKPhongTheoMa(ma);
        }

        // Sửa thông tin NV
        public static bool CapNhatDKPhong(DKPhongDTO dkp)
        {
            return DKPhongDAO.CapNhatDKPhong(dkp);
        }

        // Xóa thông tin NV
        public static bool XoaDKPhong(DKPhongDTO dkp)
        {
            return DKPhongDAO.XoaDKPhong(dkp);
        }
    }
}
