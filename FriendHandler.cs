namespace SosialMedia;

public class FriendHandler
{
    public void AcceptFriendRequest(Profile currentProfile,Profile newFriend)
    {
        currentProfile.Friends.Add(newFriend);
        Console.WriteLine($"{currentProfile.Name} is now friends with {newFriend.Name}");
    }
    public void DeclineFriendRequest()
    {
        Console.WriteLine("Decline friend request.");
        Console.WriteLine("NOT MADE YET. ");
    }

    public void ShowFriendRequests(FriendFace friendFace)
    {
        foreach (var newFriend in friendFace.GetCurrentUser().PendingFriends)
        {
            Console.WriteLine($"{newFriend.Name} wants to be your friend.");
            Console.WriteLine("Type '1' to accept. Type '2' to decline.");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("Type '1' to accept. Type '2' to decline.");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    AcceptFriendRequest(friendFace.GetCurrentUser(),newFriend);
                    break;
                case "2":
                    DeclineFriendRequest();
                    break;
            }
        }
    }
}