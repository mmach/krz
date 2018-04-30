using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Lips.Tool.QRCode
{
    public static class QRCoderGenerator
    {
        public static void  GenerateSave(string guid,string value)
        {
            Guid path = Guid.NewGuid();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            string fpath = Path.Combine(HostingEnvironment.MapPath("~/Content/QR"), guid + ".png");

            string qrCodeImage = qrCode.GetGraphic(20);
            if(File.Exists(fpath))
            {
                File.Delete(fpath);
            }
            File.WriteAllBytes(fpath, Convert.FromBase64String(qrCodeImage));
            // byte[] data = Convert.FromBase64String(qrCodeImage);
            //using (Image image = Image.FromStream(new MemoryStream(data, 0, data.Length)))
            // {
                
            //    image.Save(fpath, ImageFormat.Png);  // Or Png
         //   }
        }
    }
}
