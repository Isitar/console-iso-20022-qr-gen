using Isitar.ISO20022.Qr;
using Isitar.ISO20022.Qr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isitar.ISO20022.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var normalData = new QrData
            {
                Header = new QrHeader(),
                CdtrInf = new QrCdtrInf
                {
                    IBAN = "CH8300700114000048160",
                    Cdtr = new QrCdtr
                    {
                        Name = "Pascal Lüscher",
                        StrtNm = "Bernstrasse",
                        BldgNb = "159",
                        PstCd = "4852",
                        TwnNm = "Rothrist",
                        City = "CH"
                    }
                },
                CcyAmtDate = new QrCcyAmtDate
                {
                    Amt = 123456789.12m,
                    Ccy = QrCcyAmtDate.CurrencySelection.CHF,
                    ReqdExctnDt = DateTime.Today.AddDays(30)
                },
                RmtInf = new QrRmtInf
                {
                    Tp = QrRmtInf.TpSelection.NON,
                    Ref = "",
                    Ustrd = ""
                }

            };



            QrCodeGenerator.Generate(normalData, "E:\\temp\\outputNormal.png");
            
        }
    }
}
