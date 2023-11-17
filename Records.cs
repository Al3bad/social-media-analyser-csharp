public class Records
{
    public List<Post> Posts { get; }

    public Records()
    {
        Posts = [];
    }

    public void ReadPosts(string filename)
    {
        // TODO: read file
        Console.WriteLine("TODO: read file ..." + filename);

        // TODO: validate each row

        // TODO: add add post object to list
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
}
