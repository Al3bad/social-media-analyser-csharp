public class Post
{
    private readonly int ID;
    private readonly string content;
    private readonly string author;
    private readonly int likes;
    private readonly int shares;
    private readonly string dateTime;

    public Post(int ID, string content, string author, int likes, int shares, string dateTime)
    {
        this.ID = ID;
        this.content = content;
        this.author = author;
        this.likes = likes;
        this.shares = shares;
        this.dateTime = dateTime;
    }

    public int GetID()
    {
        return ID;
    }

    public string GetContent()
    {
        return content;
    }

    public override string ToString()
    {
        return $"{GetID()},{content},{author},{likes},{shares},{dateTime}";
    }
}
