using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SuDungDichVuDTO
    {
        private int iSTT;
        private string sMaKH;
        private DateTime DTNgaySuDung;
        private string sSoPhong;
        private string sMaDV;
        private int iSoLuong;
        private int iThanhTien;

        public int ISTT { get => iSTT; set => iSTT = value; }
        public string SMaKH { get => sMaKH; set => sMaKH = value; }
        public DateTime DTNgaySuDung1 { get => DTNgaySuDung; set => DTNgaySuDung = value; }
        public string SSoPhong { get => sSoPhong; set => sSoPhong = value; }
        public string SMaDV { get => sMaDV; set => sMaDV = value; }
        public int ISoLuong { get => iSoLuong; set => iSoLuong = value; }
        public int IThanhTien { get => iThanhTien; set => iThanhTien = value; }
        
    }
}
