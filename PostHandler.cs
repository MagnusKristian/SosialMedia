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
        string textLine = (star + space + postText).PadRight(39, ' ') + star;
        //string textLine;
        //bool twoLines = false;
        //string lineOne = "";
        //string lineTwo = "";
        //string textToPrint = "";
        string nameLine = (star + space +"Name: "+ name).PadRight(39, ' ') + star;
        string postTimeLine = (star + space + "Time posted: " + postTime).PadRight(39, ' ') + star;
        if (postText.Length > 36)
        {
            int numOfLinesNeeded = 0;
            string[] lineStrings;
            for (var i=1;i<10;i++)
            {
                if (postText.Length / i > 36)
                {
                    numOfLinesNeeded ++;
                }

            }
            lineStrings = new string[numOfLinesNeeded];
            int lineStart = 0;
            int lineLength = 36;
            for (int i = 0; i < numOfLinesNeeded; i++)
            {
                lineStrings[i] = postText.Substring(lineStart, lineLength);
                lineStart += 36;
            }

            foreach (var line in lineStrings)
            {
                Console.WriteLine($"{(star + space + line).PadRight(39, ' ') + star}");
            }

            //TODO: hvis det er verdt å bruke tid på etter du er ferdig med det andre:
            //kan lage noe med modulo for å ta inn og splitte opp på flere linjer uavhengig av antall chars osv. 
            //eller sette maks antall chars på posts.
            
            //lineOne = (star+space+postText.Substring(0, postText.Length / 2)).PadRight(39, ' ') + star;
            //lineTwo = (star+space+postText.Substring(postText.Length / 2)).PadRight(39, ' ') + star;
            //twoLines = true;
            //Console.WriteLine("text too long, fix it....");
        }
        else
        {
            textLine = (star + space + postText).PadRight(39, ' ') + star;
            Console.WriteLine();
        }
        Console.WriteLine($"{frameTopBottom}");//star
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{nameLine}");//name
        Console.WriteLine($"{spaceFrame}");//space
        //if (twoLines)
        //{
        //    Console.WriteLine($"{lineOne}"); //text
        //    Console.WriteLine($"{lineTwo}"); //text
        //}
        //else
        //{
        //    Console.WriteLine($"{textLine}");//text
        //}
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{postTimeLine}");//post time
        Console.WriteLine($"{spaceFrame}");//space
        Console.WriteLine($"{frameTopBottom}");//star
    }
}