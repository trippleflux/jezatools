using System.Text.RegularExpressions;

namespace TravianBot.Framework
{
    public class HtmlParser
    {
        public HtmlParser(string pageSource)
        {
            this.pageSource = pageSource;
        }

        private readonly string pageSource;
    }
}