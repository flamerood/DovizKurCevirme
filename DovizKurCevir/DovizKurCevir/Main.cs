using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizKurCevir
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(txtValue.Text, out double value))
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
                return;
            }

            string selectedCurrency = rbTL.Checked ? "TRY" : rbEURO.Checked ? "EUR" : rbUSD.Checked ? "USD" : null;

            if (selectedCurrency == null)
            {
                MessageBox.Show("Geçerli bir butona basınız.");
                return;
            }

            DateTime targetDate = DateTime.Today.AddDays(-1);
            string xmlData = null;

            while (xmlData == null)
            {
                string url = $"https://www.tcmb.gov.tr/kurlar/{targetDate:yyyyMM}/{targetDate:ddMMyyyy}.xml";

                try
                {
                    using (WebClient client = new WebClient())
                    {
                        xmlData = client.DownloadString(url);
                    }
                }
                catch (WebException)
                {
                    targetDate = targetDate.AddDays(-1);
                }
            }

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlData);

                var usdRateNode = xmlDoc.SelectSingleNode("//Currency[@CurrencyCode='USD']/ForexSelling");
                var eurRateNode = xmlDoc.SelectSingleNode("//Currency[@CurrencyCode='EUR']/ForexSelling");

                if (usdRateNode == null || eurRateNode == null)
                {
                    MessageBox.Show("Döviz kuru bilgileri alınamadı.");
                    return;
                }

                double usdRate = double.Parse(usdRateNode.InnerText, CultureInfo.InvariantCulture);
                double eurRate = double.Parse(eurRateNode.InnerText, CultureInfo.InvariantCulture);

                txtResult.Clear();

                switch (selectedCurrency)
                {
                    case "EUR":
                        txtResult.Text = $"USD: {(value * (eurRate / usdRate)).ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}";
                        txtResult.Text += $"TRY: {(value * eurRate).ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}";
                        break;
                    case "USD":
                        txtResult.Text = $"EURO: {(value * (usdRate / eurRate)).ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}";
                        txtResult.Text += $"TRY: {(value * usdRate).ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}";
                        break;
                    case "TRY":
                        txtResult.Text = $"USD: {(value / usdRate).ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}";
                        txtResult.Text += $"EURO: {(value / eurRate).ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}