namespace SosialMedia;

public class AddExampleUsers
{
    public List<Profile> Users { get; set; }

    public AddExampleUsers()
    {
        AddUsers();
    }
    public List<Profile> AddUsers()
    {
        Users = new List<Profile>();
        Users.Add(new Profile("Magnus Sandholmen")); // "Magnus Sandholmen"
        Users.Add(new Profile("Marie Askjem")); // "Marie Askjem"
        Users.Add(new Profile("FriendlessPerson Lastname")); // "FriendlessPerson FriendlessLastname"
        Users.Add(new Profile("Terje Kolderup")); // "Terje Kolderup"
        Users.Add(new Profile("Eskil Domben")); // "Eskil Domben"
        Users.Add(new Profile("Linn Østgaard")); // "Linn Østgaard"
        Users.Add(new Profile("Tommy Håvåg")); // "Tommy Håvåg"
        Users.Add(new Profile("Tom Stenstad")); // "Tom Stenstad"
        Users.Add(new Profile("Marius Henriksen")); // "Marius Henriksen"
        Users.Add(new Profile("Thorbjørn Berglund")); // "Thorbjørn Berglund"
        Users.Add(new Profile("Kristian Granaas")); // "Kristian1 Granaas"
        Users.Add(new Profile("Kristian Braathen")); // "Kristian2 Braathen"
        Users.Add(new Profile("Erik Vu")); // "Erik Vu"
        Users.Add(new Profile("Viktor Bastnes")); // "Viktor Bastnes"
        //Users.Add(new Profile("Magnus")); // "Magnus Sandholmen"
        //Users.Add(new Profile("Marie")); // "Marie Askjem"
        //Users.Add(new Profile("FriendlessPerson")); // "FriendlessPerson FriendlessPerson"
        //Users.Add(new Profile("Terje")); // "Terje Kolderup"
        //Users.Add(new Profile("Eskil")); // "Eskil Domben"
        //Users.Add(new Profile("Linn")); // "Linn Østgaard"
        //Users.Add(new Profile("Tommy")); // "Tommy Håvåg"
        //Users.Add(new Profile("Tom")); // "Tom Stenstad"
        //Users.Add(new Profile("Marius")); // "Marius Henriksen"
        //Users.Add(new Profile("Thorbjørn")); // "Thorbjørn Berglund"
        //Users.Add(new Profile("Kristian G")); // "Kristian1 Granaas"
        //Users.Add(new Profile("Kristian B")); // "Kristian2 Braathen"
        //Users.Add(new Profile("Erik")); // "Erik Vu"
        //Users.Add(new Profile("Viktor")); // "Viktor Bastnes"


        return Users;
    }
}