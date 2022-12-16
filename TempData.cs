namespace SosialMedia;

public class TempData
{
    public List<string> AllUserNames { get; set; }
    protected List<Profile> AllUsers { get; set; } = new List<Profile>();
    public TempData(FriendFace friendFace)
    {
        AllUserNames = new List<string>();


        //AllUsers = new AddExampleUsers().Users;
        //AddAllUsersToTempDatabaseViaApi();
        //AddAllUserNames();
    }

    //public void UpdateUserData(Profile user)
    //{
    //    List<Profile> users = GetAllUsers();
    //    for (int i = 0; i < users.Count; i++)
    //    {
    //        if (user.Id == users[i].Id)
    //        {
    //            users.RemoveAt(i);
    //            users.Insert(i, user);
    //        }
    //    }
    //}
    public void AddAllUsersToTempDatabaseViaApi()
    {
        //something something
        //AllUsers = new AddExampleUsers().Users;
        //AllUsers = friendFace.ListOfAllUsers;
    }
    public List<Profile> GetAllUsers()
    {
        return AllUsers;
    }
    public void AddUserToDatabase(Profile profile)
    {
        AllUsers.Add(profile);
    }
    private void AddAllUserNames()
    {
        AllUserNames = new List<string>();
        foreach (var profile in AllUsers)
        {
            AllUserNames.Add(profile.GetName());
        }
    }

    public List<string> GetAllUserNames()
    {
        AddAllUserNames();
        return AllUserNames;
    }
}