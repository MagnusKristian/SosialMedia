﻿namespace SosialMedia;

public class TempData
{
    public List<string> AllUserNames { get; set; }
    protected List<Profile> AllUsers { get; set; }
    public TempData()
    {
        AllUserNames = new List<string>();

        //AllUsers = new AddExampleUsers().Users;
        AddAllUsersToTempDatabaseViaApi();
        AddAllUserNames();
    }

    public void AddAllUsersToTempDatabaseViaApi()
    {
        //something something
        AllUsers = new AddExampleUsers().Users;
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
        //AddAllUserNames();
        return AllUserNames;
    }
}