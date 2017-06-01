using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrHeader
    {
        public QrHeader()
        {
            QRType = "SPC";
            Version = "0100";
            CodingType = "1";
        }
        public string QRType{ get; set; }
        public string Version { get; set; }
        public string CodingType { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(QRType);
            sb.AppendLine(Version);
            sb.AppendLine(CodingType);
            return sb.ToString();
        }
    }
}
