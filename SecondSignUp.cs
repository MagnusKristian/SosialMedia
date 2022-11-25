namespace SosialMedia;

public class SecondSignUp
{
    public Profile signUp(FriendFace friendFace)
    {
        
        string userName = UserName(friendFace);
        string fullName = FullName();
        Profile newProfile = new Profile(userName,fullName);
        newProfile.SetFullNameToPropeties(fullName);
        return newProfile;
    }

    //public void CreateUserPrompt(string userName, string fullname)
    //{

    //}
    public void WelcomePrompt(FriendFace friendFace)
    {
        Profile newProfile = new Profile(signUp(friendFace));
        //friendFace.ListOfAllUsers.Add(newProfile);
        friendFace.TempData.AddUserToDatabase(newProfile);
        friendFace.SetCurrentUser(newProfile);
    }
    public bool CheckForDuplicateUser(FriendFace friendFace, string userName)
    {
        bool userNameWasTaken = false;
        foreach (var user in friendFace.TempData.GetAllUsers())
        {
            if (user.UserName.ToLower() == userName.ToLower())
            {
                Console.WriteLine($"username '{userName}' is taken dude, try again");
                userNameWasTaken = true;
            }
        }
        return userNameWasTaken;
    }

    public string UserName(FriendFace friendFace)
    {
        Console.WriteLine("Welcome, new user, what do you want as a USERNAME (sign in)? ");
        string userName = Console.ReadLine();
        bool duplicate = CheckForDuplicateUser(friendFace, userName);
        while (duplicate == true)
        {
            Console.WriteLine("Try again: ");
            userName = Console.ReadLine();
            duplicate = CheckForDuplicateUser(friendFace, userName);
        }
        return userName;
    }

    public string FullName()
    {
        Console.WriteLine("Please enter your full name: ");
        string FullName = Console.ReadLine();
        return FullName;
    }

    public void FirstName()
    {

    }
    public void LastName()
    {

    }
    public void Name()
    {

    }
}