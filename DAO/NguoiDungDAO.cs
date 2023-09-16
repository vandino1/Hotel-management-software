using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class NguoiDungDAO
    {
        static SqlConnection con;
        public static NguoiDungDTO LayNguoiDung(string ten, string matkhau)
        {
            string sTruyVan = string.Format(@"select * from nguoidung where ten = N'{0}' and matkhau = '{1}'", ten, matkhau);
            con = DataProvider.MoKetNoi();

            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            NguoiDungDTO nd = new NguoiDungDTO();
            nd.STen = dt.Rows[0]["ten"].ToString();
            nd.SMatkhau = dt.Rows[0]["matkhau"].ToString();
            nd.IQuyen = Int32.Parse(dt.Rows[0]["quyen"].ToString());
            return nd;
        }
        public static bool SuaMKNguoiDung(NguoiDungDTO nd)
        {
            string sTruyVan = string.Format("update nguoidung set matkhau = '{0}' where ten = N'{1}'", nd.SMatkhau, nd.STen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool SuaQuyenNguoiDung(NguoiDungDTO nd)
        {
            string sTruyVan = string.Format("update nguoidung set quyen = {0} where ten = N'{1}'", nd.IQuyen, nd.STen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool CaiLaiMkNguoiDung(NguoiDungDTO nd)
        {
            string sTruyVan = string.Format("update nguoidung set matkhau = '{0}' where ten = N'{1}'", nd.SMatkhau, nd.STen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool ThemNguoiDung(NguoiDungDTO nd)
        {
            string sTruyVan = string.Format("insert into nguoidung values(N'{0}',N'{1}',N'{2}')", nd.STen, nd.SMatkhau, nd.IQuyen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<NguoiDungDTO> LayNguoiDung_XuatDS()
        {
            string sTruyVan = "Select * from nguoidung ";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NguoiDungDTO> lstnguoidung = new List<NguoiDungDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NguoiDungDTO nd = new NguoiDungDTO();

                nd.STen = dt.Rows[i]["ten"].ToString();
                nd.SMatkhau = dt.Rows[i]["matkhau"].ToString();
                nd.IQuyen = Int32.Parse(dt.Rows[i]["quyen"].ToString());
                lstnguoidung.Add(nd);
            }
            return lstnguoidung;
        }
        public static bool XoaNguoiDung(NguoiDungDTO nd)
        {
            string sTruyVan = string.Format("delete from nguoidung where ten = '{0}'", nd.STen);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
