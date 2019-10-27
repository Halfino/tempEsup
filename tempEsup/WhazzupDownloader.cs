using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows;

namespace tempEsup
{
    class WhazzupDownloader
    {
        public WhazzupDownloader() { }

        public void donwloadStatus()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "status.txt");
            string dirPath = Path.Combine(Environment.CurrentDirectory, @"Data");
            Directory.CreateDirectory(dirPath);
            string uri = "http://www.ivao.aero/whazzup/status.txt";
            using (WebClient client = new WebClient())
            {
                if (!File.Exists(path))
                {
                    client.DownloadFile(uri, path);
                }
                else
                {
                    DateTime downloaded = File.GetLastWriteTime(path);
                    if (DateTime.Compare(downloaded.Date, DateTime.Today.Date) < 0)
                    {
                        client.DownloadFile(uri, path);
                    }
                }
            }

        }


        public void downloadWhazzup(string uri)
        {
           
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "whazzup.txt");
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(uri, path);
                }
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
