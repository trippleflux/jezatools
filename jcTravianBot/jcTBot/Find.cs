using System;
using System.Collections.Generic;
using System.Text;
using mshtml;
using SHDocVw;

namespace jcTBot
{
	public class Find
	{
		public static string TagByName(InternetExplorer ie, String tagName)
		{
			String name = "xxxx";
			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName(tagName);
			foreach (IHTMLElement elm in coll)
			{
				name = elm.innerText;
			}
			return name;
		}


		public static string AttributeByTagName(InternetExplorer ie, String tagName, String attribute)
		{
			String name = "xxxx";
			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName(tagName);
			foreach (IHTMLElement elm in coll)
			{
				String attr = elm.getAttribute(attribute, 0).ToString();
				if ((attr.IndexOf("dorf1.php?a=") > -1) 
					|| (attr.IndexOf("dorf2.php?a=") > -1))
				{
					name = attr;
					break;
				}
			}
			return name;
		}


		/// <summary>
		/// Finds <input> TAG by type
		/// </summary>
		/// <param name="ie"><see cref="InternetExplorer"/></param>
		/// <param name="type">Attribute 'type'</param>
		/// <returns>Attribute 'name'</returns>
		/// 
		public static string InputTagByType(InternetExplorer ie, string type)
		{
			String name = "xxxx";
			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName("input");
			foreach (IHTMLElement elm in coll)
			{
				//Console.WriteLine(elm.getAttribute("type", 0).ToString().ToLower());
				if (elm.getAttribute("type", 0).ToString().ToLower() == type)
				{
					name = elm.getAttribute("name", 0).ToString();
					break;
				}
			}
			return name;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ie"></param>
		/// <param name="tag"></param>
		/// <param name="type"></param>
		/// <param name="name"></param>
		/// <returns><c>value</c></returns>
		/// <example>
		/// <input type="hidden" name="id" value="33"> will return 33
		/// </example>
		public static string ValueFromTagTypeAndName(InternetExplorer ie, string tag, string type, string name)
		{
			String value = "xxxx";
			IHTMLDocument3 doc3 = (IHTMLDocument3)ie.Document;
			IHTMLElementCollection coll = doc3.getElementsByTagName(tag);
			foreach (IHTMLElement elm in coll)
			{
				if (elm.getAttribute("type", 0).ToString().ToLower() == type)
				{
					if (elm.getAttribute("name", 0).ToString() == name)
					{
						value = elm.getAttribute("value", 0).ToString();
						break;
					}
				}
			}
			return value;
		}
	}
}
