using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_CSDL
    {
        static SqlConnection con;
        public static bool SaoLuuDuLieu(string sDuongDan)
        {
            string sTen = "\\QLKHACHSAN(" + DateTime.Now.Day.ToString() + "_" +
            DateTime.Now.Month.ToString() + "_" +
            DateTime.Now.Year.ToString() + "_" +
            DateTime.Now.Hour.ToString() + "_" +
            DateTime.Now.Minute.ToString() + ").bak";
            string sql = "BACKUP DATABASE QLKHACHSAN TO DISK = N'" + sDuongDan + sTen + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool PhucHoiDuLieu(string sDuongDan)
        {
            string sql = "restore DATABASE QLKHACHSAN from DISK = N'" + sDuongDan + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.PhucHoi(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
