namespace SosialMedia;

public class SocialPage
{
    public List<Post> Posts { get; set; }

    public SocialPage()
    {
        Posts = new List<Post>();
    }
}