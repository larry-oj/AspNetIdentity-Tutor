using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CookieOptions = AspNetIdentity_Tutor.Options.CookieOptions;

namespace AspNetIdentity_Tutor.Pages.Account;

public class Logout : PageModel
{
    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(CookieOptions.AuthCookieName);
        return RedirectToPage("/Index");
    }
}