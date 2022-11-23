using System.Threading.Channels;

namespace SosialMedia;

public class PostHandler
{
    public FriendFace FriendFace { get; set; }
    public Post Post { get; set; }
    public PostHandler(FriendFace friendFace)
    {
        FriendFace = friendFace;
    }

    public void CreatePost(Profile postCreator,string postText)
    {
        Post = new Post(postCreator, postText);

        foreach (var post in FriendFace.SocialPage.Posts)
        {
            if (post.PostCreator == Post.PostCreator)
            {
                FriendFace.SocialPage.Posts.Remove(post);
            }
        }

        FriendFace.SocialPage.Posts.Add(Post);
    }

    public void DisplayPosts()
    {
        foreach (var post in FriendFace.SocialPage.Posts)
        {
            PostTemplate(post.PostCreator.Name,post.CreatedDate.ToString(),post.Text);
        }
        //---------------
    }

    public void PostTemplate(string name, string postTime,string postText)
    {
        string star = "*";
        string space = " ";
        string frameTopBottom = star.PadRight(40,'*');
        string spaceFrame = star.PadRight(39, ' ') + star;
        string shortPostText = "";
        //string shortTextLine = (star + space + shortPostText).PadRight(39, ' ') + star;
        string nameLine = (star + space +"Name: "+ name).PadRight(39, ' ') + star;
        string postTimeLine = (star + space + "Time posted: " + postTime).PadRight(39, ' ') + star;
        

        
        Console.WriteLine($"{frameTopBottom}");//star
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{nameLine}");//name
        Console.WriteLine($"{spaceFrame}");//space
        LongOrShortPostText(postText);
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{postTimeLine}");//post time
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{frameTopBottom}");//star
    }

    private static void LongOrShortPostText(string postText)
    {
        //Console.WriteLine("LongOrShortPostText KJØRTE");
        string star = "*";
        string space = " ";
        //string shortPostText = "xxxx";
        string shortTextLine = (star + space + postText).PadRight(39, ' ') + star;
        if (postText.Length <= 36)
        {
            //shortPostText = postText;
            Console.WriteLine($"{shortTextLine}");
            //Console.WriteLine("NEIIIIIII DEN ER IKKE LENGER ENN 36");
        }
        if (postText.Length > 36)
        {
            //Console.WriteLine("JAAAA DEN ER LENGER ENN 36");
            int numOfLinesNeeded = 1;
            string[] lineStrings;
            for (var i = 1; i < 10; i++)
            {
                if (postText.Length / i > 36)
                {
                    numOfLinesNeeded++;
                }
            }
            lineStrings = new string[numOfLinesNeeded];
            int lineStart = 0;
            int lineLength = 35;
            for (int i = 1; i < numOfLinesNeeded; i++)
            {
                
                if (numOfLinesNeeded > i+1)
                {
                    lineStrings[i] = postText.Substring(lineStart);
                    lineStart += 36;
                }

                if (i + 1 < numOfLinesNeeded)
                {
                    lineStrings[i] = postText.Substring(lineStart, lineLength);
                }
                
            }
            foreach (var line in lineStrings)
            {
                Console.WriteLine($"{(star + space + line).PadRight(39, ' ') + star}");
            }
        }
    }
}