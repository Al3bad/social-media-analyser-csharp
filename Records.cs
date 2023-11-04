namespace SocialMediaAnalyser
{
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
}
