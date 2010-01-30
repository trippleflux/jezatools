#region

using System;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class MyFormat : IFormatProvider, ICustomFormatter
    {
        // String.Format calls this method to get an instance of an
        // ICustomFormatter to handle the formatting.
        public object GetFormat(Type service)
        {
            if (service == typeof (ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        // After String.Format gets the ICustomFormatter, it calls this format
        // method on each argument.
        public string Format
            (string format,
             object arg,
             IFormatProvider provider)
        {
            if (format == null)
            {
                return String.Format("{0}", arg);
            }
            if (!format.StartsWith("B"))
            {
                if (arg is IFormattable)
                {
                    return ((IFormattable) arg).ToString(format, provider);
                }
                if (arg != null)
                {
                    return arg.ToString();
                }
            }
            format = format.Trim(new[] {'B'});
            string b = "";
            int lengthFormat = Int32.Parse(format);
            if (arg != null)
            {
                int lengthArg = arg.ToString().Length;
                if ((lengthFormat < lengthArg) && (lengthFormat > 0))
                {
                    b = arg.ToString().Substring(0, lengthFormat);
                }
                else
                {
                    b = arg.ToString();
                }
            }
            return Convert.ToString(b);
        }
    }
}