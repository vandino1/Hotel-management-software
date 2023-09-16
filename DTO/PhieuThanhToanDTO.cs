using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThanhToanDTO
    {
        private string sMAHD;
        private string sMANV;
        private string sMAKH;
        private DateTime DTNgayThanhToan;
        private string sSoPhong;
        private int iSoNgayTro;
        private int iTienPhong;
        private int iTongTien;

        public string SMAHD { get => sMAHD; set => sMAHD = value; }
        public string SMANV { get => sMANV; set => sMANV = value; }
        public string SMAKH { get => sMAKH; set => sMAKH = value; }
        public DateTime DTNgayThanhToan1 { get => DTNgayThanhToan; set => DTNgayThanhToan = value; }
        public string SSoPhong { get => sSoPhong; set => sSoPhong = value; }
        public int ISoNgayTro { get => iSoNgayTro; set => iSoNgayTro = value; }
        public int ITienPhong { get => iTienPhong; set => iTienPhong = value; }
        public int ITongTien { get => iTongTien; set => iTongTien = value; }
    }
}
