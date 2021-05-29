using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace codibook.Classes
{
    public class htmlParser
    {
        public string GetOgTitle(string link)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(link);
            HtmlNodeCollection ogTitle = htmlDoc.DocumentNode.SelectNodes("//meta[@property='og:title']");

            return ogTitle[0].Attributes["content"].Value;
        }

        public string GetOgImage(string link)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(link);

            HtmlNodeCollection ogImage = htmlDoc.DocumentNode.SelectNodes("//meta[@property='og:image']");

            return ogImage[0].Attributes["content"].Value;

        }

        public BitmapImage LoadImage(string url)   //Image URL -> Bitmap 으로 변환, Image1.Source = LoadImage(“url”) 이런식으로 쓰면 됨
        {

            try
            {

                if (string.IsNullOrEmpty(url))

                    return null;

                WebClient wc = new WebClient();

                Byte[] MyData = wc.DownloadData(url);

                wc.Dispose();

                BitmapImage bimgTemp = new BitmapImage();

                bimgTemp.BeginInit();

                bimgTemp.StreamSource = new MemoryStream(MyData);

                bimgTemp.EndInit();

                return bimgTemp;

            }

            catch

            {

                return null;

            }

        }
    }
}
