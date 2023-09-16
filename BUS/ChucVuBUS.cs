using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class ChucVuBUS
    {
        public static List<ChucVuDTO> LayChucVu()
        {
            return ChucVuDAO.LayChucVu();
        }
        // Thêm mới CV
        public static bool ThemChucVu(ChucVuDTO cv)
        {
            return ChucVuDAO.ThemChucVu(cv);
        }
        // Sửa thông tin CV
        public static bool CapNhatChucVu(ChucVuDTO cv)
        {
            return ChucVuDAO.CapNhatChucVu(cv);
        }
        // Xóa thông tin CV
        public static bool XoaChucVu(ChucVuDTO cv)
        {
            return ChucVuDAO.XoaChucVu(cv);
        }
        // Tìm CV theo mã
        public static ChucVuDTO TimChucVuTheoMa(string ma)
        {
            return ChucVuDAO.TimChucVuTheoMa(ma);
        }
    }
}
