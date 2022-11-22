namespace SosialMedia;

public class Search
{
    private FriendFace FriendFace { get; set; }

    public Search(FriendFace friendFace)
    {
        FriendFace = friendFace;
    }
    public void SearchForName()
    {
        List<string> UserNames = FriendFace.TempData.GetAllUserNames(FriendFace);
        //TEMPORARY FOR DEVELOPING SEARCH FUNCTIONALITY.
        string searchParameter = "";
        while (searchParameter != "x")
        {
            Console.WriteLine("Type 'x' to exit.");
            Console.WriteLine("Type in the name of the person you want to find: ");
            searchParameter = Console.ReadLine().ToLower();
            Console.Clear();
            if(searchParameter == "x"){return;}
            List<string> matches = new List<string>();
            foreach (string UserName in UserNames)
            {
                if (UserName.ToLower().Contains(searchParameter))
                {
                    matches.Add(UserName);
                }
            }
            Display(matches,searchParameter);
        }
        
        

            //return;//change. also get list of all users(objects) check if match and return the userOBJ.
            //maybe use string name to view in search menu?.
        
    }
    public void SearchForUserName()
    {

    }
    public void SearchForFirstName()
    {

    }
    public void SearchForLastName()
    {

    }

    public void Display(List<string> nameList,string searchParameter)
    {
        if (nameList.Count > 0)
        {
            Console.WriteLine();
            foreach (var name in nameList)
            {
                Console.WriteLine($"{name}");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"Could not find any match for {searchParameter}...");
        }
    }
}