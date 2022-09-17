using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetIdentity_Tutor.Pages;

[Authorize]
public class UserPage : PageModel
{
    public void OnGet()
    {
        
    }
}