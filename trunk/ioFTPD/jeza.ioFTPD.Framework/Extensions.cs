using System.Text;

namespace jeza.ioFTPD.Framework
{
    public static class Extensions
    {
        public static string FormatArgs(this IData data, string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in args)
            {
                sb.AppendFormat("{0} ", s);
            }
            return sb.ToString().Trim();
        }
    }
}