namespace SosialMedia;

public class Profile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public List<Profile> Friends { get; set; }

    public Profile(string name = "Unknown")
    {
        Name = name;
        Address = string.Empty;
        Description = $"Description for {Name}: \n";
        Friends = new List<Profile>();
        Id = Guid.NewGuid();
        Console.WriteLine($"Welcome to FriendFace, {Name}!");
        Console.WriteLine();
    }
    public void AddFriend(Profile friendToAdd,Profile userAddingFriend)
    {
        if (friendToAdd == null) { Console.WriteLine("Error, user not found, try again!"); return; }

        if(Friends.Contains(friendToAdd)){ Console.WriteLine("Error, user is already a friend, try again!"); return;}
        Friends.Add(friendToAdd);
        Console.WriteLine($"{Name} is now friends with {friendToAdd.Name}");

        //add the user to the friends list also
        userAddingFriend.Friends.Add(this);

    }

    public void RemoveFriend(Profile friendToRemove)
    {
        if(friendToRemove == null){ Console.WriteLine("Error, user not found, try again!"); return;}
        Friends.Remove(friendToRemove);
        Console.WriteLine($"{Name} is no longer friends with {friendToRemove.Name}");
    }

    public void DisplayFriends()
    {
        Console.WriteLine($"Here is all of {Name}'s friends: ");
        foreach (var friend in Friends)
        {
            Console.WriteLine($"{friend.Name}");
        }
    }

    public void AddDescription(string description )
    {
        Description = $"Description for {Name}: \n"+description;
    }

    public void ShowDescription()
    {
        Console.WriteLine(Description);
    }

    public void ShowProfile(Profile user)
    {
        Console.WriteLine("********************");
        Console.WriteLine($"*Name: {user.Name}");
        Console.WriteLine("*                  *");
        Console.WriteLine($"*{user.Description}");
        Console.WriteLine("*                  *");
        Console.WriteLine($"*Friends:          *");
        foreach (var friend in user.Friends)
        {
            Console.WriteLine($"*{friend.Name} ");
            Console.WriteLine("*                  *");
        }
        Console.WriteLine("*                  *");
        Console.WriteLine("*                  *");
        Console.WriteLine("*                  *");
        Console.WriteLine("********************");
    }
}