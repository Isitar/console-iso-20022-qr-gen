using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrUltmtCdtr
    {
        public string Name { get; set; }
        public string StrtNm { get; set; }
        public string BldgNb { get; set; }
        public string PstCd { get; set; }
        public string TwnNm { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine(QrData.GetOptional(StrtNm));
            sb.AppendLine(QrData.GetOptional(BldgNb));
            sb.AppendLine(PstCd);
            sb.AppendLine(TwnNm);
            sb.AppendLine(City);
            return sb.ToString();
        }
        public static string GetEmptyDataValue()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                sb.AppendLine("");
            }
            return sb.ToString();
        }
    }
}
