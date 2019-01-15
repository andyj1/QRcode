using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing;

namespace Qrcode
{
    public class codeWord
    {
        static void write()
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions
            {
                Height = 250,
                Width = 250,
                Margin = 1,
                DisableECI = true,
                CharacterSet = "UTF-8"
            };
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };

            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            String url = "https://www.amazon.com/";
            barcodeWriter
                .Write(url)
                .Save(@"C:\Users\jong7\Documents\vscode-workspace\Qrcode\generated.bmp");
        }

        static void read()
        {
            // create a barcode reader instance
            var barcodeReader = new BarcodeReader();

            // create an in memory bitmap
            var barcodeBitmap =
                (Bitmap)Bitmap.FromFile(@"C:\Users\jong7\Documents\vscode-workspace\Qrcode\generated.bmp");

            // decode the barcode from the in memory bitmap
            var barcodeResult = barcodeReader.Decode(barcodeBitmap);

            // output results to console
            Console.WriteLine($"Decoded barcode text: {barcodeResult?.Text}");
            Console.WriteLine($"Barcode format: {barcodeResult?.BarcodeFormat}");
        }

        public static void Main()
        {
            Console.WriteLine("processed.");
            write();
            read();
        }
    }
}
