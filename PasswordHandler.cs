namespace SosialMedia;

public class PasswordHandler
{
    public bool passwordHandler(string password)
    {
        bool passwordIsGood = false;
        //bool passIsOk = false;
        bool passLengthOverEight = false;
        bool containsNumber = false;
        bool containsLetter = false;
        //bool containsSign = false; //-
        bool containsUpper = false;
        bool containsLower = false;
        //bool doesNotContainName = false; //-
        //bool differentFromPrevPass = false; //-
        if (password.Length < 8) { Console.WriteLine("Password does not contain 8 or more characters."); }
        if (password.Length >= 8) { passLengthOverEight = true; }
        foreach (var character in password)
        {
            if (char.IsDigit(character)) { containsNumber = true; }
            if (char.IsLetter(character)) { containsLetter = true; }
            //
            //if (char.IsSymbol(character)) { containsSign = true; }
            //
            if (char.IsUpper(character)) { containsUpper = true; }
            if (char.IsLower(character)) { containsLower = true; }
        }
        if (containsNumber == false) { Console.WriteLine("Password does not contain number"); }
        if (containsLetter == false) { Console.WriteLine("Password does not contain letter"); }
        //if (containsSign == false) { Console.WriteLine("Password does not contain sign"); }
        if (containsUpper == false) { Console.WriteLine("Password does not contain uppercase letter"); }
        if (containsLower == false) { Console.WriteLine("Password does not contain lowercase letter"); }
        //if (doesNotContainName == false) { Console.WriteLine("Password does not differ from name"); }
        //if (differentFromPrevPass == false) { Console.WriteLine("Password does not differ from previous password"); }
        if (
            passLengthOverEight &&
            containsNumber &&
            containsLetter &&
            /*containsSign &&*/
            containsUpper &&
            containsLower /*&&
            doesNotContainName &&*/
            /*differentFromPrevPass*/)
        {
            passwordIsGood = true;
        }
        //----------------------
        return passwordIsGood;
    }
    public void PasswordChange(FriendFace friendFace)
    {
        Console.WriteLine("Criteria for new password: \n " +
                          "8 characters or more in length\n" +
                          "1 or more number or sign\n" +
                          "1 or more letter character\n" +
                          "cannot be your name\n" +
                          "cannot be previous password");
        Console.WriteLine("\nType in your new password: ");
        string password = Console.ReadLine();
        if (password.Length <= 0) { return; }
        bool goodPass = false;
        while (goodPass == false)
        {
            goodPass = passwordHandler(password);
            if (goodPass == false)
            {
                Console.WriteLine("Try again dude.");
                password = Console.ReadLine();
            }
        }
        if (goodPass)
        {
            friendFace.GetCurrentUser().SetPassword(password);
            Console.WriteLine($"New password is: '{friendFace.GetCurrentUser().GetPassword()}'");
            return;
        }
    }
}