using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private string sMaKH;
        private string sHoKH;
        private string sTen;
        private string sGioiTinh;
        private DateTime DTNgaySinh;
        private string sDiaChi;
        private string sSDT;
        private string sCMMND;
        private string sQuocTich;

        public string SMaKH { get => sMaKH; set => sMaKH = value; }
        public string SHoKH { get => sHoKH; set => sHoKH = value; }
        public string STen { get => sTen; set => sTen = value; }
        public string SGioiTinh { get => sGioiTinh; set => sGioiTinh = value; }
        public DateTime DTNgaySinh1 { get => DTNgaySinh; set => DTNgaySinh = value; }
        public string SDiaChi { get => sDiaChi; set => sDiaChi = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
        public string SCMMND { get => sCMMND; set => sCMMND = value; }
        public string SQuocTich { get => sQuocTich; set => sQuocTich = value; }
    }
}
