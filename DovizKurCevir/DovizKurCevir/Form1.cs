using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;

namespace DovizKurCevir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double value = double.Parse(txtValue.Text);
            string selectedCurrency = "";

            if (rbTL.Checked)
            {
                selectedCurrency = "TL";
            }
            else if (rbEURO.Checked)
            {
                selectedCurrency = "EURO";
            }
            else if (rbUSD.Checked)
            {
                selectedCurrency = "USD";
            }
            else
            {
                MessageBox.Show("Geçerli bir butona basınız.");
                return;
            }


            // Canlı döviz kurlarını almak için kullanılan URL
            string url = "https://www.turkiye.gov.tr/doviz-kurlari";

            // WebClient sınıfını kullanarak canlı döviz kurlarını içeren XML dosyasını indirin
            using (WebClient client = new WebClient())
            {
                //string xml = client.DownloadString(url);

                // İndirilen XML dosyasını işleyin ve döviz kuru değerlerini alın
                //XmlDocument doc = new XmlDocument();
                //doc.LoadXml(xml);
                string xmlData = client.DownloadString(url);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlData);

                //XmlNodeList nodes = doc.DocumentElement.SelectNodes("Currency");
                XmlNodeList currencyList = xmlDoc.GetElementsByTagName("Currency");

                foreach (XmlNode currency in currencyList)
                {

                    //string currencyCode = node.SelectSingleNode("currencyCode").InnerText;
                    //string currencyValue = node.SelectSingleNode("ForexSelling").InnerText;
                    string currencyCode = currency.SelectSingleNode("Isim").InnerText;
                    string currencyValue = currency.SelectSingleNode("ForexSelling").InnerText;

                    if (selectedCurrency == "TL")
                    {
                        if (currencyCode == "ABD DOLARI")
                        {
                            double usdValue = double.Parse(currencyValue, CultureInfo.InvariantCulture);
                            double tlValue = value / usdValue;
                            txtResult.Text += $"USD: {tlValue.ToString():F2}\n";
                        }

                        if (currencyCode == "EURO")
                        {
                            double euroValue = double.Parse(currencyValue, CultureInfo.InvariantCulture);
                            double tlValue = value / euroValue;
                            txtResult.Text += $"EURO: {tlValue.ToString():F2}\n";
                        }
                    }
                    else if (selectedCurrency == "EURO")
                    {
                        if (currencyCode == "ABD DOLARI")
                        {
                            double usdValue = double.Parse(currencyValue, CultureInfo.InvariantCulture);
                            double euroValue = value / usdValue;
                            txtResult.Text += $"USD: {euroValue.ToString():F2}\n";
                        }
                        if (currencyCode == "1 - TÜRK LİRASI")
                        {
                            double tlValue = double.Parse(currencyValue, CultureInfo.InvariantCulture);
                            double euroValue = value / tlValue;
                            txtResult.Text += $"TL :{euroValue.ToString():F2}\n";
                        }
                    }
                    else if (selectedCurrency == "USD")
                    {
                        if (currencyCode == "EURO")
                        {
                            double euroValue = double.Parse(currencyValue, CultureInfo.InvariantCulture);
                            double usdValue = value / euroValue;
                            txtResult.Text += $"EURO: {usdValue.ToString():F2}\n";
                        }
                        if (currencyCode == "1 - TÜRK LİRASI")
                        {
                            double tlValue = double.Parse(currencyValue, CultureInfo.InvariantCulture);
                            double usdValue = value / tlValue;
                            txtResult.Text += $"TL: {usdValue.ToString():F2}\n";
                        }
                    }
                }
            }
        }
    }
}
