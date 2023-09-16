using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class SuDungDichVuBUS
    {
        //Lấy DS 
        public static List<SuDungDichVuDTO> LayDSSuDungDichVu()
        {
            return SuDungDichVuDAO.LayDSSuDungDichVu();
        }

        // Thêm mới 
        public static bool ThemSuDungDichVu(SuDungDichVuDTO udv)
        {
            return SuDungDichVuDAO.ThemSuDungDichVu(udv);
        }

        // Tìm NV theo mã
        public static SuDungDichVuDTO TimSuDungDichVuTheoMa(string ma)
        {
            return SuDungDichVuDAO.TimSuDungDichVuTheoMa(ma);
        }

        // Sửa thông tin 
        public static bool CapNhatSuDungDichVu(SuDungDichVuDTO udv)
        {
            return SuDungDichVuDAO.CapNhatSuDungDichVu(udv);
        }

        // Xóa thông tin
        public static bool XoaSuDungDichVu(SuDungDichVuDTO udv)
        {
            return SuDungDichVuDAO.XoaSuDungDichVu(udv);
        }
    }
}
