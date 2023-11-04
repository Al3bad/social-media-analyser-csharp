// Start program
Console.WriteLine("Welcome To Social Media Analayser CLI App");

// Program init
Records records = new Records();
records.GetPosts().Add(new Post(10, "Message 1", "username", 123, 321, "12/12/2012 12:12"));
records.GetPosts().Add(new Post(20, "Message 2", "username", 123, 321, "15/12/2012 12:12"));

// Init menu
string title = "Select from main menu";
Dictionary<string, string> options =
    new()
    {
        { "1", "Add post" },
        { "2", "Delete post" },
        { "3", "Retrieve post by ID" },
        { "4", "Retrieve the top N posts with most likes" },
        { "5", "Retrieve the top N posts with most shares" },
        { "6", "Exist" }
    };

string? selectedOption;
int postId;

do
{
    // Display show menu
    Console.WriteLine(title);
    foreach (string option in options.Keys)
    {
        Console.WriteLine($"{option}) {options[option]}");
    }
    // Get user input
    selectedOption = Console.ReadLine();
    Console.WriteLine(selectedOption);
    switch (selectedOption)
    {
        case "1":
            Console.WriteLine("Add post");
            break;
        case "2":
            Console.Write("Please enter post ID: ");
            if (int.TryParse(Console.ReadLine(), out postId))
            {
                records.DeletePostById(postId);
            }
            break;
        case "3":
            Console.Write("Please enter post ID: ");
            if (int.TryParse(Console.ReadLine(), out postId))
            {
                Post post = records.GetPostById(postId);
                if (post != null)
                {
                    Console.WriteLine(post);
                }
                else
                {
                    Console.WriteLine("Post is not found!");
                }
            }
            break;
        case "4":
            Console.WriteLine("Retrieve the top N posts with most likes");
            break;
        case "5":
            Console.WriteLine("Retrieve the top N posts with most shares");
            break;
        case "6":
            Console.WriteLine("Exit");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (selectedOption != "6");

// Definition of post object
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

// Definition of user object
class Records
{
    private List<Post> posts;

    public Records()
    {
        posts = new List<Post>();
    }

    public List<Post> GetPosts()
    {
        return posts;
    }

    public void ReadPosts(string filename)
    {
        // TODO: read file
        Console.WriteLine("TODO: read file ..." + filename);

        // TODO: validate each row

        // TODO: add add post object to list
    }

    public Post GetPostById(int id)
    {
        return posts.Find(post => post.GetID() == id);
    }

    public void DeletePostById(int id)
    {
        int postIdx = posts.FindIndex(post => post.GetID() == id);
        if (postIdx != -1)
        {
            posts.RemoveAt(postIdx);
        }
    }
}
