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
                    Amt = 123456789.12654655m,
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
            normalData.RmtInf.Tp = QrRmtInf.TpSelection.QRR;
            normalData.RmtInf.Ref = "210000000003139471430009017";
            normalData.RmtInf.Ustrd = "uftrag vom15.09.2019##S5.09.2019##S1/01/20170309/11/10201409/20/14000000/22/36958/30/CH106017086/40/1020/41/3010";
            QrCodeGenerator.Generate(normalData, "E:\\temp\\outputRef.png");
        }
    }
}
