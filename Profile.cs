﻿using System.Globalization;

namespace SosialMedia;

public class Profile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageURL { get; set; }
    public string Email { get; set; }
    private string Password { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public List<Profile> Friends { get; set; }

    public Profile(string name = "Unknown", string password = "1234")
    {
        Name = name;
        Password = password;
        Address = string.Empty;
        Description = $"{Name}'s description: \n";
        Friends = new List<Profile>();
        Id = Guid.NewGuid();
        Console.WriteLine($"Welcome to FriendFace, {Name}!");
        Console.WriteLine();
    }

    public string GetPassword()
    {
        return Password;
    }
    public Profile(Profile profile)
    {
        Name = profile.Name;
        Password = profile.Password;
        Address = string.Empty;
        Description = $"{Name}'s description: \n";
        Friends = new List<Profile>();
        Id = Guid.NewGuid();
        //Console.WriteLine($"Welcome to FriendFace, {Name}-PROFILE!");
        //Console.WriteLine();

    }

    public void SetPassword(string newPassword)
    {
        Password = newPassword;
    }

    public void AddFriend(Profile friendToAdd,FriendFace friendFace)
    {
        if (friendToAdd == null) { Console.WriteLine("Error, user not found, try again!"); return; }

        if (friendToAdd.Name == Name) { Console.WriteLine("You cant be friends with yourself..."); return; }
        if(Friends.Contains(friendToAdd)){ Console.WriteLine("Error, user is already a friend, try again!"); return;}
        Friends.Add(friendToAdd);
        Console.WriteLine($"{Name} is now friends with {friendToAdd.Name}");

        //add the user to the friends list also
        //friendToAdd.AddFriend(friendFace.GetCurrentUser(), friendFace);

        friendToAdd.Friends.Add(this);
        //friendToAdd.Friends.Add(friendFace.GetCurrentUser());
        Console.WriteLine($"{friendToAdd.Name} is now friends with {Name}");

    }

    public void RemoveFriend(Profile friendToRemove, Profile userRemovingFriend)
    {
        if(friendToRemove == null){ Console.WriteLine("Error, user not found, try again!"); return;}

        if (Friends.Contains(friendToRemove))
        {
            Friends.Remove(friendToRemove);
            Console.WriteLine($"{Name} is no longer friends with {friendToRemove.Name}");
            //Remove the user from the friends list also
            friendToRemove.Friends.Remove(userRemovingFriend);
        }
        else
        {
            Console.WriteLine($"Error. '{userRemovingFriend.Name}' is not currently friends with '{friendToRemove.Name}'");
        }
    }

    public void DisplayFriends()
    {
        Console.WriteLine($"Here is all of {Name}'s friends: ");
        if(Friends.Count <= 0){
            Console.WriteLine($"{Name} has no friends.");
            return;
        }
        foreach (var friend in Friends)
        {
            Console.WriteLine($"-{friend.Name}");
        }
    }

    public void AddDescription(string description )
    {
        Description = $"Description for {Name}: \n"+description;
    }

    public void ShowDescription()
    {
        Console.WriteLine($"{Description}");
    }

    public void ShowProfile(Profile user)
    {
        if (user == null)
        {
            Console.WriteLine("Error...IN SHOWPROFILE()-PROFILE");
            return;
        }
        Console.WriteLine("********************");
        Console.WriteLine($"*Name: {user.Name}");
        Console.WriteLine("*                  *");
        Console.WriteLine($"*{user.Description}");
        Console.WriteLine("*                  *");
        Console.WriteLine($"*{user.Name}'s Friends: ");
        if (user.Friends.Count>=1)
        {
            foreach (Profile friend in user.Friends)
            {
            Console.WriteLine($"*{friend.Name} ");
            Console.WriteLine("*                  *");
            }
        }
        else
        {
            Console.WriteLine($"*{user.Name} is friendless:(");
        }
        Console.WriteLine("*                  *");
        Console.WriteLine("*                  *");
        Console.WriteLine("*                  *");
        Console.WriteLine("********************");
    }
}