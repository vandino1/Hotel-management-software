using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrangBiPhongDTO
    {
        private string sMaTrangBi;
        private string sSoPhong;
        private string sMATB;
        private int iSoLuong;

        public string SMaTrangBi { get => sMaTrangBi; set => sMaTrangBi = value; }
        public string SSoPhong { get => sSoPhong; set => sSoPhong = value; }
        public string SMATB { get => sMATB; set => sMATB = value; }
        public int ISoLuong { get => iSoLuong; set => iSoLuong = value; }
    }
}
