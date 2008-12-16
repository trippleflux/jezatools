namespace TravianBot.Framework
{
    public interface IReader
    {
        void Parse(string pageSource);
        void Process();
    }
}