﻿namespace SosialMedia;

public class Menu
{
    public void MenuPrompt(Profile userProfile, List<Profile> allUserProfiles, FriendFace friendFace)
    {
        //Profile curUser = friendFace.GetCurrentUser();
        //List<Profile> allUsers = friendFace.GetAllUsers();

        while (true)
        {
            Console.WriteLine("\nWelcome to the main menu, here are your choices: ");
            Console.WriteLine("1. Add friend: ");
            Console.WriteLine("2. Remove friend: ");
            Console.WriteLine("3. View all your friends: ");
            Console.WriteLine("4. Choose a friend and view their profile: ");
            Console.WriteLine("5. Sign out: ");
            Console.WriteLine("----------");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("1");
                    Console.WriteLine("Add friend: ");
                    userProfile.AddFriend(CheckForFriendInDatabase(allUserProfiles),userProfile,friendFace);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("2");
                    Console.WriteLine("Remove friend: ");
                    userProfile.RemoveFriend(CheckForFriendInDatabase(allUserProfiles), userProfile);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("3");
                    Console.WriteLine("View all your friends: ");
                    userProfile.DisplayFriends();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("4");
                    Console.WriteLine("Choose a friend and view their profile: ");

                    userProfile.ShowProfile(CheckForFriendInDatabase(allUserProfiles));
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("5");
                    Console.WriteLine("Sign out");

                    SignOut(friendFace);
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
                friendFace.CurrentProfile = null;
                friendFace.Login.login(friendFace);
                return;
            }
            if (yesOrNo == "2")
            {
                return;
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