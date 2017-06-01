using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Qr.Data
{
    public class QrAddress
    {
        [StringValidator(MaxLength = 70, MinLength = 1)]
        public string Name { get; set; }

        [StringValidator(MaxLength = 70)]
        public string StrtNm { get; set; }

        [StringValidator(MaxLength = 16)]
        public string BldgNb { get; set; }

        [StringValidator(MaxLength = 16, MinLength = 1)]
        public string PstCd { get; set; }
        [StringValidator(MaxLength = 35, MinLength = 1)]
        public string TwnNm { get; set; }
        [StringValidator(MaxLength = 2, MinLength = 2)]
        public string City { get; set; }

        public override string ToString()
        {


            var sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine(QrData.GetOptional(StrtNm));
            sb.AppendLine(QrData.GetOptional(BldgNb));
            sb.AppendLine(PstCd);
            sb.AppendLine(TwnNm);
            sb.Append(City);
            return sb.ToString();
        }
        public static string GetEmptyDataValue()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.AppendLine("");
            }
            sb.Append("");
            return sb.ToString();
        }
    }
}
