﻿using enums;

UI.Heading("Welcome To Social Media Analayser CLI App", 70);

// ----------------------------------------------
// --> Init program
// ----------------------------------------------
Records records = new();
string filename = "posts.csv";
if (Environment.GetCommandLineArgs().Length > 1)
{
    filename = Environment.GetCommandLineArgs()[1];
}
records.ReadPosts(filename);

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
                    default:
                        Console.WriteLine("Invalid Options!");
                        break;
                }
            }
        );
    }
    else if (currentScene == Scene.AddPostForm)
    {
        UI.Form(
            [
                new Field<int>("ID", value => Parser.ParseInt(value, 0)),
                new Field<string>("Author", value => Parser.ParseStr(value, allowSpaces: false)),
                new Field<int>("Likes", value => Parser.ParseInt(value, 0)),
                new Field<int>("Shares", value => Parser.ParseInt(value, 0)),
                new Field<DateTime>(
                    "Date/Time",
                    value => Parser.ParseDateTime(value, "d/M/yyyy HH:mm")
                ),
                new Field<string>("Content", value => Parser.ParseStr(value)),
            ],
            (fields) =>
            {
                if (fields is null || AddPost(fields))
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
bool AddPost(List<IField> fields)
{
    Post post = new();

    // Iterate over the fields array and set values in the Post object
    try
    {
        foreach (IField field in fields)
        {
            switch (field.Label)
            {
                case "ID":
                    post.ID = ((Field<int>)field).ParsedValue;
                    break;
                case "Author":
                    post.Author = ((Field<string>)field).ParsedValue;
                    break;
                case "Likes":
                    post.Likes = ((Field<int>)field).ParsedValue;
                    break;
                case "Shares":
                    post.Shares = ((Field<int>)field).ParsedValue;
                    break;
                case "Date/Time":
                    post.DateTime = ((Field<DateTime>)field).ParsedValue;
                    break;
                case "Content":
                    post.Content = ((Field<string>)field).ParsedValue;
                    break;
                // Handle other fields if needed
                default:
                    break;
            }
        }
        records.Posts.Add(post);
        Console.WriteLine("New post has been successfuly created!");
        _ = Console.ReadLine();
        return true;
    }
    catch (Exception)
    {
        Console.WriteLine("Form is not valid! Hit enter to try again!");
        _ = Console.ReadLine();
        return false;
    }
}

void DeletePost()
{
    int? postId = UI.Prompt<int>("Please enter post ID", input => Parser.ParseInt(input, 0));
    if (postId != null)
    {
        records.DeletePostById(postId.Value);
        Console.WriteLine("Post has been successfuly deleted!");
        _ = Console.ReadLine();
    }
}

void GetPostById()
{
    int? postId = UI.Prompt<int>("Please enter post ID", input => Parser.ParseInt(input, 0));
    if (postId != null)
    {
        Post? post = records.GetPostById(postId.Value);
        if (post != null)
        {
            List<string> headings = ["ID", "Date/Time", "Author", "Likes", "Shares", "Content"];
            UI.Table(headings, [post]);
        }
        else
        {
            Console.WriteLine("Post is not found!");
        }
        _ = Console.ReadLine();
    }
}

void GetMostLikedPosts()
{
    int? limit = UI.Prompt<int>("Please enter the number of posts you want to see", input => Parser.ParseInt(input, 0));
    if (limit != null)
    {
        IEnumerable<Post> posts = records.GetMostLikedPosts(limit.Value);
        List<string> headings = ["ID", "Date/Time", "Author", "Likes", "Shares", "Content"];
        UI.Table(headings, posts.ToList());
        _ = Console.ReadLine();
    }
}

void GetMostSharedPosts()
{
    int? limit = UI.Prompt<int>("Please enter the number of posts you want to see", input => Parser.ParseInt(input, 0));
    if (limit != null)
    {
        IEnumerable<Post> posts = records.GetMostSharedPosts(limit.Value);
        List<string> headings = ["ID", "Date/Time", "Author", "Likes", "Shares", "Content"];
        UI.Table(headings, posts.ToList());
        _ = Console.ReadLine();
    }
}
