namespace TravianBot.Framework
{
    public class Loot
    {
        public int Wood { get; set; }
        public int Clay { get; set; }
        public int Iron { get; set; }
        public int Crop { get; set; }

        public int Total { get; set; }

        public int Sum()
        {
            return Wood + Clay + Iron + Crop;
        }

        public override string ToString()
        {
            return string.Format("{0,6} {1,6} {2,6} {3,6}", Wood, Clay, Iron, Crop);
        }
    }
}