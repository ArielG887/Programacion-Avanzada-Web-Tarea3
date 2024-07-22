using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APW.Web.ViewModels;

public class UserViewModel
{
    public string Username { get; set; }

    public string Email { get; set; }
    [BindNever]
    public string Password { get; set; } // This will not be bound from the request data

    public string Description { get; set; }

    public UserInfo User { get; set; }
}

[Bind("FirstName,LastName,Email")]
public class UserInfo
{
    public string Username { get; set; }
    public string Email { get; set; }
    [BindNever]
    public string Password { get; set; } // This will not be bound from the request data

    public string Description { get; set; }
}
