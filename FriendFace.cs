namespace SosialMedia;

public class FriendFace
{
    public List<Profile> ListOfAllUsers { get; set; }
    public Profile? CurrentProfile { get; set; } = new Profile("ERROR-USER-SHOULDNT SHOW UP/fix later");//TODO: fix this.
    public Menu Menu = new Menu();
    public Login Login = new Login();
    public SignUp SignUp = new SignUp();
    public PasswordHandler passwordHandler = new PasswordHandler();
    public FriendHandler friendHandler = new FriendHandler();
    public ProfileHandler ProfileHandler = new ProfileHandler();
    public PostHandler PostHandler { get; set; }
    public SocialPage SocialPage = new SocialPage();
    public TempData TempData { get; set; }
    public Search Search { get; set; }

    public FriendFace()
    {
        PostHandler = new PostHandler(this);
        Search = new Search(this);
        TempData = new TempData();
        tempHelperFunction();
        Run();
    }
    public void tempHelperFunction()
    {
        //"database" for alle brukerene på friendface
        AddExampleUsers AddUsers = new AddExampleUsers();
        ListOfAllUsers = AddUsers.AddUsers();
        //legger til alle på friendface i vennelista til "magnus".
        // 3 for hoppe over "magnus" og "marie"- og "FriendlessPerson"
        for (int i = 3; i < ListOfAllUsers.Count; i++)
        {
            ListOfAllUsers[0].Friends.Add(ListOfAllUsers[i]);
            ListOfAllUsers[i].Friends.Add(ListOfAllUsers[0]);
        }

        new AddExamplePosts(this);

        //Console.Clear();
        //Console.WriteLine("\nPROGRAM STARTED:THE ABOVE IS TEMPORARY AND SHOULD NOT BE SHOWN IN FINISHED PRODUCT.\n");
    }
    public void Run()
    {
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
    public void SetCurrentUser(Profile user)
    {
        CurrentProfile = user;
    }
}