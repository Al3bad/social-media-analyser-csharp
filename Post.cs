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

    public string GetColumnValue(int columnIndex)
    {
        switch (columnIndex)
        {
            case 0: return ID.ToString();
            case 1: return DateTime.ToString();
            case 2: return Author;
            case 3: return Likes.ToString();
            case 4: return Shares.ToString();
            case 5: return Content;
            default: return string.Empty;
        }
    }

    public override string ToString()
    {
        return $"{ID},{Content},{Author},{Likes},{Shares},{DateTime}";
    }
}
