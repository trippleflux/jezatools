namespace jeza.ToDoList
{
    public interface IAccountInfo
    {
        string Title { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        AccountProvider Provider { get; set; }
    }
}