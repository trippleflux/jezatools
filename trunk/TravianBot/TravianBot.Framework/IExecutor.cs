namespace TravianBot.Framework
{
    public interface IExecutor
    {
        /// <summary>
        /// Parses XML file with execution actions.
        /// </summary>
        void Parse(string fileName);

        /// <summary>
        /// Execute parsed actions.
        /// </summary>
        void Process();
    }
}