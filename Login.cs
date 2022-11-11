namespace SosialMedia;

public class Login
{
    //SignUp signUp = new SignUp();
    public void login(FriendFace friendFace)
    {
        Console.WriteLine("Welcome to FriendFace!");
        Console.WriteLine("Type '1' to sign in:");
        Console.WriteLine("Type '2' to sign up:");
        string logInChoice = Console.ReadLine();

        bool validChoice = false;
        while (validChoice == false)
        {
            Console.Clear();
            Console.WriteLine("Welcome to FriendFace!");
            Console.WriteLine("Type '1' to sign in:");
            Console.WriteLine("Type '2' to sign up:");
            logInChoice = Console.ReadLine();
            if(logInChoice == "1" || logInChoice == "2")validChoice=true;
        }
        
        bool userFound= false;
        if (logInChoice == "1")
        {
            Console.WriteLine("What is your name?(username)");
            string username = Console.ReadLine();
            Profile chosenUser = null;
            while (userFound == false)
            {
                for (int i = 0; i < friendFace.ListOfAllUsers.Count; i++)
                {
                    if (username.ToLower() == friendFace.ListOfAllUsers[i].Name.ToLower())
                    {
                        userFound = true;
                        chosenUser = friendFace.ListOfAllUsers[i];
                        Console.WriteLine("What is your password?");
                        bool passOk = false;
                        while (passOk == false)
                        {
                            Console.WriteLine("Please enter correct password: ");
                            string password = Console.ReadLine();
                            if (chosenUser.Password ==password)
                            {
                                passOk = true;
                                Console.WriteLine("Correct password");
                                Console.WriteLine($"welcome back!");
                            }
                        }
                    }
                }
            }

            if (chosenUser != null && userFound == true)
            {
                Console.WriteLine($"Found user '{chosenUser.Name}', Logging in...");
                friendFace.SetCurrentUser(chosenUser);
                Console.WriteLine("hotdog");
            }

            //friendFace.WelcomePrompt();
        }
        if (logInChoice == "2")
        {
            //signUp.signUp();
            friendFace.WelcomePrompt();
        }
    }

   
}