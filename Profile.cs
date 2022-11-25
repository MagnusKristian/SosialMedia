using System.Globalization;

namespace SosialMedia;

public class Profile
{
    //public Guid Guid = new Guid();
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string ImageURL { get; set; }
    private string Email { get; set; }
    private string Password { get; set; }
    private string Address { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public List<Profile> Friends { get; set; }
    public List<Profile> PendingFriends { get; set; }
    public List<Profile> SentPendingFriends { get; set; }
    public bool SentPendingFriendRequest { get; set; }
    public bool PendingFriendRequest { get; set; }

    public Profile(string userName,string fullName)
    {
        Id = Guid.NewGuid();
        Name = fullName;
        FirstName = "'FirstName'";
        LastName = "'LastName'";
        SetFullNameToPropeties(Name);
        UserName = FirstName + ("-" + Id.ToString()[^4..]); //FirstName;
        //UserName = name;
        Status = "No status set";
        Password = "1234";
        Address = "'Address'";
        Description = $"{Name}'s description: ";
        ImageURL = "'ImageURL'";
        Email = "'Email'";

        Friends = new List<Profile>();
        PendingFriends = new List<Profile>();
        SentPendingFriends = new List<Profile>();
        SentPendingFriendRequest = false;
        PendingFriendRequest = false;

        Console.WriteLine($"Welcome to FriendFace, NAME: {Name}!");
        Console.WriteLine($"Username: {UserName}.");
        Console.WriteLine($"FirstName: {FirstName}.");
        Console.WriteLine($"LastName: {LastName}.");


        Console.WriteLine();
    }
    //this needs to be fixed
    public Profile(string name = "Unknown")
    {
        Id = Guid.NewGuid();
        Name = name;
        FirstName = "'FirstName'";
        LastName = "'LastName'";
        SetFullNameToPropeties(name);
        UserName = FirstName + ("-" + Id.ToString()[^4..]); //FirstName;
        //UserName = name;
        Status = "No status set";
        Password = "1234";
        Address = "'Address'";
        Description = $"{Name}'s description: ";
        ImageURL = "'ImageURL'";
        Email = "'Email'";

        Friends = new List<Profile>();
        PendingFriends = new List<Profile>();
        SentPendingFriends = new List<Profile>();
        SentPendingFriendRequest = false;
        PendingFriendRequest = false;

        Console.WriteLine($"Welcome to FriendFace, NAME: {Name}!");
        Console.WriteLine($"Username: {UserName}.");
        Console.WriteLine($"FirstName: {FirstName}.");
        Console.WriteLine($"LastName: {LastName}.");


        Console.WriteLine();
    }

    public void someOneAllreadyNamedName(string firstName, string lastName)
    {
        //TODO: this
        //if ()
        //{
        //    //(first)name+=1/i;
        //}
    }

    public void SetFullNameToPropeties(string name)
    {
        //TODO: FUNKER IKKE, FIKS DET SNART.
        string[] firstAndLastNames = SplitNameString(name);
        
        //FirstName = firstAndLastNames[0];
        //LastName = firstAndLastNames[1];

        SetFirstName(firstAndLastNames[0]);
        SetLastName(firstAndLastNames[1]);
    }
    public string[] SplitNameString(string nameString)
    {
        if (!nameString.Contains(' '))
        {
            string[] nameStringArray = { nameString,"NOLASTNAME" };
            return nameStringArray;
        }
        string[] firstAndLastName = nameString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (firstAndLastName.Length > 2)
        {
            string[] multipleLastOrMiddleNames = new string[firstAndLastName.Length];
            multipleLastOrMiddleNames[0] = firstAndLastName[0];
            for (int i = 1; i < firstAndLastName.Length; i++)
            {
                if (i > 1)
                {
                    multipleLastOrMiddleNames[1] += (" " + firstAndLastName[i]);

                }
                else
                {
                    multipleLastOrMiddleNames[1] += firstAndLastName[i];

                }

            }
            return multipleLastOrMiddleNames;
        }
        //string firstName = firstAndLastName[0];
        //string lastName = firstAndLastName[1];
        return firstAndLastName;
    }
    //this needs to be fixed
    public Profile(Profile profile)
    {
        UserName = profile.Name;
        Name = profile.Name;
        FirstName = profile.Name;
        Status = "No status set";
        Password = profile.Password;
        Address = string.Empty;
        Description = $"{profile.Name}'s description: ";
        Friends = new List<Profile>();
        Id = Guid.NewGuid();
        PendingFriendRequest = false;
        PendingFriends = new List<Profile>();
        SentPendingFriends = new List<Profile>();
        SentPendingFriendRequest = false;
    }

    public Profile()
    {
        //this is ok, but TODO: clean up.
        UserName = "'UserName'";
        Name = "'Name'";
        FirstName = "'FirstName'";
        LastName = "'LastName'";
        Status = "No status set";
        Password = "1234";
        Address = "'Address'";
        Description = $"{"'UserName'"}'s description: ";
        ImageURL = "'ImageURL'";
        Email = "'Email'";
        Id = Guid.NewGuid();
        Friends = new List<Profile>();
        PendingFriends = new List<Profile>();
        SentPendingFriends = new List<Profile>();
        SentPendingFriendRequest = false;
        PendingFriendRequest = false;
    }


    //-----------
    public void SetStatus(string status)
    {
        Status = status;
    }
    public string GetStatus()
    {
        return Status;
    }
    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }
    public string GetLastName()
    {
        return LastName;
    }
    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }
    public string GetFirstName()
    {
        return FirstName;
    }

    public string GetPassword()
    {
        return Password;
    }
    public void SetPassword(string newPassword)
    {
        Password = newPassword;
    }

    public void SetUserName(string username)
    {
        UserName = username;
    }

    public string GetUserName()
    {
        return UserName;
    }
    public void SetName(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }

    public List<Profile> GetAllFriends()
    {
        return Friends;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }
    public string GetDescription()
    {
        return Description;
    }


    //TODO: move this out of profile
    public void AddFriend(Profile friendToAdd,FriendFace friendFace)
    {
        
        if (friendToAdd == null) { return; }
        if (friendToAdd.Name == Name) { Console.WriteLine("You cant be friends with yourself..."); return; }
        if(Friends.Contains(friendToAdd)){ Console.WriteLine("Error, user is already a friend, try again!"); return;}
        if(SentPendingFriends.Contains(friendToAdd)){ Console.WriteLine($"You have already sent a friend request to '{friendToAdd.Name}'"); return;}
        if (PendingFriends.Contains(friendToAdd)) { Console.WriteLine($"You already have a pending friend request from {friendToAdd.Name}, go accept or decline."); return; }
        friendFace.friendHandler.SendFriendRequest(this,friendToAdd);
    }
    public void RemoveFriend(Profile friendToRemove)
    {
        if (friendToRemove == null) { return; }

        if (friendToRemove == null){ Console.WriteLine("Error, user not found, try again!"); return;}
        //fjern den over.?

        if (Friends.Contains(friendToRemove))
        {
            Friends.Remove(friendToRemove);
            Console.WriteLine($"{Name} is no longer friends with {friendToRemove.Name}");
            //Remove the user from the friends list also
            if (friendToRemove.GetAllFriends().Contains(this))
            {
                friendToRemove.RemoveFriend(this);
            }
        }
        else
        {
            Console.WriteLine($"Error. '{this.Name}' is not currently friends with '{friendToRemove.Name}'");
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
        //TODO: fix profile, make better
        //TODO: do i need this?
        if (user == null)
        {
            Console.WriteLine("Error...IN SHOWPROFILE()-PROFILE");
            return;
        }

        Console.WriteLine("******************************");
        Console.WriteLine("*                            *");
        if (user == this)
        {
            Console.WriteLine($"* Your username is: '{UserName}'".PadRight(29, ' ') + "*");
            string PrintPendingFriends = this.PendingFriendRequest ? $"* Pending friend requests: '{PendingFriends.Count}'".PadRight(29, ' ') + "*"
                : "Pending friend requests: 0".PadRight(29, ' ') + "*";
            Console.WriteLine(PrintPendingFriends);
        }
        Console.WriteLine($"* Name: {user.Name}".PadRight(29,' ')+"*");
        Console.WriteLine("*                            *");
        Console.WriteLine($"* FirstName: {user.GetFirstName()}".PadRight(29, ' ') + "*");
        Console.WriteLine("*                            *");

        Console.WriteLine($"* {user.Description}".PadRight(29, ' ') + "*");
        Console.WriteLine("*                            *");          
        Console.WriteLine($"* {user.Name}'s Friends: ".PadRight(29, ' ') + "*");
        if (user.Friends.Count>=1)
        {
            foreach (var friend in user.Friends)
            {
                Console.WriteLine($"* {friend.Name}".PadRight(29,' ')+"*");
            }
        }
        else
        {
            Console.WriteLine($"*{user.Name} is friendless:(".PadRight(29, ' ') + "*");
        }
        Console.WriteLine("*                            *");
        Console.WriteLine("*                            *");
        Console.WriteLine("*                            *");
        Console.WriteLine("******************************");
        Console.WriteLine();
        if (user == this)
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Username: {UserName}.");
            Console.WriteLine($"FirstName: {FirstName}.");
            Console.WriteLine($"LastName: {LastName}.");
        }
        
    }
}