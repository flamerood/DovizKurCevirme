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

                switch (selectedCurrency)
                {
                    case "EUR":
                        if (kurTipi == "TL")
                        {
                            txtResult.Text += $"EURO: {(valueTL / eurRate).ToString("F2", CultureInfo.GetCultureInfo("tr-TR"))}{Environment.NewLine}";
                        }
                        else if (kurTipi == "USD")
                        {
                            txtResult.Text = $"EURO: {(valueUSD / (eurRate / usdRate)).ToString("F2", CultureInfo.GetCultureInfo("tr-TR"))}{Environment.NewLine}";
                        }
                        else
                        {
                            MessageBox.Show("Aynı birimler dönüştürülemez.");
                            return;
                        }
                        break;
                    case "USD":
                        if (kurTipi == "TL")
                        {
                            txtResult.Text += $"USD: {(valueTL / usdRate).ToString("F2", CultureInfo.GetCultureInfo("tr-TR"))}{Environment.NewLine}";
                        }
                        else if (kurTipi == "EUR")
                        {
                            txtResult.Text = $"USD: {(valueEUR / (usdRate / eurRate)).ToString("F2", CultureInfo.GetCultureInfo("tr-TR"))}{Environment.NewLine}";
                        }
                        else
                        {
                            MessageBox.Show("Aynı birimler dönüştürülemez.");
                            return;
                        }
                        break;    
                    case "TRY":
                        if (kurTipi == "USD")
                        {
                            txtResult.Text = $"TRY: {(valueUSD * usdRate).ToString("F2", CultureInfo.GetCultureInfo("tr-TR"))}{Environment.NewLine}";
                        }
                        else if (kurTipi == "EUR")
                        {
                            txtResult.Text += $"TRY: {(valueEUR * eurRate).ToString("F2", CultureInfo.GetCultureInfo("tr-TR"))}{Environment.NewLine}";
                        }
                        else
                        {
                            MessageBox.Show("Aynı birimler dönüştürülemez.");
                            return;
                        }
                    
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