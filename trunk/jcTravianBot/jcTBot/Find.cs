using System;
using System.Collections.Generic;
using System.Text;
using mshtml;
using SHDocVw;

namespace jcTBot
{
	public class Find
	{
		public static string InputTagByType(InternetExplorer ie, string type)
		{
			String name = "xxxx";
			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName("input");
			foreach (IHTMLElement elm in coll)
			{
				if (elm.getAttribute("type", 0).ToString().ToLower() == type)
				{
					name = elm.getAttribute("name", 0).ToString();
				}
			}
			return name;
		}

		public static string TextBoxValue(InternetExplorer ie, string type, string name)
		{
			String value = "xxxx";
			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName("input");
			foreach (IHTMLElement elm in coll)
			{
				if (elm.getAttribute("type", 0).ToString().ToLower() == type)
				{
					if (elm.getAttribute("name", 0).ToString() == name)
					{
						value = elm.getAttribute("value", 0).ToString();
					}
				}
			}
			return value;
		}
	}
}
