using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrRmtInf
    {
        public QrRmtInf()
        {
            Tp = TpSelection.QRR;
        }
        public enum TpSelection { QRR,SCOR,NON}
        public TpSelection Tp { get; set; }
        public string Ref { get; set; }
        public string Ustrd { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Tp.ToString());
            sb.AppendLine(QrData.GetOptional(Ref));
            sb.Append(QrData.GetOptional(Ustrd));
            return sb.ToString();
        }
    }
}
