UI.Heading("Welcome To Social Media Analayser CLI App", 70);

// ----------------------------------------------
// --> Init program
// ----------------------------------------------
Records records = new();
records.Posts.Add(new Post(10, "Message 1", "username", 123, 321, "12/12/2012 12:12"));
records.Posts.Add(new Post(20, "Message 2", "username", 123, 321, "15/12/2012 12:12"));

// ----------------------------------------------
// --> Run
// ----------------------------------------------
Scene currentScene = Scene.MainMenu;
int selectedOptionIdx = 0;
List<string> options =
    new()
    {
        "Add post",
        "Delete post",
        "Retrieve post by ID",
        "Retrieve the top N posts with most likes",
        "Retrieve the top N posts with most shares",
        "Exit"
    };

do
{
    Console.Clear();

    // Display show menu
    if (currentScene == Scene.MainMenu)
    {
        UI.Heading("Select from main menu", 70);
        UI.Menu(options, selectedOptionIdx);
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            selectedOptionIdx = Math.Max(0, selectedOptionIdx - 1);
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            selectedOptionIdx = Math.Min(options.Count - 1, selectedOptionIdx + 1);
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            if (selectedOptionIdx == options.Count - 1)
            {
                break;
            }
            else if (selectedOptionIdx == 0)
            {
                AddPost();
            }
            else if (selectedOptionIdx == 1)
            {
                DeletePost();
            }
            else if (selectedOptionIdx == 2)
            {
                GetPostById();
            }
            else if (selectedOptionIdx == 3)
            {
                GetMostLikedPosts();
            }
            else if (selectedOptionIdx == 4)
            {
                GetMostSharedPosts();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
} while (true);

// ----------------------------------------------
// --> Functions
// ----------------------------------------------
void AddPost()
{
    Console.WriteLine("TODO: Add post");
    // TODO: take valid user input

    // TODO: create post obj

    // TODO: add object to the list
}

void DeletePost()
{
    UI.Prompt("Please enter post ID");
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

enum Scene
{
    MainMenu,
    AddPostForm,
    DeletePostForm,
    GetPostForm,
    GetPostsForm
}
