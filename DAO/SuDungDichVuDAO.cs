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
    public class SuDungDichVuDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<SuDungDichVuDTO> LayDSSuDungDichVu()
        {
            string sTruyVan = "select * from SuDungDichVu";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<SuDungDichVuDTO> lstSuDungDichVu = new List<DTO.SuDungDichVuDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SuDungDichVuDTO udv = new SuDungDichVuDTO();
                udv.ISTT = int.Parse(dt.Rows[i]["STT"].ToString());
                udv.SMaKH = dt.Rows[i]["MaKH"].ToString();
                udv.DTNgaySuDung1 = DateTime.Parse(dt.Rows[i]["NgaySuDung"].ToString());
                udv.SSoPhong = dt.Rows[i]["SoPhong"].ToString();
                udv.SMaDV = dt.Rows[i]["MADV"].ToString();
                udv.ISoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                udv.IThanhTien = int.Parse(dt.Rows[i]["ThanhTien"].ToString());

                lstSuDungDichVu.Add(udv);
            }
            DataProvider.DongKetNoi(con);
            return lstSuDungDichVu;
        }
        // Thêm NV
        public static bool ThemSuDungDichVu(SuDungDichVuDTO udv)
        {
            string sTruyVan = string.Format(@"insert into SuDungDichVu values
(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')", udv.ISTT, udv.SMaKH, udv.DTNgaySuDung1,  udv.SSoPhong, udv.SMaDV, udv.ISoLuong, udv.IThanhTien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static SuDungDichVuDTO TimSuDungDichVuTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from SuDungDichVu where STT=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            SuDungDichVuDTO udv = new SuDungDichVuDTO();
            udv.ISTT = int.Parse(dt.Rows[0]["STT"].ToString());
            udv.SMaKH = dt.Rows[0]["MaKH"].ToString();
            udv.DTNgaySuDung1 = DateTime.Parse(dt.Rows[0]["NgaySuDung"].ToString());
            udv.SSoPhong = dt.Rows[0]["SoPhong"].ToString();
            udv.SMaDV = dt.Rows[0]["MADV"].ToString();
            udv.ISoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());
            udv.IThanhTien = int.Parse(dt.Rows[0]["ThanhTien"].ToString());

            DataProvider.DongKetNoi(con);
            return udv;

        }

        // Cập nhật thông tin NV
        public static bool CapNhatSuDungDichVu(SuDungDichVuDTO udv)
        {
            string sTruyVan = string.Format(@"update SuDungDichVu set MAKH=N'{0}',
            NgaySuDung=N'{1}',SoPhong=N'{2}',MADV='{3}',SoLuong='{4}',ThanhTien='{5}' where STT=N'{6}'",
          udv.SMaKH, udv.DTNgaySuDung1, udv.SSoPhong, udv.SMaDV, udv.ISoLuong, udv.IThanhTien, udv.ISTT);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaSuDungDichVu(SuDungDichVuDTO udv)
        {
            string sTruyVan = string.Format(@"delete from SuDungDichVu where STT=N'{0}'", udv.ISTT);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
