using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
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
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();
        
        // Create security context
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Credential.Username),
            new Claim(ClaimTypes.Role, "User")
        };

        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
        var principal = new ClaimsPrincipal(identity);
        
        await HttpContext.SignInAsync("MyCookieAuth", principal);

        return RedirectToPage("/Index");
    }
}

public class Credential
{
    [Required]
    [Display(Name = "User Name")]
    [StringLength(30, MinimumLength = 3)]
    [RegularExpression(@"[\w]+")]
    public string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [StringLength(30, MinimumLength = 3)]
    public string Password { get; set; }
}