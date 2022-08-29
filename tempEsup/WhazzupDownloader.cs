using System;
using System.Net;
using System.IO;
using System.Windows;

namespace tempEsup
{
    class WhazzupDownloader
    {
        public WhazzupDownloader() { }

         public void downloadWhazzup(string uri)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "whazzup.json");

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(uri, path);
                }
            }
            catch (WebException e)
            {
                MessageBox.Show("Soubor whazzup nelze stahnout.Kontaktujte VID 309445 \n" + e.Message);
            }
        }
    }
}
