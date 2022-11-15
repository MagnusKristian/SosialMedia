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
        //Console.Clear();
        //Console.WriteLine("\nPROGRAM STARTED:THE ABOVE IS TEMPORARY AND SHOULD NOT BE SHOWN IN FINISHED PRODUCT.\n");

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

    public bool PasswordHandler(string password)
    {
        bool passwordIsGood = false;
        //bool passIsOk = false;
        bool passLengthOverEight = false;
        bool containsNumber = false;
        bool containsLetter = false;
        //bool containsSign = false; //-
        bool containsUpper = false;
        bool containsLower = false;
        //bool doesNotContainName = false; //-
        //bool differentFromPrevPass = false; //-

        if (password.Length < 8) { Console.WriteLine("Password does not contain 8 or more characters."); }

        if (password.Length >= 8) { passLengthOverEight = true; }
        foreach (var character in password)
        {
            if (char.IsDigit(character)) { containsNumber = true; }
            if (char.IsLetter(character)) { containsLetter = true; }
            //
            //if (char.IsSymbol(character)) { containsSign = true; }
            //
            if (char.IsUpper(character)) { containsUpper = true; }
            if (char.IsLower(character)) { containsLower = true; }
        }

        if (containsNumber == false) { Console.WriteLine("Password does not contain number"); }
        if (containsLetter == false) { Console.WriteLine("Password does not contain letter"); }
        //if (containsSign == false) { Console.WriteLine("Password does not contain sign"); }
        if (containsUpper == false) { Console.WriteLine("Password does not contain uppercase letter"); }
        if (containsLower == false) { Console.WriteLine("Password does not contain lowercase letter"); }
        //if (doesNotContainName == false) { Console.WriteLine("Password does not differ from name"); }
        //if (differentFromPrevPass == false) { Console.WriteLine("Password does not differ from previous password"); }
        if(
            passLengthOverEight &&
            containsNumber &&
            containsLetter &&
            /*containsSign &&*/
            containsUpper &&
            containsLower /*&&
            doesNotContainName &&*/
            /*differentFromPrevPass*/)
        {
            passwordIsGood = true;
        }
        //----------------------
        return passwordIsGood;
    }
    public void PasswordChange()
    {
        Console.WriteLine("Criteria for new password: \n " +
                          "8 characters or more in length\n" +
                          "1 or more number or sign\n" +
                          "1 or more letter character\n" +
                          "cannot be your name\n" +
                          "cannot be previous password");
        Console.WriteLine("\nType in your new password: ");
        string password = Console.ReadLine();
        if (password.Length <= 0) { return; }

        bool goodPass = false;
        while (goodPass == false)
        {
            goodPass = PasswordHandler(password);
            if (goodPass == false)
            {
                Console.WriteLine("Try again dude.");
            password = Console.ReadLine();
            }
        }

        if (goodPass == true)
        {
            GetCurrentUser().SetPassword(password);
            Console.WriteLine($"New password is: '{GetCurrentUser().GetPassword()}'");
            return;
        }
        
        


        //bool passIsOk = false;
        //bool passLengthOverEight = false;
        //bool containsNumber = false;
        //bool containsLetter = false;
        ////bool containsSign = false; //-
        //bool containsUpper = false;
        //bool containsLower = false;
        ////bool doesNotContainName = false; //-
        ////bool differentFromPrevPass = false; //-
        //if (password.Length <=0){return;}


        //bool passIsOk = false;
        //while (passIsOk == false)
        //{
        //    PasswordHandler(password);
        //    if (password.Length <= 0) { return; }



        //    if (password.Length < 8)
        //    {
        //        Console.WriteLine("Password does not contain 8 or more characters.");
        //    }
        //    else if (password.Length >= 8)
        //    {
        //        passLengthOverEight = true;
        //    }
            
        //    foreach (var character in password)
        //    {
        //        if (char.IsDigit(character))
        //        {
        //            containsNumber = true;
        //        }
        //        if (char.IsLetter(character))
        //        {
        //            containsLetter = true;
        //        }
        //        //
        //        if (char.IsSymbol(character))
        //        {
        //            containsSign = true;
        //        }
        //        //
        //        if (char.IsUpper(character))
        //        {
        //            containsUpper = true;
        //        }
        //        if (char.IsLower(character))
        //        {
        //            containsLower = true;
        //        }
        //    }
        //    //if(password)
            
        //    if (containsNumber == false) { Console.WriteLine("Password does not contain number"); }
        //    if (containsLetter == false) { Console.WriteLine("Password does not contain letter"); }
        //    if (containsSign == false) { Console.WriteLine("Password does not contain sign"); }
        //    if (containsUpper == false) { Console.WriteLine("Password does not contain uppercase letter"); }
        //    if (containsLower == false) { Console.WriteLine("Password does not contain lowercase letter"); }
        //    if (doesNotContainName == false) { Console.WriteLine("Password does not differ from name"); }
        //    if (differentFromPrevPass == false) { Console.WriteLine("Password does not differ from previous password"); }
        //    if
        //    (passLengthOverEight &&
        //     containsNumber &&
        //     containsLetter &&
        //     containsSign &&
        //     containsUpper &&
        //     containsLower &&
        //     doesNotContainName &&
        //     differentFromPrevPass)
        //    {
        //        passIsOk = true;
        //        GetCurrentUser().SetPassword(password);
        //        Console.WriteLine($"New password is: '{GetCurrentUser().Password}'");
        //        return;
        //    }
        //    Console.WriteLine("Try again...");
        //    password = Console.ReadLine();
        //}
    }
}