namespace SosialMedia;

public class FriendFace
{
    public List<Profile> ListOfAllUsers { get; set; }
    public Profile? CurrentProfile { get; set; } = new Profile("ERROR-USER-SHOULDNT SHOW UP/fix later");
    public Menu Menu = new Menu();
    public Login Login = new Login();
    SignUp signup = new SignUp();


    public FriendFace()
    {
        //"database" for alle brukerene på friendface
        ListOfAllUsers = new List<Profile>();
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

        //legger til alle på friendface i vennelista til "magnus".
        for (int i = 1; i < ListOfAllUsers.Count; i++)
        {
            ListOfAllUsers[0].AddFriend(ListOfAllUsers[i],this);
        }
        Console.WriteLine("\nPROGRAM STARTED:THE ABOVE IS TEMPORARY AND SHOULD NOT BE SHOWN IN FINISHED PRODUCT.\n");

        Login.login(this);

        Menu.MenuPrompt(this);
    }

    public List<Profile> GetAllUsers()
    {
        return this.ListOfAllUsers;
    }
    public Profile GetCurrentUser()
    {
        return this.CurrentProfile;
    }

    public void ShowAllUsers()
    {
        for (int i = 0; i < ListOfAllUsers.Count; i++)
        {
            Console.WriteLine($"Name: {ListOfAllUsers[i].Name}");
        }
    }
    public void WelcomePrompt()
    {
        //signup.signUp();

        //Console.WriteLine("Welcome to friendFace! What is your name?");
        //string userName = Console.ReadLine();
        Profile newProfile = new Profile(signup.signUp(this));
        ListOfAllUsers.Add(newProfile);
        //ListOfAllUsers.Add(new Profile(userName));
        
        SetCurrentUser(newProfile);

    }

    public void SetCurrentUser(Profile user)
    {
        CurrentProfile = user;
    }
}