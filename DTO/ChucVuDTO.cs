using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVuDTO
    {
        private string sMaCV;
        private string sTenCV;
        private string sSDT;

        public string SMaCV { get => sMaCV; set => sMaCV = value; }
        public string STenCV { get => sTenCV; set => sTenCV = value; }
        public string SSDT { get => sSDT; set => sSDT = value; }
    }
}
