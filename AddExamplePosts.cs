﻿namespace SosialMedia;

public class AddExamplePosts
{
    public AddExamplePosts(FriendFace friendFace)
    {
        //add examplePosts
        List<Profile> ExampleUsers = new List<Profile>();
        for (int i = 0; i < 10; i++)
        {
            ExampleUsers.Add(new Profile($"ExampleName{i}"));
            string textToAdd = $"Example-{i}- -Text";
            for (int j = 0; j < i+1; j++)
            {
                Console.WriteLine("INSERT-----------");
                textToAdd = textToAdd.Insert(10, " 123456789-123456789-123456789-");
                Console.WriteLine("-----"+textToAdd);
            }
            friendFace.SocialPage.Posts.Add(new Post(ExampleUsers[i], textToAdd));
            Thread.Sleep(200);
            Console.WriteLine(i);
            Console.WriteLine("1 second intervals on adding exampleusers");
        }
        //friendFace.SocialPage.Posts.Add(new Post(exampleUser1, "Example Text".Insert(7, " 123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-")));
        //friendFace.SocialPage.Posts.Add(new Post(exampleUser2,"Example Text".Insert(7, " 123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-123456789-")));
    }
}