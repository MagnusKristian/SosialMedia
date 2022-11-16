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
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("*                                      *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("*        Welcome to FriendFace!        *");
            Console.WriteLine("*        Type '1' to sign in:          *");
            Console.WriteLine("*        Type '2' to sign up:          *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("****************************************");
            Console.WriteLine();
            //Console.BackgroundColor = ConsoleColor.Cyan;

            logInChoice = Console.ReadLine();
            Console.ResetColor();

            if (logInChoice == "1" || logInChoice == "2")
            {
                validChoice = true;
                Console.Clear();
                break;
            }
        }
        Console.ResetColor();
        
        bool userFound= false;
        bool logInOk = false;
        if (logInChoice == "1")
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.WriteLine("*                                      *");
            Console.WriteLine("*   What is your name?(Not username)   *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("****************************************");
            Console.WriteLine();
            Console.ResetColor();

            string username = "";
            Profile chosenUser = null;
            while (userFound == false)
            {
                username = Console.ReadLine();
                Console.Clear();
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
                            if (chosenUser.GetPassword() ==password)
                            {
                                passOk = true;
                                Console.WriteLine("Correct password");
                                friendFace.SetCurrentUser(chosenUser);
                                Console.WriteLine($"welcome back, {chosenUser.Name}!");
                            }
                        }
                    }
                }
                if (userFound == false)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("User not found. Try again.");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("****************************************");
                    Console.WriteLine("*                                      *");
                    Console.WriteLine("*   What is your name?(Not username)   *");
                    Console.WriteLine("*                                      *");
                    Console.WriteLine("****************************************");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            if (chosenUser != null && userFound == true)
            {
                //Console.WriteLine("---------------");
                //Console.WriteLine($"Found user '{chosenUser.Name}', Logging in...");
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