namespace SosialMedia;

public class Search
{
    private FriendFace FriendFace { get; set; }

    public Search(FriendFace friendFace)
    {
        FriendFace = friendFace;
    }
    public void SearchForName(string searchUsername)
    {
        List<string> UserNames = FriendFace.TempData.GetAllUserNames();
        //TEMPORARY FOR DEVELOPING SEARCH FUNCTIONALITY.
        if (UserNames.Contains(searchUsername))
        {
            //return;//change. also get list of all users(objects) check if match and return the userOBJ. maybe use string name to view in search menu?.
        }
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
}