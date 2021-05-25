using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
