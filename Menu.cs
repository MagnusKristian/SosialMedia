namespace SosialMedia;

public class Menu
{
    public void MenuPrompt(Profile userProfile, List<Profile> allUserProfiles)
    {
        while (true)
        {
            Console.WriteLine("\nWelcome to the main menu, here are your choices: ");
            Console.WriteLine("1. Add friend: ");
            Console.WriteLine("2. Remove friend: ");
            Console.WriteLine("3. View all your friends: ");
            Console.WriteLine("4. Choose a friend and view their profile: ");
            Console.WriteLine("----------");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("1");
                    Console.WriteLine("Add friend: ");
                    userProfile.AddFriend(CheckForFriendInDatabase(allUserProfiles),userProfile);
                    break;
                case "2":
                    Console.WriteLine("2");
                    Console.WriteLine("Remove friend: ");
                    userProfile.RemoveFriend(CheckForFriendInDatabase(allUserProfiles), userProfile);
                    break;
                case "3":
                    Console.WriteLine("3");
                    Console.WriteLine("View all your friends: ");
                    userProfile.DisplayFriends();
                    break;
                case "4":
                    Console.WriteLine("4");
                    Console.WriteLine("Choose a friend and view their profile: ");

                    userProfile.ShowProfile(CheckForFriendInDatabase(allUserProfiles));
                    break;
                default:
                    break;
            }
        }
    }

    public Profile CheckForFriendInDatabase(List<Profile> allUserProfiles)
    {
        Profile ChosenFriend = null;
        while (ChosenFriend == null)
        {
            Console.WriteLine("Type in the name here: ");
            string friendName = Console.ReadLine();
            foreach (var profile in allUserProfiles)
            {
               if (profile.Name.ToLower() == friendName.ToLower())
               {
                   ChosenFriend = profile;
               }
            }
            if (ChosenFriend == null)
            {
                Console.WriteLine("Could not find user, try again...");
            }
        }

        //while (ChosenFriend == null)
        //{
        //    Console.WriteLine("Could not find user, try again...");
        //    friendName = Console.ReadLine();
        //    foreach (var profile in allUserProfiles)
        //    {
        //        if (profile.Name.ToLower() == friendName.ToLower())
        //        {
        //            ChosenFriend = profile;
        //        }
        //    }
        //}
        //userProfile.AddFriend(ChosenFriend);
        return ChosenFriend;
    }
}