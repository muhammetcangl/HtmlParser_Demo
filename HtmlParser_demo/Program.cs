using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> liste = new List<string>();//Gelen veriyi saklayacağımız alan String tipinden oluşturuluyor.

            Uri url = new Uri("https://teknoparkistanbul.com.tr/firma-listesi");
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string html = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);

            foreach (HtmlNode link in dokuman.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.Contains("https://teknoparkistanbul.com.tr/firma-listesi/"))
                    Console.WriteLine(att.Value);
            }

            Console.ReadKey();
        }
    }
}
