// Start program
Console.WriteLine("Welcome To Social Media Analayser CLI App");
Post post = new Post(10, "Hello World!", "username", 123, 321, "12/12/2012 12:12");
Console.WriteLine(post.ToString());

// Define post class
class Post
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

    public override string ToString()
    {
        return $"{ID},{content},{author},{likes},{shares},{dateTime}";
    }
}
