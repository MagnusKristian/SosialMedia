namespace SosialMedia;

public class SecondSignUp
{
    public Profile signUp(FriendFace friendFace)
    {
        string userName = UserName(friendFace);
        Profile newProfile = new Profile(userName);
        return newProfile;
    }
    public void WelcomePrompt(FriendFace friendFace)
    {
        Profile newProfile = new Profile(signUp(friendFace));
        friendFace.ListOfAllUsers.Add(newProfile);
        friendFace.SetCurrentUser(newProfile);
    }
    public bool CheckForDuplicateUser(FriendFace friendFace, string userName)
    {
        bool userNameWasTaken = false;
        foreach (var user in friendFace.GetAllUsers())
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