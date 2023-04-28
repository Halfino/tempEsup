using System;
using System.Windows;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempEsup
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Copyright(c) 2022 Jan Koranda\n\n"
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
        }

        private async void LKAA_Click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKAA\"");
        }

        private async void LKAA_Dom_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKAA_DOM\"");
        }

        private async void LKAA_West_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKAA_WEST\"");
        }

        private async void LKTB_CTA_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKTB_CTA\"");
        }

        private async void LKMT_CTA_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKMT_CTA\"");
        }

        private async void LKPR_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKPR\"");

        }

        private async void LKTB_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKTB\"");
        }

        private async void LKMT_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKMT\"");
        }

        private async void LKKV_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKKV\"");
        }

        private async void LKPD_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKPD\"");
        }

        private async void LKVO_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKVO\"");
        }

        private async void LKCV_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKCV\"");
        }

        private async void LKNA_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKNA\"");
        }

        private async void LKKB_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKKB\"");
        }

        private async void LKAA_VFR_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKAA_VFR\"");
        }

        private async void LKAA_MAN_click(object sender, RoutedEventArgs e)
        {
            await GetSquawk("\"LKAA_MAN\"");
        }

        private async Task GetSquawk(string bank)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://esup.onehalf.eu/squawks");
                request.Content = new StringContent("{\"bank\": " + bank + "}", Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                string data = JObject.Parse(response.Content.ReadAsStringAsync().Result)["code"].ToString();
                if (data == "FULL")
                {
                    MessageBox.Show("Zvolená banka SQUAWK je obsazena. Zvolte náhradní.");
                    Code.Text = "0000";
                }
                else
                {
                    Code.Text = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Objevila se chyba, kontaktujte VID 309445" + ex);
            }
        }

        private void Lazy_click(object sender, RoutedEventArgs e)
        {
            Code.Text = "1000";
        }
    }
    
}