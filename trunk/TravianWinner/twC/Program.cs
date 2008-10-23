using System;
using mshtml;
using SHDocVw;
using twL;

namespace twC
{
    class Program
    {
        static void Main(string[] args)
        {
            InternetExplorer ie = new InternetExplorerClass();
			Browser.Login("http://s6.travian.si/login.php", ie);
			//HTMLDocument pageSource = Browser.GetPageSource("http://s6.travian.si/login.php", ie);
			//Console.WriteLine(pageSource.body.innerHTML);
		}
    }
}
