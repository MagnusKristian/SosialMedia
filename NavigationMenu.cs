namespace SosialMedia;

public class NavigationMenu
{
    public void Menu()
    {
        Console.WriteLine("Do something: ");
        ConsoleKeyInfo KeyPressed = Console.ReadKey();
        bool choiceMade = false;
        while (choiceMade == false)
        {
            if (KeyPressed.Key == ConsoleKey.UpArrow)
            {
                
            }
            if (KeyPressed.Key == ConsoleKey.DownArrow)
            {

            }
            KeyPressed = Console.ReadKey();
            if (KeyPressed.Key == ConsoleKey.Enter)
            {
                choiceMade = true;
            }
        }

    }
}