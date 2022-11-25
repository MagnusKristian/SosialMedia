namespace SosialMedia;

public class Menu
{
    public void MenuPrompt(FriendFace friendFace)
    {
        while (true)
        {
            Console.WriteLine($"");
            Console.WriteLine("--------------------------------------------------");
            
            Console.WriteLine("\n Main menu, here are your choices: ");
            Console.WriteLine("1. Add friend: ");
            Console.WriteLine("2. Remove friend: ");
            Console.WriteLine("3. View all your friends: ");
            Console.WriteLine("4. Choose a friend and view their profile: ");
            Console.WriteLine("5. Settings: ");
            Console.WriteLine("6. Sign out: ");
            Console.WriteLine("7. View your own profile: ");
            Console.WriteLine("8. View friend requests: ");
            Console.WriteLine("9. Search: ");
            Console.WriteLine("10. Display posts: ");

            Console.WriteLine("22. Debug show current user: ");
            Console.WriteLine("23. Debug show all users: ");
            Console.WriteLine("24. Show sent pending friend requests: ");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"");
            Console.WriteLine("Type in the number of your choice: ");

            if (friendFace.GetCurrentUser().PendingFriendRequest)
            {
                Console.WriteLine($"You have {friendFace.GetCurrentUser().PendingFriends.Count} friend requests.");
            }
            

            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    if (friendFace.GetCurrentUser().SentPendingFriends.Count<1) { friendFace.GetCurrentUser().SentPendingFriendRequest = false; }
                    if (friendFace.GetCurrentUser().SentPendingFriends.Count >= 1) { friendFace.GetCurrentUser().SentPendingFriendRequest = true; }
                    friendFace.friendHandler.ShowSentFriendRequests(friendFace);
                    Console.WriteLine("1");
                    Console.WriteLine("Add friend: ");
                    friendFace.GetCurrentUser().AddFriend(CheckForFriendInDatabase(friendFace.GetAllUsers()),friendFace);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("2");
                    Console.WriteLine("Remove friend: ");
                    friendFace.GetCurrentUser().RemoveFriend(CheckForFriendInDatabase(friendFace.GetAllUsers()));
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("3");
                    Console.WriteLine("View all your friends: ");
                    friendFace.GetCurrentUser().DisplayFriends();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("4");
                    Console.WriteLine("Choose a friend and view their profile: ");
                    friendFace.GetCurrentUser().ShowProfile(CheckForFriendInDatabase(friendFace.GetAllUsers()));
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("5");
                    Console.WriteLine("Settings");
                    Settings(friendFace);
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("6");
                    Console.WriteLine("Sign out");

                    SignOut(friendFace);
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("7");
                    friendFace.GetCurrentUser().ShowProfile(friendFace.GetCurrentUser());
                    Console.ReadLine();
                    break;

                case "8":
                    Console.Clear();
                    Console.WriteLine("8");
                    friendFace.friendHandler.ShowFriendRequests(friendFace);
                    break;
                case "9":
                    Console.Clear();
                    Console.WriteLine("9");
                    friendFace.Search.SearchForName();
                    break;
                case "10":
                    Console.Clear();
                    Console.WriteLine("10");
                    friendFace.PostHandler.DisplayPosts();
                    break;

                //----------------- FOR TESTING & DEBUGGING

                case "22":
                    Console.Clear();
                    Console.WriteLine("22");
                    Console.WriteLine($"CURRENT USER IS: {friendFace.GetCurrentUser().Name}");
                    Console.ReadLine();
                    break;

                case "23":
                    Console.Clear();
                    Console.WriteLine("23");
                    friendFace.ShowAllUsers();
                    break;

                case "24":
                    Console.Clear();
                    Console.WriteLine("24");
                    friendFace.friendHandler.ShowSentFriendRequests(friendFace);
                    break;
                    


                default:
                    break;
            }
        }
    }

    public void SignOut(FriendFace friendFace)
    {
        Console.WriteLine("Are you sure you want to log out?\n Type '1' for yes, '2' for no.");
        string yesOrNo = Console.ReadLine();
        while (yesOrNo != "1" || yesOrNo != "2")
        {
            if (yesOrNo == "1")
            {
                Console.WriteLine("Signing out now...");
                friendFace.CurrentProfile = null; //= new Profile("Error-user-Sign-out");
                friendFace.Login.login(friendFace);
                return;
            }
            if (yesOrNo == "2")
            {
                return;
            }
        }
    }

    public void Settings(FriendFace friendFace)
    {
        Console.WriteLine("Settings menu: ");
        Console.WriteLine("1. Change Name.");
        Console.WriteLine("2. Change Password.");
        Console.WriteLine("3. Change Username");
        Console.WriteLine("4. Change Description");
        Console.WriteLine("5. Change Profile picture");
        Console.WriteLine("6. Change Status");
        Console.WriteLine("10. EXIT.");
        Console.WriteLine();
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("1. Change Name.(first name)");
                Console.WriteLine("Works for first name only.");
                friendFace.ProfileHandler.ChangeFirstName(friendFace);
                break;
            case "2":
                Console.WriteLine("2. Change Password.");
                friendFace.passwordHandler.PasswordChange(friendFace);
                break;
            case "3":
                Console.WriteLine("3. Change Username");
                friendFace.ProfileHandler.ChangeUsername(friendFace);
                break;
            case "4":
                Console.WriteLine("4. Change Description");
                Console.WriteLine("does not work yet.");
                break;
            case "5":
                Console.WriteLine("5. Change Profile picture");
                Console.WriteLine("does not work yet.");
                break;
            case "6":
                Console.WriteLine("6. Change Status");
                Console.WriteLine("does not work yet.");
                friendFace.ProfileHandler.ChangeStatus(friendFace);
                break;
            case "10":
                Console.WriteLine("exit.");
                return;
                break;
            default:
                break;
        }
    }
    public Profile CheckForFriendInDatabase(List<Profile> allUserProfiles)
    {
        Profile ChosenFriend = null;
        while (ChosenFriend == null)
        {

            Console.WriteLine("Type in the name here: ");
            string friendName = Console.ReadLine();
            if (friendName.ToLower() == "x"){break;}
            bool wentThroughUsers = false;
            //if (wentThroughUsers)
            //{
            //    break;
            //}
            foreach (var profile in allUserProfiles)
            {
                //TODO: fix this. profile.Name??
                if (profile.Name.ToLower().Contains(friendName.ToLower()))
                {
                    Console.WriteLine($"Did you mean: {profile.Name}?");
                    Console.WriteLine($"1.YES \n2.NO");
                    string yesOrNO = Console.ReadLine();
                    if (yesOrNO == "1")
                    {
                        if (profile.Name.ToLower() == friendName.ToLower())
                        {
                            ChosenFriend = profile;
                            return ChosenFriend;
                        }
                    }
                    if (yesOrNO == "2")
                    {
                        continue;
                    }
                }
            }
            if (ChosenFriend == null)
            {
                friendName = "x";
                Console.WriteLine("Could not find user, try again...");
            }
            if (friendName.ToLower() == "x") { break; }
        }
        return ChosenFriend;
    }
}