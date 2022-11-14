namespace SosialMedia;

public class SignUp
{
    public Profile signUp(FriendFace friendFace)
    {
        Console.WriteLine("Welcome, new user, what is your name? ");
        string userName = Console.ReadLine();
        bool duplicate = CheckForDuplicateUser(friendFace,userName);
        while (duplicate== true)
        {
            Console.WriteLine("Try again: ");
            userName = Console.ReadLine();
            duplicate = CheckForDuplicateUser(friendFace,userName);
        }
        Profile newProfile = new Profile(userName);

        //newProfile.SetPassword();

        //Console.WriteLine("Password? ");
        //string password = Console.ReadLine();
        return newProfile;
    }

    public bool CheckForDuplicateUser(FriendFace friendFace,string userName)
    {
        //List<string> usernames = new List<string>();
        //foreach (var user in friendFace.ListOfAllUsers)
        //{
        //    usernames.Add(user.Name);
        //}
        bool userNameWasTaken = false;
        foreach (var name in friendFace.GetAllUsers())
        {
            if (name.Name.ToLower() == userName.ToLower())
            {
                Console.WriteLine("username taken dude");
                userNameWasTaken = true;
            }
        }
        return userNameWasTaken;


        //bool userNameIsNoGood = true;
        //while (userNameIsNoGood)
        //{
        //    for (int i = 0; i < friendFace.GetAllUsers().Count; i++)
        //    {
        //        if (friendFace.GetAllUsers()[i].UserName == userName)
        //        {
        //            Console.WriteLine($"{friendFace.GetAllUsers()[i].UserName} is taken, try something else.");
        //        }
        //    }
        //    //foreach (var person in friendFace.GetAllUsers())
        //    //{
        //    //    Console.WriteLine($"{person.Name}");
        //    //    if (person.Name.ToLower() == userName.ToLower())
        //    //    {
        //    //        Console.WriteLine($"{person.Name} taken, try something else.");
        //    //    }

        //    //    //if (expr)
        //    //    //{

        //    //    //}
        //    //}
        //    Console.WriteLine("Good name, signing up now.");
        //}
    }
}