namespace SosialMedia;

public class Login
{
    public void login(FriendFace friendFace)
    {
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
                for (int i = 0; i < friendFace.GetAllUsers().Count; i++)
                {
                    //TODO: remove after fixing login stuff:
                    if (friendFace.GetAllUsers()[i].GetUserName().ToLower().Contains(username.ToLower()))
                    {
                        Console.WriteLine("THESE CW'S ARE TEMPORARY...");
                        Console.WriteLine($"Did you mean '{friendFace.GetAllUsers()[i].GetUserName().ToLower()}'");
                        Console.WriteLine($"({friendFace.GetAllUsers()[i].GetLastName()})");
                    }
                    if (username.ToLower() == friendFace.GetAllUsers()[i].GetUserName().ToLower())
                    {
                        Console.Clear();
                        userFound = true;
                        chosenUser = friendFace.GetAllUsers()[i];
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
                                friendFace.friendHandler.CheckForFriendRequests(friendFace);

                                //TODO:For testing. Remove later ------------
                                //friendFace.ListOfAllUsers.Add(new Profile("Example new friends name1"));
                                //friendFace.ListOfAllUsers[1].AddFriend(friendFace.ListOfAllUsers[0],friendFace);
                                //if (friendFace.GetCurrentUser().Name.ToLower() == "Magnus".ToLower())
                                //{
                                //friendFace.ListOfAllUsers[1].AddFriend(friendFace.ListOfAllUsers[0],friendFace);
                                //}
                                //friendFace.GetCurrentUser().PendingFriendRequest = true;
                                //-------------


                                friendFace.friendHandler.CheckForFriendRequests(friendFace);
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
                friendFace.SetCurrentUser(chosenUser);
            }
        }
        if (logInChoice == "2")
        {
            Console.WriteLine("2");
            friendFace.SignUp.WelcomePrompt(friendFace);
            Console.WriteLine("Your password is '1234', do you want to set a new password?");
            Console.WriteLine("type '1' for YES. \nType '2' for NO.");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    friendFace.passwordHandler.PasswordChange(friendFace);
                    break;
                case "2":
                    Console.WriteLine("Thats fine, change it at a later date.");
                    break;
            }
        }
    }
}