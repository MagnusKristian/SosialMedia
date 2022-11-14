namespace SosialMedia;

public class Login
{
    //SignUp signUp = new SignUp();
    public void login(FriendFace friendFace)
    {
        //Console.WriteLine("Welcome to FriendFace!");
        //Console.WriteLine("Type '1' to sign in:");
        //Console.WriteLine("Type '2' to sign up:");
        string logInChoice = "";

        bool validChoice = false;
        while (validChoice == false)
        {
            Console.Clear();
            Console.WriteLine("Welcome to FriendFace!");
            Console.WriteLine("Type '1' to sign in:");
            Console.WriteLine("Type '2' to sign up:");
            logInChoice = Console.ReadLine();
            if(logInChoice == "1" || logInChoice == "2")
            {
                validChoice = true;
                break;
            }
        }
        
        bool userFound= false;
        bool logInOk = false;
        if (logInChoice == "1")
        {
            Console.WriteLine("What is your name?(username)");
            string username = "";
            Profile chosenUser = null;
            while (userFound == false)
            {
                username = Console.ReadLine();
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
                if (userFound == false)
                {
                    Console.WriteLine("User not found. Try again.");
                    Console.WriteLine("What is your name?(username)");
                }
            }
            if (chosenUser != null && userFound == true)
            {
                Console.WriteLine("---------------");
                Console.WriteLine($"Found user '{chosenUser.Name}', Logging in...");
                friendFace.SetCurrentUser(chosenUser);
            }

            //friendFace.WelcomePrompt();
        }
        if (logInChoice == "2")
        {
            Console.WriteLine("2");
            //signUp.signUp();
            friendFace.WelcomePrompt();
        }
    }

   
}