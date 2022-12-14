namespace SosialMedia;

public class ProfileHandler
{
    public void ChangeUsername(FriendFace friendFace)
    {
        Console.WriteLine("Work in progress...");
        Console.WriteLine("Does not work yet.");

        string oldUserName = friendFace.GetCurrentUser().GetUserName();
        string newUsername = "";
        bool acceptableChange = false;
        while (acceptableChange == false)
        {
            Console.WriteLine($"Your username is: '{friendFace.GetCurrentUser().GetUserName()}', Type in your new name: ");
            newUsername = Console.ReadLine();
            bool usernameTaken = CheckForDuplicateUser(friendFace, newUsername);
            if (usernameTaken == false)
            {
                acceptableChange = true;
            }
        }

        if (acceptableChange == true)
        {
            friendFace.GetCurrentUser().SetUserName(newUsername);
            Console.WriteLine($"Your username was changed to: '{newUsername}' from '{oldUserName}'");
        }
    }
    public void ChangeFirstName(FriendFace friendFace)
    {
        Console.WriteLine($"Hello '{friendFace.GetCurrentUser().GetFirstName()}'");
        Console.WriteLine("What would you like to change your first name to? : ");
        string oldName = friendFace.GetCurrentUser().GetFirstName();
        string newFirstName = Console.ReadLine();
        bool accepted = false;
        while (accepted == false) 
        {
            Console.WriteLine($"type '1' to accept '{newFirstName}' as your new first name.");
            Console.WriteLine($"type '2' to decline.");
            string acceptOrDecline = Console.ReadLine();
            if (acceptOrDecline == "1")
            {
                accepted = true;
            }
            if (acceptOrDecline == "2")
            {
                Console.WriteLine("Aborted successfully.");
                return;
            }
        }
        friendFace.GetCurrentUser().SetFirstName(newFirstName);
        Console.WriteLine($"Name changed successfully from '{oldName}' to '{friendFace.GetCurrentUser().GetFirstName()}'");
        
    }
    public void ChangeLastName(FriendFace friendFace)
    {
        //user.SetFirstName(newName);
        Console.WriteLine("Does not work yet.");
        string newLastName = ChangeHelper("last name");
        friendFace.GetCurrentUser().SetLastName(newLastName);
        Console.WriteLine($"{"Last name"} changed to: {friendFace.GetCurrentUser().GetLastName()}");

    }
    public void ChangeStatus(FriendFace friendFace)
    {
        //Console.WriteLine($"What do you want your new status to be?");
        string newStatus = ChangeHelper("status");
        friendFace.GetCurrentUser().SetStatus(newStatus);
        Console.WriteLine($"{"Status"} changed to: {friendFace.GetCurrentUser().GetStatus()}");

    }

    public string ChangeHelper(string thingToChange)
    {
        Console.WriteLine($"What do you want your new {thingToChange} to be?");
        string newThingChanged = Console.ReadLine();
        if (newThingChanged.ToLower() == "x")
        {
            Console.WriteLine($"Exited, {thingToChange} was not updated.");
            return null;
        }

        return newThingChanged;
    }
    public void ChangeDescription(FriendFace friendFace, string newDescription)
    {
        friendFace.GetCurrentUser().SetDescription(newDescription);
        Console.WriteLine($"Description changed to: {friendFace.GetCurrentUser().GetDescription()}");

    }
    public void ChangeProfilePicture(Profile user, string newImgURL)
    {
        //user.SetFirstName(newNnewImgURLame);
        Console.WriteLine("Does not work yet.");

    }
    public bool CheckForDuplicateUser(FriendFace friendFace, string userName)
    {
        bool userNameWasTaken = false;
        foreach (var profile in friendFace.GetAllUsers())
        {
            if (profile.Name.ToLower() == userName.ToLower())
            {
                Console.WriteLine("username taken dude, Try again!");
                userNameWasTaken = true;
                //TODO: THIS IS SET UP WRONG, REMEMBER WHEN YOU GET BACK FROM POMODORO BREAK.
            }
        }
        return userNameWasTaken;
    }


    //public void UpdateProperty(string thingToUpdate)
    //{
    //    string nameOfThingToUpdate = thingToUpdate;
    //    if(thingToUpdate == null){}
    //    if(thingToUpdate == "name"){}

    //    switch (thingToUpdate)
    //    {
    //        case "name": 
    //            break;
    //        case "password":
    //            break;
    //        default:
    //            break;
    //    }

    //    Console.WriteLine($"Successfully updated '{thingToUpdate}' to: ''.");
    //}
}