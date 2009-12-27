using System.Net;

namespace TW.Helper.Http
{
    public class Page
    {
        public Page()
        {
            CookieContainer = new CookieContainer();
            CookieCollection = new CookieCollection();
        }

        public CookieContainer CookieContainer { get; set; }
        public CookieCollection CookieCollection { get; set; }
    }
}