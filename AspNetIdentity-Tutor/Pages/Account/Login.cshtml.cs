using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CookieOptions = AspNetIdentity_Tutor.Options.CookieOptions;

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
        var role = Credential.Username == "admin" ? "Admin" : "User";
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Credential.Username),
            new Claim(ClaimTypes.Role, role)
        };

        var identity = new ClaimsIdentity(claims, CookieOptions.AuthCookieName);
        var principal = new ClaimsPrincipal(identity);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = Credential.RememberMe
        };
        
        await HttpContext.SignInAsync(CookieOptions.AuthCookieName, principal, authProperties);

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
    
    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }
}