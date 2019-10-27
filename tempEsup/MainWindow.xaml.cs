using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using System.Timers;

namespace tempEsup
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;

        public MainWindow()
        {
            InitializeComponent();
            WhazzupDownloader statusDownloader = new WhazzupDownloader();
            statusDownloader.donwloadStatus();
            MessageBox.Show("Copyright(c) 2019 Jan Koranda\n\n"
                            + "Permission is hereby granted, free of charge, to any person\n"
                            + "obtaining a copy of this software and associated documentation\n"
                            + "files(the 'Software'), to deal in the Software without\n"
                            + "restriction, including without limitation the rights to use,\n"
                            + "copy, modify, merge, publish, distribute, sublicense, and / or sell\n"
                            + "copies of the Software, and to permit persons to whom the\n"
                            + "Software is furnished to do so, subject to the following\n"
                            + "conditions:\n"
                            + "\n"
                            + "The above copyright notice and this permission notice shall be included\n"
                            + " in all copies or substantial portions of the Software.\n\n"
                            + "THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,\n"
                            + "EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES\n"
                            + "OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND\n"
                            + "NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT\n"
                            + "HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,\n"
                            + "WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING\n"
                            + "FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR\n"
                            + "OTHER DEALINGS IN THE SOFTWARE.");
            Globals.previous = 0;

            //Dont know how to execute download on timer start, so using this again here
            //_timer used for tracking refresh rate only
            _time = TimeSpan.FromMinutes(5);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();

            StatusParser parser = new StatusParser();
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\", "status.txt");
            string whazzupUri = parser.parseStatus(path);
            Console.WriteLine(whazzupUri);
            WhazzupDownloader whazzupDownload = new WhazzupDownloader();
            whazzupDownload.downloadWhazzup(whazzupUri);

            //Timer to execute download after 5 minutes and reset time tracker
            using (Timer t = new Timer(TimeSpan.FromMinutes(5).TotalMilliseconds)) // Set the time (5 mins in this case)
            {
                t.AutoReset = true;
                t.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                t.Start();
            }

        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _time = TimeSpan.FromMinutes(5);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();

            StatusParser parser = new StatusParser();
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\", "status.txt");
            string whazzupUri = parser.parseStatus(path);
            Console.WriteLine(whazzupUri);
            WhazzupDownloader whazzupDownload = new WhazzupDownloader();
            whazzupDownload.downloadWhazzup(whazzupUri);
        }

        
        private void LKAA_Click(object sender, RoutedEventArgs e)
        {

            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKAA_MIN(), Globals.LKAA_MAX(), Globals.previousLKAA);
            Globals.previousLKAA = newSquawk;
            Code.Text = newSquawk.ToString();
        }

        private void LKAA_Dom_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKAA_DOM_MIN(), Globals.LKAA_DOM_MAX(), Globals.previousLKAAdom);
            Globals.previousLKAAdom = newSquawk;
            Code.Text = newSquawk.ToString();
        }

        private void LKAA_West_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKAA_WEST_MIN(), Globals.LKAA_WEST_MAX(), Globals.prevLKAAwest);
            Globals.prevLKAAwest = newSquawk;
            Code.Text = newSquawk.ToString();
        }

        private void LKAA_East_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKAA_EAST_MIN(), Globals.LKAA_EAST_MAX(), Globals.prevLKAAeast);
            Globals.prevLKAAeast = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKPR_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKPR_MIN(), Globals.LKPR_MAX(), Globals.prevLKPR);
            Globals.prevLKPR = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKTB_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKTB_MIN(), Globals.LKTB_MAX(), Globals.prevLKTB);
            Globals.prevLKTB = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKMT_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKMT_MIN(), Globals.LKMT_MAX(), Globals.prevLKMT);
            Globals.prevLKMT = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKKV_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKKV_MIN(), Globals.LKKV_MAX(), Globals.prevLKKV);
            Globals.prevLKKV = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKPD_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKPD_MIN(), Globals.LKPD_MAX(), Globals.prevLKPD);
            Globals.prevLKPD = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKVO_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKVO_MIN(), Globals.LKVO_MAX(), Globals.prevLKVO);
            Globals.prevLKVO = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKCV_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKCV_MIN(), Globals.LKCV_MAX(), Globals.prevLKCV);
            Globals.prevLKCV = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKNA_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKNA_MIN(), Globals.LKNA_MAX(), Globals.prevLKNA);
            Globals.prevLKNA = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKKB_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKKB_MIN(), Globals.LKKB_MAX(), Globals.prevLKKB);
            Globals.prevLKKB = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKAA_VFR_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKAA_VFR_MIN(), Globals.LKAA_VFR_MAX(), Globals.prevLKAAvfr);
            Globals.prevLKAAvfr = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void LKAA_MAN_click(object sender, RoutedEventArgs e)
        {
            SquawkCounter counter = new SquawkCounter();
            int newSquawk = counter.countSquawk(Globals.LKAA_MAN_MIN(), Globals.LKAA_MAN_MAX(), Globals.prevLKAAmnl);
            Globals.prevLKAAmnl = newSquawk;
            Code.Text = newSquawk.ToString("D4");
        }

        private void Lazy_click(object sender, RoutedEventArgs e)
        {
            Code.Text = "1000";
        }
    }
    
}
