using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class DichVuBUS
    {
        //Lấy DS 
        public static List<DichVuDTO> LayDSDichVu()
        {
            return DichVuDAO.LayDSDichVu();
        }

        // Thêm mới NV
        public static bool ThemDichVu(DichVuDTO dv)
        {
            return DichVuDAO.ThemDichVu(dv);
        }

        // Tìm NV theo mã
        public static DichVuDTO TimDichVuTheoMa(string ma)
        {
            return DichVuDAO.TimDichVuTheoMa(ma);
        }

        // Sửa thông tin NV
        public static bool CapNhatDichVu(DichVuDTO dv)
        {
            return DichVuDAO.CapNhatDichVu(dv);
        }

        // Xóa thông tin NV
        public static bool XoaDichVu(DichVuDTO dv)
        {
            return DichVuDAO.XoaDichVu(dv);
        }
    }
}
