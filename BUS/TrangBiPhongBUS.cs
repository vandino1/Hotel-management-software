using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
     public class TrangBiPhongBUS
    {
        //Lấy DS 
        public static List<TrangBiPhongDTO> LayDSTrangBiPhong()
        {
            return TrangBiPhongDAO.LayDSTrangBiPhong();
        }

        // Thêm mới 
        public static bool ThemTrangBiPhong(TrangBiPhongDTO tbp)
        {
            return TrangBiPhongDAO.ThemTrangBiPhong(tbp);
        }

        // Tìm NV theo mã
        public static TrangBiPhongDTO TimTrangBiPhongTheoMa(string ma)
        {
            return TrangBiPhongDAO.TimTrangBiPhongTheoMa(ma);
        }

        // Sửa thông tin 
        public static bool CapNhatTrangBiPhong(TrangBiPhongDTO tbp)
        {
            return TrangBiPhongDAO.CapNhatTrangBiPhong(tbp);
        }

        // Xóa thông tin
        public static bool XoaTrangBiPhong(TrangBiPhongDTO tbp)
        {
            return TrangBiPhongDAO.XoaTrangBiPhong(tbp);
        }
    }
}
