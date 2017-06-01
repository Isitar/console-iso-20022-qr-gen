using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrCcyAmtDate
    {
        public enum CurrencySelection { CHF, EUR }
        private decimal? amt;

        public decimal? Amt
        {
            get { return amt; }
            set
            {
                if ((value.HasValue) && (value.Value.ToString(QrData.DecimalFormat).Length > 12))
                {
                    throw new ArgumentException("max length 12 (including decimal point)");
                }
                amt = value;
            }
        }

        public CurrencySelection Ccy { get; set; }
        public DateTime ReqdExctnDt { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(QrData.GetOptional(Amt));
            sb.AppendLine(Ccy.ToString());
            sb.Append(QrData.GetOptional(ReqdExctnDt));
            return sb.ToString();
        }
    }
}
