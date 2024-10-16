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
            int doluSayisi = 0;
            string kurTipi = "";
            if (double.TryParse(textTL.Text.Replace('.', ','), out double valueTL))
            {
                doluSayisi++;
                kurTipi = "TL";
            }
            if (double.TryParse(textUSD.Text.Replace('.', ','), out double valueUSD))
            {
                doluSayisi++;
                kurTipi = "USD";
            }
            if (double.TryParse(txtEUR.Text.Replace('.', ','), out double valueEUR)) 
            { 
                doluSayisi++;
                kurTipi = "EUR";
            }
           
            if (doluSayisi == 0)
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
                return;
            }
            if (doluSayisi > 1)
            {
                MessageBox.Show("Lütfen tek bir kutu girin.");
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

                double result = 0;

                switch (selectedCurrency)
                {
                    case "EUR":
                        if (kurTipi == "TL")
                            result = valueTL / eurRate;
                        else if (kurTipi == "USD")
                            result = valueUSD / (eurRate / usdRate);
                        else
                            ShowError();
                        break;

                    case "USD":
                        if (kurTipi == "TL")
                            result = valueTL / usdRate;
                        else if (kurTipi == "EUR")
                            result = valueEUR / (usdRate / eurRate);
                        else
                            ShowError();
                        break;

                    case "TRY":
                        if (kurTipi == "USD")
                            result = valueUSD * usdRate;
                        else if (kurTipi == "EUR")
                            result = valueEUR * eurRate;
                        else
                            ShowError();
                        break;
                }

                if (result != 0)
                {
                    txtResult.Text += $"{selectedCurrency}: {result.ToString("N2", CultureInfo.GetCultureInfo("tr-TR"))}{Environment.NewLine}";
                }

                void ShowError()
                {
                    MessageBox.Show("Aynı birimler dönüştürülemez.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}