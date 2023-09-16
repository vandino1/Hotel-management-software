using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DKPhongDTO
    {
        private string sMADK;
        private DateTime DTNgayDK;
        private string sMAKH;
        private DateTime DTNgayDen;
        private DateTime DTNgayDi;
        private string sSoPhong;
        private int iSoLuong;     

        public string SMADK { get => sMADK; set => sMADK = value; }
        public DateTime DTNgayDK1 { get => DTNgayDK; set => DTNgayDK = value; }
        public string SMAKH { get => sMAKH; set => sMAKH = value; }
        public DateTime DTNgayDen1 { get => DTNgayDen; set => DTNgayDen = value; }
        public DateTime DTNgayDi1 { get => DTNgayDi; set => DTNgayDi = value; }
        public string SSoPhong { get => sSoPhong; set => sSoPhong = value; }
        public int ISoLuong { get => iSoLuong; set => iSoLuong = value; }    
    }
}
