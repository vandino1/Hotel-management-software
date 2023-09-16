using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BUS_CSDL
    {
        public static bool SaoLuu(string sDuongDan)
        {
            return DAO_CSDL.SaoLuuDuLieu(sDuongDan);
        }
        public static bool PhucHoi(string sDuongDan)
        {
            return DAO_CSDL.PhucHoiDuLieu(sDuongDan);
        }
    }
}
