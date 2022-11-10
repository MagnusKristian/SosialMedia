namespace SosialMedia;

public class FriendFace
{
    public List<Profile> ListOfAllUsers { get; set; }
    public Profile CurrentProfile { get; set; }
    public Menu Menu = new Menu();
    public Login Login = new Login();

    public FriendFace()
    {
        ListOfAllUsers = new List<Profile>();
        
        //Login.login(this);

        //WelcomePrompt();

        ListOfAllUsers.Add(new Profile("Magnus"));
        ListOfAllUsers.Add(new Profile("Marie"));
        ListOfAllUsers.Add(new Profile("Terje"));
        ListOfAllUsers.Add(new Profile("Eskil"));
        ListOfAllUsers.Add(new Profile("Linn"));
        ListOfAllUsers.Add(new Profile("Tommy"));
        ListOfAllUsers.Add(new Profile("Tom"));
        ListOfAllUsers.Add(new Profile("Marius"));
        ListOfAllUsers.Add(new Profile("Thorbjørn"));
        ListOfAllUsers.Add(new Profile("Kristian G"));
        ListOfAllUsers.Add(new Profile("Kristian B"));
        ListOfAllUsers.Add(new Profile("Erik"));
        ListOfAllUsers.Add(new Profile("Viktor"));

        for (int i = 1; i < ListOfAllUsers.Count; i++)
        {
            ListOfAllUsers[0].AddFriend(ListOfAllUsers[i],CurrentProfile);
        }

        Console.WriteLine();
        Console.WriteLine("PROGRAM STARTED:THE ABOVE IS TEMPORARY AND SHOULD NOT BE SHOWN IN FINISHED PRODUCT.");
        Console.WriteLine();

        Login.login(this);

        Menu.MenuPrompt(CurrentProfile, ListOfAllUsers);
    }

    private FriendFace SetCurrentUser()
    {
        throw new NotImplementedException();
    }

    public void WelcomePrompt()
    {
        Console.WriteLine("Welcome to friendFace! What is your name?");
        string userName = Console.ReadLine();
        Profile newProfile = new Profile(userName);
        ListOfAllUsers.Add(newProfile);
        //CurrentProfile = ListOfAllUsers[0];
        SetCurrentUser(newProfile);

    }

    public void SetCurrentUser(Profile user)
    {
        CurrentProfile = user;
    }
}