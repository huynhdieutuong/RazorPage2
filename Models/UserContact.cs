using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

public class UserContact
{
    // [BindProperty] - Default binding in POST
    // [BindProperty(SupportsGet = true)] - Support binding in GET
    // /privacy.html?UserId=abc&Email=tuong@gmail.com&UserName=Tuong
    [BindProperty]
    [DisplayName("Your Id")]
    public string UserId { get; set; }
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string UserName { get; set; }
}