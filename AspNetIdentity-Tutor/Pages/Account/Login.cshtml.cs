using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetIdentity_Tutor.Pages.Account;

public class Login : PageModel
{
    [BindProperty]
    public Credential Credential { get; set; }
    
    public void OnGet()
    {
    }
    
    public void OnPost()
    {
        
    }
}

public class Credential
{
    [Required]
    [Display(Name = "User Name")]
    public string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}