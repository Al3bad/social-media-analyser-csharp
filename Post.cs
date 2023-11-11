public class Post
{
    public int ID { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public int Likes { get; set; }
    public int Shares { get; set; }
    public DateTime DateTime { get; set; }

    public Post() { }

    public Post(int id, string content, string author, int likes, int shares, DateTime dateTime)
    {
        ID = id;
        Content = content;
        Author = author;
        Likes = likes;
        Shares = shares;
        DateTime = dateTime;
    }

    public override string ToString()
    {
        return $"{ID},{Content},{Author},{Likes},{Shares},{DateTime}";
    }
}
