namespace SosialMedia;

public class FriendFace
{
    public List<Profile> ListOfAllUsers { get; set; }
    public Profile? CurrentProfile { get; set; } //= new Profile("ERROR-USER-SHOULDNT SHOW UP/fix later");//TODO: fix this.
    public Menu Menu = new Menu();
    public Login Login = new Login();
    //-
    //public SignUp SignUp = new SignUp();
    public SecondSignUp SignUp = new SecondSignUp();
    //-

    public PasswordHandler passwordHandler = new PasswordHandler();
    public FriendHandler friendHandler = new FriendHandler();
    public ProfileHandler ProfileHandler = new ProfileHandler();
    public PostHandler PostHandler { get; set; }
    public SocialPage SocialPage = new SocialPage();
    //
    //swap tempdata for a database and use sql to get "real" data.
    public TempData TempData { get; set; }
    //
    public Search Search { get; set; }

    public FriendFace()
    {
        PostHandler = new PostHandler(this);
        Search = new Search(this);
        TempData = new TempData(this);
        
        tempHelperFunction();
        Run();
    }

    public void tempHelperFunction()
    {
        

        //"database" for alle brukerene på friendface
        AddExampleUsers AddUsers = new AddExampleUsers();
        //ListOfAllUsers = AddUsers.AddUsers();
        foreach (var profile in AddUsers.AddUsers())
        {
            TempData.AddUserToDatabase(profile);
        }

        //ListOfAllUsers = TempData.GetAllUsers();
        //legger til alle på friendface i vennelista til "magnus".
        // 3 for hoppe over "magnus" og "marie"- og "FriendlessPerson"
        for (int i = 3; i < TempData.GetAllUsers().Count; i++)
        {
            TempData.GetAllUsers()[0].Friends.Add(TempData.GetAllUsers()[i]);
            TempData.GetAllUsers()[i].Friends.Add(TempData.GetAllUsers()[0]);
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
        //ListOfAllUsers = TempData.GetAllUsers();
        return TempData.GetAllUsers();
    }
    public Profile GetCurrentUser()
    {
        return this.CurrentProfile;
    }
    public void ShowAllUsers()
    {
        for (int i = 0; i < GetAllUsers().Count; i++)
        {
            Console.WriteLine($"Name: {GetAllUsers()[i].Name}");
        }
    }
    public void SetCurrentUser(Profile user)
    {
        CurrentProfile = user;
    }
}