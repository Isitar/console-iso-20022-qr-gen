using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrCdtrInf
    {
        private string iban;

        public string IBAN
        {
            get { return iban; }
            set
            {
                if (value.Length != 21)
                {
                    throw new ArgumentException("Lenghth has to be 21");
                }
                iban = value;
            }
        }

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
