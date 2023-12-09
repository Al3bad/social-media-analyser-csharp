public class Records
{
    public List<Post> Posts { get; }

    public Records()
    {
        Posts = [];
    }

    public void ReadPosts(string filename)
    {
        Console.WriteLine($"Reading {filename}...");
        try
        {
            int validRecordsCount = 0;
            int invalidRecordsCount = 0;
            using StreamReader sr = File.OpenText(filename);
            string row;
            while ((row = sr.ReadLine()) != null)
            {
                try
                {
                    string[] fields = Parser.ParseCSV(row, 6);
                    validRecordsCount++;
                    Posts.Add(new Post()
                    {
                        ID = Parser.ParseInt(fields[0], 0),
                        Content = Parser.ParseStr(fields[1], allowEmpty: true),
                        Author = Parser.ParseStr(fields[2], allowSpaces: false),
                        Likes = Parser.ParseInt(fields[3], 0),
                        Shares = Parser.ParseInt(fields[4], 0),
                        DateTime = Parser.ParseDateTime(fields[5], "d/M/yyyy HH:mm")
                    });
                }
                catch (Exception)
                {
                    invalidRecordsCount++;
                }
            }
            Console.WriteLine($"Number of valid posts {validRecordsCount}");
            Console.WriteLine($"Number of invalid posts {invalidRecordsCount}");
            Console.WriteLine("Press enter to continue...");
            _ = Console.ReadLine();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File does not exist! Press enter to continer...");
            _ = Console.ReadLine();
        }

    }

    public Post? GetPostById(int id)
    {
        return Posts.Find(post => post.ID == id);
    }

    public void DeletePostById(int id)
    {
        int postIdx = Posts.FindIndex(post => post.ID == id);
        if (postIdx != -1)
        {
            Posts.RemoveAt(postIdx);
        }
    }

    public IEnumerable<Post> GetMostLikedPosts(int limit)
    {
        return (from post in Posts
                orderby post.Likes descending
                select post).Take(limit);
    }

    public IEnumerable<Post> GetMostSharedPosts(int limit)
    {
        return (from post in Posts
                orderby post.Shares descending
                select post).Take(limit);
    }

}
