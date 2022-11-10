namespace SosialMedia;

public class Login
{
    public void login(FriendFace friendFace)
    {
        Console.WriteLine("Welcome to FriendFace!");
        Console.WriteLine("Type '1' to sign in:");
        Console.WriteLine("Type '2' to sign up:");
        string logInChoice = Console.ReadLine();
        if (logInChoice == "1")
        {
            friendFace.WelcomePrompt();
        }
        if (logInChoice == "2")
        {
            
        }
    }

   
}