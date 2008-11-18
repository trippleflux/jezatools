namespace TravianPlayer.Framework
{
    public class TaskExecutor : IExecutor
    {
        public TaskExecutor(Game gameInfo)
        {
            this.gameInfo = gameInfo;
        }

        public Game GameInfo
        {
            get { return gameInfo; }
        }

        public TaskList Parse()
        {
            throw new System.NotImplementedException();
        }

        private readonly Game gameInfo;
    }
}