namespace SosialMedia;

public class FriendHandler
{
    public void SendFriendRequest(Profile currenProfile, Profile newFriend)
    {
        newFriend.PendingFriends.Add(currenProfile);
        newFriend.PendingFriendRequest = true;
        currenProfile.SentPendingFriends.Add(newFriend);
        currenProfile.SentPendingFriendRequest = true;
    }
    public void AcceptFriendRequest(FriendFace friendFace,Profile newFriend)
    {
        //adds friend to this user
        friendFace.GetCurrentUser().Friends.Add(newFriend);
        Console.WriteLine($"{friendFace.GetCurrentUser().Name} is now friends with {newFriend.Name}");
        friendFace.GetCurrentUser().PendingFriends.Remove(newFriend);
        if (friendFace.GetCurrentUser().PendingFriends.Count < 1)
        {
            friendFace.GetCurrentUser().PendingFriendRequest = false;
        }
        //adds this user to friend
        newFriend.Friends.Add(friendFace.GetCurrentUser());
        //for testing(cw under)
        Console.WriteLine($"{newFriend.Name} is now friends with {friendFace.GetCurrentUser().Name}.");
        newFriend.SentPendingFriends.Remove(friendFace.GetCurrentUser());
        if (newFriend.SentPendingFriends.Count<1)
        {
            newFriend.SentPendingFriendRequest = false;
        }

    }
    public void DeclineFriendRequest(FriendFace friendFace,Profile newFriend)
    {
        Console.WriteLine("Decline friend request.");
        friendFace.GetCurrentUser().PendingFriends.Remove(newFriend);
        Console.WriteLine($"{newFriend.Name}'s friend request was denied. (Removed from pending friends.)");
        newFriend.SentPendingFriends.Remove(friendFace.GetCurrentUser());
        if (newFriend.SentPendingFriends.Count < 1)
        {
            newFriend.SentPendingFriendRequest = false;
        }
    }

    public void CheckForFriendRequests(FriendFace friendFace)
    {
        if (friendFace.GetCurrentUser().PendingFriends.Count < 1)
        {
            friendFace.GetCurrentUser().PendingFriendRequest = false;
        }

        if (friendFace.GetCurrentUser().PendingFriends.Count >= 1)
        {
            friendFace.GetCurrentUser().PendingFriendRequest = true;
        }
    }

    public void ShowSentFriendRequests(FriendFace friendFace)
    {
        if (friendFace.GetCurrentUser().SentPendingFriends.Count >= 1)
        {
            friendFace.GetCurrentUser().SentPendingFriendRequest = true;
            Console.WriteLine($"**** You have sent friend requests to: ****");
            foreach (var potentialFriend in friendFace.GetCurrentUser().SentPendingFriends)
            {
                Console.WriteLine($"*- {potentialFriend.Name}");
            }
        }

        if (friendFace.GetCurrentUser().SentPendingFriendRequest == false)
        {
            Console.WriteLine("**** You do not have any pending sent friend requests. ****");
        }
    }
    public void ShowFriendRequests(FriendFace friendFace)
    {
        if (friendFace.GetCurrentUser().PendingFriendRequest)
        {
            for (int i = 0; i < friendFace.GetCurrentUser().PendingFriends.Count; i++)
            {
                Console.WriteLine($"{friendFace.GetCurrentUser().PendingFriends[i].Name} wants to be your friend.");
                Console.WriteLine("Type '1' to accept. Type '2' to decline. Type 'x' to Skip for now.");
                string choice = Console.ReadLine();
                if (choice.ToLower()== "x")
                {
                    return;
                }
                while (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Type '1' to accept. Type '2' to decline.");
                    choice = Console.ReadLine();
                }
                switch (choice)
                {
                    case "1":
                        AcceptFriendRequest(friendFace, friendFace.GetCurrentUser().PendingFriends[i]);
                        break;
                    case "2":
                        DeclineFriendRequest(friendFace, friendFace.GetCurrentUser().PendingFriends[i]);
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine($"No pending friend requests for {friendFace.GetCurrentUser().Name}");
        }
        CheckForFriendRequests(friendFace);

        //List<Profile> friendReqProfiles = friendFace.GetCurrentUser().PendingFriends;
        //foreach (var newFriend in friendReqProfiles)
        //{
        //    Console.WriteLine($"{newFriend.Name} wants to be your friend.");
        //    Console.WriteLine("Type '1' to accept. Type '2' to decline.");
        //    string choice = Console.ReadLine();
        //    while (choice != "1" && choice != "2")
        //    {
        //        Console.WriteLine("Type '1' to accept. Type '2' to decline.");
        //        choice = Console.ReadLine();
        //    }
        //    switch (choice)
        //    {
        //        case "1":
        //            AcceptFriendRequest(friendFace,newFriend);
        //            break;
        //        case "2":
        //            DeclineFriendRequest(friendFace,newFriend);
        //            break;
        //    }
        //}
    }
}