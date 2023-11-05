UI.Heading("Welcome To Social Media Analayser CLI App", 70);

// ----------------------------------------------
// --> Init program
// ----------------------------------------------
Records records = new();
records.Posts.Add(new Post(10, "Message 1", "username", 123, 321, "12/12/2012 12:12"));
records.Posts.Add(new Post(20, "Message 2", "username", 123, 321, "15/12/2012 12:12"));

// ----------------------------------------------
// --> Init menu
// ----------------------------------------------
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

// ----------------------------------------------
// --> Run
// ----------------------------------------------
string? selectedOption;
do
{
    // Display show menu
    UI.Heading(title, 70);
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
            AddPost();
            break;
        case "2":
            DeletePost();
            break;
        case "3":
            GetPostById();
            break;
        case "4":
            GetMostLikedPosts();
            break;
        case "5":
            GetMostSharedPosts();
            break;
        case "6":
            Console.WriteLine("Exit");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (selectedOption != "6");

// ----------------------------------------------
// --> Functions
// ----------------------------------------------
void AddPost()
{
    Console.WriteLine("TODO: Add post");
}

void DeletePost()
{
    Console.Write("Please enter post ID: ");
    if (int.TryParse(Console.ReadLine(), out int postId))
    {
        records.DeletePostById(postId);
    }
}

void GetPostById()
{
    Console.Write("Please enter post ID: ");
    if (int.TryParse(Console.ReadLine(), out int postId))
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
}

void GetMostLikedPosts()
{
    Console.WriteLine("Retrieve the top N posts with most likes");
}

void GetMostSharedPosts()
{
    Console.WriteLine("Retrieve the top N posts with most shares");
}
