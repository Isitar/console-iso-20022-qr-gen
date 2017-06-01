using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrCdtrInf
    {
        public QrCdtrInf()
        {
            Cdtr = new QrCdtr();
        }

        [StringValidator(MaxLength = 21, MinLength = 21)]
        public string IBAN { get; set; }

        public QrCdtr Cdtr { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(IBAN);
            sb.Append(Cdtr.ToString());
            return sb.ToString();
        }

    }
}
