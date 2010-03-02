namespace jeza.Travian.Framework
{
    public class Oases
    {
        public Oases AddClassName(string className)
        {
            this.className = className;
            return this;
        }

        public Oases AddUrl(string url)
        {
            this.url = url;
            return this;
        }

        private string className;
        private string url;
    }
}