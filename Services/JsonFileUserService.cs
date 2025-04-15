// Services/JsonFileUserService.cs
using Newtonsoft.Json;
using VibeCodeUserMgmtCRUD.Models;

namespace VibeCodeUserMgmtCRUD.Services
{
    public class JsonFileUserService : IUserService
    {
        private readonly string _dataFilePath;
        private List<User> _users;

        public JsonFileUserService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            var fileName = configuration.GetValue<string>("UserStorage:FilePath") ?? "users.json";
            _dataFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "App_Data", fileName);
            
            // Create directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(_dataFilePath));
            
            // Load users from file
            _users = LoadUsersFromFile();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            // Generate a new ID
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            SaveUsersToFile();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.IsActive = user.IsActive;
                SaveUsersToFile();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                SaveUsersToFile();
            }
        }

        private List<User> LoadUsersFromFile()
        {
            if (File.Exists(_dataFilePath))
            {
                var json = File.ReadAllText(_dataFilePath);
                return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            return new List<User>();
        }

        private void SaveUsersToFile()
        {
            var json = JsonConvert.SerializeObject(_users, Formatting.Indented);
            File.WriteAllText(_dataFilePath, json);
        }
    }
}