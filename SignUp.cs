namespace SosialMedia;

public class SignUp
{
    public string signUp()
    {
        Console.WriteLine("Welcome, new user, what is your name? ");
        string name = Console.ReadLine();
        //Console.WriteLine("Password? ");
        //string password = Console.ReadLine();
        return name;
    }
}