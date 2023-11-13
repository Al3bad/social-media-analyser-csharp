using enums;

UI.Heading("Welcome To Social Media Analayser CLI App", 70);

// ----------------------------------------------
// --> Init program
// ----------------------------------------------
Records records = new();
records.Posts.Add(
    new Post(
        10,
        "Message 1",
        "username",
        123,
        321,
        Parser.ParseDateTime("12/12/2012 12:12", "dd/MM/yyyy HH:mm")
    )
);
records.Posts.Add(
    new Post(
        20,
        "Message 2",
        "username",
        123,
        321,
        Parser.ParseDateTime("12/12/2012 12:12", "dd/MM/yyyy HH:mm")
    )
);

// ----------------------------------------------
// --> Run
// ----------------------------------------------
Scene currentScene = Scene.MainMenu;
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
        UI.Form(
            new List<IField>()
            {
                new Field<int>("ID", value => Parser.ParseInt(value, 0)),
                new Field<string>("Author", value => Parser.ParseStr(value)),
                new Field<int>("Likes", value => Parser.ParseInt(value, 0)),
                new Field<int>("Shares", value => Parser.ParseInt(value, 0)),
                new Field<DateTime>(
                    "Date/Time",
                    value => Parser.ParseDateTime(value, "dd/MM/yyyy HH:mm")
                ),
                new Field<string>("Content", value => Parser.ParseStr(value)),
            },
            (fields) =>
            {
                if (AddPost(fields))
                {
                    currentScene = Scene.MainMenu;
                }
            }
        );
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
