using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using Gma.QrCodeNet.Encoding.Windows.Forms;
using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isitar.ISO20022.Qr.Data;

namespace Isitar.ISO20022.Qr
{
    public class QrCodeGenerator
    {
        private const int dpi = 1000;
        private const double codeSizeMm = 46;
        private const double crossSizeMm = 7;
        private const double cmInchFactor = 2.54;
        public static void Generate(QrData data, string outputPath)
        {

            var codeSizeInch = (codeSizeMm / 10) / cmInchFactor;
            var codeSizePixel = (int)(dpi * codeSizeInch);

            var encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode;
            encoder.TryEncode(data.ToString(), out qrCode);



            //var dark = new MyGColor(Color.Black);
            //var light = new MyGColor(Color.White);
            //SVGRenderer svgRenderer = new SVGRenderer(
            //    new FixedModuleSize(50, QuietZoneModules.Zero),
            //    dark, light);

            //var filePath = "E:\\temp\\output.svg";
            //File.WriteAllText(filePath, svgRenderer.WriteToString(qrCode.Matrix, false));

            //var svgDocument = SvgDocument.Open(filePath);

            //var bmp = svgDocument.Draw((int)(dpi * codeSizeInch), (int)(dpi * codeSizeInch));
            //bmp.SetResolution(dpi, dpi);
            //bmp.Save("E:\\temp\\output_fromSVG.png", ImageFormat.Png);

            //var bytes = Encoding.UTF8.GetBytes(svgRenderer.WriteToString(qrCode.Matrix));
            //using (var stream = new MemoryStream(bytes))
            //{
            //    var svgDocument = SvgDocument.Open<SvgDocument>(stream);
            //    var codeSizeInch = codeSizeMm / cmInchFactor;
            //    var bmp = svgDocument.Draw();// (int)(dpi * codeSizeInch), (int)(dpi * codeSizeInch));
            //    bmp.SetResolution(dpi, dpi);
            //    bmp.Save("E:\\temp\\output_fromSVG.png", ImageFormat.Png);
            //}



            //var bmp = svgDoc.Draw((int)(dpi * codeSizeInch), (int)(dpi * codeSizeInch));


            //var width = bmp.Width;
            //bmp.Save("E:\\temp\\output_FromSvg.png", ImageFormat.Png);


            GraphicsRenderer gRenderer = new GraphicsRenderer(
                new FixedModuleSize(100, QuietZoneModules.Zero),
                Brushes.Black, Brushes.White);




            MemoryStream ms = new MemoryStream();
            gRenderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var bmpCode = new Bitmap(ms);

            Bitmap finalImage = new Bitmap(codeSizePixel, codeSizePixel);
            finalImage.SetResolution(dpi, dpi);
            using (var g = Graphics.FromImage(finalImage))
            {
                g.DrawImage(bmpCode, new Rectangle(0, 0, codeSizePixel, codeSizePixel));
                //gRenderer.Draw(g, qrCode.Matrix);
                //gRenderer.Draw(g, qrCode.Matrix);

                var crossLocationCM = ((codeSizeMm - crossSizeMm) / 10) / 2;
                var crossLocationInch = crossLocationCM / cmInchFactor;
                var crossLocationPx = (int)(crossLocationInch * dpi);

                var crossWidthInch = (crossSizeMm / 10) / cmInchFactor;
                var crossWidthPixel = (int)(crossWidthInch * dpi);
                g.DrawImage(Properties.Resources.CH_Kreuz_7mm,
                    new Rectangle(
                        new Point(crossLocationPx, crossLocationPx),
                        new Size(crossWidthPixel, crossWidthPixel)
                        ));
            }
            finalImage.Save(outputPath, ImageFormat.Png);

            //using (FileStream fs = new FileStream("E:\\temp\\output.png", FileMode.Create, FileAccess.Write))
            //{
            //    gRenderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, fs,new Point(dpi,dpi));
            //}
        }

        //private class MyGColor : GColor
        //{
        //    public MyGColor(byte r, byte g, byte b, byte a)
        //    {
        //        R = r;
        //        G = g;
        //        B = b;
        //        A = a;
        //    }

        //    public MyGColor(Color c)
        //    {
        //        R = c.R;
        //        G = c.G;
        //        B = c.B;
        //        A = c.A;
        //    }
        //    public override byte R { get; }

        //    public override byte G { get; }

        //    public override byte B { get; }

        //    public override byte A { get; }
        //}
    }

}


