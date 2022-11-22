namespace SosialMedia;

public class TempData
{
    public List<string> AllUserNames { get; set; }
    public List<Profile> AllUsers { get; set; }
    public TempData()
    {
        AllUserNames = new List<string>();
        AllUsers = new List<Profile>();
    }

    public void AddAllUserNames(FriendFace friendFace)
    {
        AllUserNames = new List<string>();
        foreach (var profile in friendFace.GetAllUsers())
        {
            AllUserNames.Add(profile.GetUserName());
        }
    }

    public List<string> GetAllUserNames(FriendFace friendFace)
    {
        AddAllUserNames(friendFace);
        return AllUserNames;
    }
}