namespace SocialMediaAnalyser
{
    internal class Program
    {
        private const string WelcomeMessage = "Welcome To Social Media Analayser CLI App";
        private static Records records = new Records();

        private static void Main(string[] args)
        {
            // Start program
            UI.Heading(WelcomeMessage, 70);

            // Program init
            records
                .GetPosts()
                .Add(new Post(10, "Message 1", "username", 123, 321, "12/12/2012 12:12"));
            records
                .GetPosts()
                .Add(new Post(20, "Message 2", "username", 123, 321, "15/12/2012 12:12"));

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
        }

        private static void AddPost()
        {
            Console.WriteLine("TODO: Add post");
        }

        private static void DeletePost()
        {
            Console.Write("Please enter post ID: ");
            if (int.TryParse(Console.ReadLine(), out int postId))
            {
                records.DeletePostById(postId);
            }
        }

        private static void GetPostById()
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

        private static void GetMostLikedPosts()
        {
            Console.WriteLine("Retrieve the top N posts with most likes");
        }

        private static void GetMostSharedPosts()
        {
            Console.WriteLine("Retrieve the top N posts with most shares");
        }
    }
}
