namespace ServerManagement.Models;

public static class UserRepository
{
    private static readonly List<User> _users;

    static UserRepository()
    {
        _users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@foo.com" },
            new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.s@foo.com" }
        };
    }

    public static IEnumerable<User> GetAll() => _users;

    public static User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public static void Add(User user)
    {
        user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(user);
    }

    public static void Update(User user, int userId)
    {
        User existingUser = GetById(userId) ?? throw new ArgumentException("User not found");

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
    }

    public static bool Delete(int id)
    {
        User user = GetById(id) ?? throw new ArgumentException("user not found!");
        _users.Remove(user);
        return true;
    }
}
