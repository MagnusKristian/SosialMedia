namespace SosialMedia;

public class TempData
{
    public List<string> AllUserNames { get; set; }

    public TempData()
    {
        
    }

    public void AddAllUserNames(FriendFace friendFace)
    {
        foreach (var profile in friendFace.GetAllUsers())
        {
            AllUserNames.Add(profile.GetUserName());
        }
        
    }

    public List<string> GetAllUserNames()
    {
        return AllUserNames;
    }
}