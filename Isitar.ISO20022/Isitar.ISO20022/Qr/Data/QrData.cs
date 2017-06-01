using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrData
    {
        public const string DecimalFormat = "0.00";
        public const string DateTimeFormat = "yyyy-MM-dd";
        public QrHeader Header { get; set; }
        public QrCdtrInf CdtrInf { get; set; }
        public QrUltmtCdtr UltmtCdtr { get; set; }
        public QrCcyAmtDate CcyAmtDate { get; set; }
        public QrUltmtDbtr UltmtDbtr { get; set; }
        public QrRmtInf RmtInf { get; set; }

        public override string ToString()
        {
            
            

            var sb = new StringBuilder();
            sb.AppendLine(Header.ToString());
            sb.AppendLine(CdtrInf.ToString());
            if (UltmtCdtr != null)
            {
                sb.AppendLine(UltmtCdtr.ToString());
            }
            else
            {
                sb.AppendLine(QrUltmtCdtr.GetEmptyDataValue());
            }
            
            sb.AppendLine(CcyAmtDate.ToString());

            if (UltmtDbtr != null)
            {
                sb.AppendLine(UltmtDbtr.ToString());
            }
            else
            {
                sb.AppendLine(QrUltmtDbtr.GetEmptyDataValue());
            }

            sb.Append(RmtInf.ToString());

            return sb.ToString();
        }

        public static string GetOptional(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s;
        }
        public static string GetOptional(decimal? d)
        {
            if (!d.HasValue) return "";

            return d.Value.ToString(DecimalFormat);
        }

        public static string GetOptional(DateTime dt)
        {
            if (dt == null) return "";

            return dt.ToString(DateTimeFormat);
        }
    }
}
