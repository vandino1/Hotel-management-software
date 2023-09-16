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
    public class PhieuThanhToanDAO
    {
        static SqlConnection con;

        // Lấy danh sách tất cả nhân viên
        public static List<PhieuThanhToanDTO> LayDSPhieuThanhToan()
        {
            string sTruyVan = "select * from PhieuThanhToan";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<PhieuThanhToanDTO> lstPhieuThanhToan = new List<DTO.PhieuThanhToanDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PhieuThanhToanDTO ptt = new PhieuThanhToanDTO();
                ptt.SMAHD = dt.Rows[i]["MAHD"].ToString();
                ptt.SMANV = dt.Rows[i]["MANV"].ToString();
                ptt.SMAKH = dt.Rows[i]["MAKH"].ToString();
                ptt.DTNgayThanhToan1 = DateTime.Parse(dt.Rows[i]["NgayThanhToan"].ToString());
                ptt.SSoPhong = dt.Rows[i]["SoPhong"].ToString();
                ptt.ISoNgayTro = int.Parse(dt.Rows[i]["SoNgayTro"].ToString());
                ptt.ITienPhong = int.Parse(dt.Rows[i]["TienPhong"].ToString());
                ptt.ITongTien = int.Parse(dt.Rows[i]["TongTien"].ToString());
                lstPhieuThanhToan.Add(ptt);
            }
            DataProvider.DongKetNoi(con);
            return lstPhieuThanhToan;
        }
        // Thêm NV
        public static bool ThemPhieuThanhToan(PhieuThanhToanDTO ptt)
        {
            string sTruyVan = string.Format(@"insert into PhieuThanhToan values
(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}')",
ptt.SMAHD, ptt.SMANV, ptt.SMAKH, ptt.DTNgayThanhToan1, ptt.SSoPhong, ptt.ISoNgayTro, ptt.ITienPhong,ptt.ITongTien);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Lấy thông tin nhân viên có mã ma, trả về null nếu không thấy
        public static PhieuThanhToanDTO TimPhieuThanhToanTheoMa(string ma)
        {
            string sTruyVan = string.Format(@"select * from PhieuThanhToan where MAHD=N'{0}'", ma);
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            // Nếu có chuyển dữ liệu thành kiểu NhanVienDTO
            PhieuThanhToanDTO ptt = new PhieuThanhToanDTO();
            ptt.SMAHD = dt.Rows[0]["MAHD"].ToString();
            ptt.SMANV = dt.Rows[0]["MANV"].ToString();
            ptt.SMAKH = dt.Rows[0]["MAKH"].ToString();
            ptt.DTNgayThanhToan1 = DateTime.Parse(dt.Rows[0]["NgayThanhToan"].ToString());
            ptt.SSoPhong = dt.Rows[0]["SoPhong"].ToString();
            ptt.ISoNgayTro = int.Parse(dt.Rows[0]["SoNgayTro"].ToString());
            ptt.ITienPhong = int.Parse(dt.Rows[0]["TienPhong"].ToString());
            ptt.ITongTien = int.Parse(dt.Rows[0]["TongTien"].ToString());

            DataProvider.DongKetNoi(con);
            return ptt;
        }

        // Cập nhật thông tin NV
        public static bool CapNhatPhieuThanhToan(PhieuThanhToanDTO ptt)
        {
            string sTruyVan = string.Format(@"update PhieuThanhToan set MANV=N'{0}',
        MAKH=N'{1}',NgayThanhToan=N'{2}',SoPhong=N'{3}',SoNgayTro=N'{4}',TienPhong=N'{5}',TongTien=N'{6}'where MAHD=N'{7}'",
            ptt.SMANV, ptt.SMAKH, ptt.DTNgayThanhToan1, ptt.SSoPhong, ptt.ISoNgayTro, ptt.ITienPhong, ptt.ITongTien, ptt.SMAHD);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Xóa thông tin 1 nhân viên
        public static bool XoaPhieuThanhToan(PhieuThanhToanDTO ptt)
        {
            string sTruyVan = string.Format(@"delete from PhieuThanhToan where MAHD=N'{0}'", ptt.SMAHD);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}
