using System;
using System.Collections.Generic;
using System.Configuration;
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
        [StringValidator(MinLength = 3, MaxLength = 3)]
        public string QRType { get; set; }
        [StringValidator(MinLength = 4, MaxLength = 4)]
        public string Version { get; set; }
        [StringValidator(MinLength = 1, MaxLength = 1)]
        public string CodingType { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(QRType);
            sb.AppendLine(Version);
            sb.Append(CodingType);
            return sb.ToString();
        }
    }
}
