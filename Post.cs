namespace SosialMedia;

public class Post
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public Profile PostCreator { get; set; }
    public string Text { get; set; }

    public Post(Profile postCreator, string text)
    {
        Id = new Guid();
        CreatedDate = DateTime.Now;
        PostCreator = postCreator;
        Text = text;
    }
}