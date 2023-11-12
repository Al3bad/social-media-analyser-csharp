using enums;

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

int selectedFieldIdx = 0;
string[] formFields = { "ID: ", "Author: ", "Likes: ", "Shares: ", "Date/Time: ", "Content: " };
string[] fieldValues = new string[formFields.Length];
MainMenuOption selectedOption = MainMenuOption.AddPost;

do
{
    Console.Clear();

    // Display show menu
    if (currentScene == Scene.MainMenu)
    {
        UI.Heading("Select from main menu", 70);
        UI.Menu(
            new List<Option<MainMenuOption>>()
            {
                new(MainMenuOption.AddPost, "Add post"),
                new(MainMenuOption.DeletePost, "Delete post"),
                new(MainMenuOption.RetrievePost, "Retrieve post by ID"),
                new(
                    MainMenuOption.RetrieveMostLikedPosts,
                    "Retrieve the top N posts with most likes"
                ),
                new(
                    MainMenuOption.RetrieveMostSharedPosts,
                    "Retrieve the top N posts with most shares"
                ),
                new(MainMenuOption.Exit, "Exit")
            },
            selectedOption =>
            {
                switch (selectedOption)
                {
                    case MainMenuOption.AddPost:
                        currentScene = Scene.AddPostForm;
                        break;
                    case MainMenuOption.DeletePost:
                        DeletePost();
                        break;
                    case MainMenuOption.RetrievePost:
                        GetPostById();
                        break;
                    case MainMenuOption.RetrieveMostLikedPosts:
                        GetMostLikedPosts();
                        break;
                    case MainMenuOption.RetrieveMostSharedPosts:
                        GetMostSharedPosts();
                        break;
                    case MainMenuOption.Exit:
                        Environment.Exit(0);
                        break;
                }
            }
        );
    }
    else if (currentScene == Scene.AddPostForm)
    {
        // Render the form fields
        for (int i = 0; i < formFields.Length; i++)
        {
            if (i == selectedFieldIdx)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write("  ");
            }

            Console.WriteLine($"{formFields[i]}{fieldValues[i]}");
        }

        ConsoleKeyInfo keyInfo = Console.ReadKey();

        // Handle user input
        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            selectedFieldIdx = Math.Max(0, selectedFieldIdx - 1);
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            selectedFieldIdx = Math.Min(formFields.Length - 1, selectedFieldIdx + 1);
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            break; // Exit the form
        }
        else if (keyInfo.Key == ConsoleKey.Backspace)
        {
            // Delete one character from the selected field if it's not empty
            if (fieldValues[selectedFieldIdx].Length > 0)
            {
                fieldValues[selectedFieldIdx] = fieldValues[selectedFieldIdx].Substring(
                    0,
                    fieldValues[selectedFieldIdx].Length - 1
                );
            }
        }
        else
        {
            // Edit the selected field
            Console.SetCursorPosition(formFields[selectedFieldIdx].Length + 2, selectedFieldIdx);
            fieldValues[selectedFieldIdx] += keyInfo.KeyChar.ToString();
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
