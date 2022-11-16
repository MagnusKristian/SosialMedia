namespace SosialMedia;

public class AddExampleUsers
{
    public List<Profile> Users { get; set; }

    public List<Profile> AddUsers()
    {
        Users = new List<Profile>();
        Users.Add(new Profile("Magnus"));
        Users.Add(new Profile("Marie"));
        Users.Add(new Profile("Terje"));
        Users.Add(new Profile("Eskil"));
        Users.Add(new Profile("Linn"));
        Users.Add(new Profile("Tommy"));
        Users.Add(new Profile("Tom"));
        Users.Add(new Profile("Marius"));
        Users.Add(new Profile("Thorbjørn"));
        Users.Add(new Profile("Kristian G"));
        Users.Add(new Profile("Kristian B"));
        Users.Add(new Profile("Erik"));
        Users.Add(new Profile("Viktor"));
        return Users;
    }
}