using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private string sMaNV;
        private string sHoNV;
        private string sTen;
        private string sGioiTinh;
        private DateTime DTNgaySinh;
        private string sCMMND;
        private string sSDT;
        private string sDiaChi;
        private string sMaCV;

        public string SMaNV { get => sMaNV; set => sMaNV = value; }
        public string SHoNV { get => sHoNV; set => sHoNV = value; }
        public string STen { get => sTen; set => sTen = value; }
        public string SGioiTinh { get => sGioiTinh; set => sGioiTinh = value; }
        public DateTime DTNgaySinh1 { get => DTNgaySinh; set => DTNgaySinh = value; }
        public string SCMMND { get => sCMMND; set => sCMMND = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SMaCV { get => sMaCV; set => sMaCV = value;
        }
    }
}
