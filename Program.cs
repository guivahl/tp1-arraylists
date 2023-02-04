using GetPass;
using System.Collections;

string? options = "0";

while (options != "3")
{
    System.Console.WriteLine("Choose option:\n1. Create user\n2. Login\n3. Exit");

    options = System.Console.ReadLine();
    switch (options)
    {
        case "1":
            CreateUser();
            break;
        case "2":
            Login();
            break;
        default:
            options = "3";
            break;
    }
}

static void CreateUser()
{
    System.Console.Write("Username: ");
    string? username = System.Console.ReadLine();

    while (username == null)
    {
        System.Console.Write("Username invalid! Please try again: ");
        username = System.Console.ReadLine();
    }

    int MIN_PASSWORD_SIZE = 4;
    int MAX_PASSWORD_SIZE = 8;

    string password = ConsolePasswordReader.Read();

    while (!(password.Length >= MIN_PASSWORD_SIZE && password.Length <= MAX_PASSWORD_SIZE))
    {
        System.Console.Write("Password size invalid! Please try again: ");
        password = ConsolePasswordReader.Read();
    }

    User newUser = new User(username, password);

    User.users.Add(newUser);
}

static void Login()
{
    System.Console.Write("Username:");
    string? username = System.Console.ReadLine();

    while (username == null)
    {
        System.Console.Write("Username invalid! Please try again: ");
        username = System.Console.ReadLine();
    }

    string password = ConsolePasswordReader.Read();

    User? user = FindUserByUsername(username);

    if (user == null)
    {
        System.Console.WriteLine("User not found!");
        return;
    }

    if (user.Password != password)
    {
        System.Console.WriteLine("Wrong password!");
        return;
    }

    System.Console.WriteLine("Successful login!");
}

static User? FindUserByUsername(string username)
{
    foreach (User user in User.users)
    {
        if (user.Username == username)
            return user;
    }

    return null;
}


class User
{
    public static ArrayList users = new ArrayList() {
    new User("user", "password"),
    new User("username", "pass123")
};
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }
}