using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ThietBiBUS
    {
        //Lấy DS 
        public static List<ThietBiDTO> LayDSThietBi()
        {
            return ThietBiDAO.LayDSThietBi();
        }

        // Thêm mới 
        public static bool ThemThietBi(ThietBiDTO tb)
        {
            return ThietBiDAO.ThemThietBi(tb);
        }

        // Tìm NV theo mã
        public static ThietBiDTO TimThietBiTheoMa(string ma)
        {
            return ThietBiDAO.TimThietBiTheoMa(ma);
        }

        // Sửa thông tin 
        public static bool CapNhatThietBi(ThietBiDTO tb)
        {
            return ThietBiDAO.CapNhatThietBi(tb);
        }

        // Xóa thông tin
        public static bool XoaThietBi(ThietBiDTO tb)
        {
            return ThietBiDAO.XoaThietBi(tb);
        }
    }
}
