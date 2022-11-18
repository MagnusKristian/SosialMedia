namespace SosialMedia;

public class SignUp
{
    public Profile signUp(FriendFace friendFace)
    {
        Console.WriteLine("Welcome, new user, what is your name? ");
        string userName = Console.ReadLine();
        bool duplicate = CheckForDuplicateUser(friendFace,userName);
        while (duplicate== true)
        {
            Console.WriteLine("Try again: ");
            userName = Console.ReadLine();
            duplicate = CheckForDuplicateUser(friendFace,userName);
        }
        Profile newProfile = new Profile(userName);
        return newProfile;
    }
    public void WelcomePrompt(FriendFace friendFace)
    {
        Profile newProfile = new Profile(signUp(friendFace));
        friendFace.ListOfAllUsers.Add(newProfile);
        friendFace.SetCurrentUser(newProfile);
    }
    public bool CheckForDuplicateUser(FriendFace friendFace,string userName)
    {
        bool userNameWasTaken = false;
        foreach (var name in friendFace.GetAllUsers())
        {
            if (name.Name.ToLower() == userName.ToLower())
            {
                Console.WriteLine("username taken dude");
                userNameWasTaken = true;
            }
        }
        return userNameWasTaken;
    }
}