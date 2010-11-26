namespace ProductTracker
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Password: {2}, Level: {3}", Id, Name, Password, Level);
        }
    }
}