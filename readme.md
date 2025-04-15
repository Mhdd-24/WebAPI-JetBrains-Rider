# User Management CRUD Application

A simple ASP.NET MVC Web Application for managing users with full CRUD (Create, Read, Update, Delete) operations.

## Project Overview

This project demonstrates how to create a user management system using ASP.NET MVC with file-based JSON storage instead of a traditional database. The application allows you to:

- View a list of all users
- View details of a specific user
- Create new users
- Edit existing users
- Delete users

## Features

- **Persistent Storage**: User data is stored in a JSON file, allowing data to persist between application restarts without requiring a database
- **Service Layer Pattern**: Uses a service layer to separate business logic from controllers
- **Bootstrap UI**: Professional styling using Bootstrap for a responsive, modern interface
- **Input Validation**: Form validation to ensure data integrity

## Technical Stack

- **Framework**: ASP.NET MVC (.NET 6+)
- **Frontend**: HTML, CSS, JavaScript, Bootstrap
- **Data Storage**: JSON file-based storage
- **Icon Library**: Font Awesome
- **Configuration**: ASP.NET Core Configuration system

## Project Structure

The application follows a standard MVC pattern with additional service layer:

- **Models/**: Contains the User model class
- **Views/**: Contains Razor views for all CRUD operations
- **Controllers/**: Contains the HomeController for handling HTTP requests
- **Services/**: Contains the service layer for data operations
- **App_Data/**: Storage location for the JSON data file

## Getting Started

### Prerequisites

- .NET 6 SDK or later
- Visual Studio 2022 or JetBrains Rider

### Installation

1. Clone this repository or download the source code
2. Open the solution file in Visual Studio or Rider
3. Restore NuGet packages
4. Build the solution
5. Run the application

## Configuration

The application uses the following configuration in `appsettings.json`:

```json
{
  "UserStorage": {
    "FilePath": "user.json"
  }
}
```

This specifies the filename for storing user data. The file will be created in the `App_Data` folder when the application runs.

## Code Examples

### User Model

```csharp
public class User
{
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    
    [Required]
    [Display(Name = "Full Name")]
    public string Name { get; set; }
    
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Active Status")]
    public bool IsActive { get; set; }
}
```

### Service Interface

```csharp
public interface IUserService
{
    List<User> GetAllUsers();
    User GetUserById(int id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
}
```

### Controller Methods

```csharp
// GET: Home
public IActionResult Index()
{
    return View(_userService.GetAllUsers());
}

// POST: Home/Create
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(User user)
{
    if (ModelState.IsValid)
    {
        _userService.AddUser(user);
        return RedirectToAction(nameof(Index));
    }
    return View(user);
}
```

## Development Process

This application was created following these steps:

1. Created the base ASP.NET MVC project
2. Defined the User model with required properties and validation
3. Implemented a service layer for data operations
4. Created a JSON file-based implementation of the service
5. Built the HomeController with all necessary CRUD actions
6. Designed responsive views using Bootstrap
7. Added proper validation and error handling
8. Configured the application to use the JSON file storage

## Screenshots

(Screenshots would be included here in an actual README)

## Future Enhancements

Potential improvements for this project:

- User authentication and authorization
- Pagination for the user list
- Sorting and filtering capabilities
- Search functionality
- User profile images
- Role-based user management
- Export to CSV/Excel functionality
- Dark mode theme option

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Bootstrap for the responsive UI framework
- Font Awesome for the icon library
- ASP.NET Core team for the excellent web framework