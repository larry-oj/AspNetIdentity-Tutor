using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetIdentity_Tutor.Pages;

[Authorize(Policy = "AdminOnly")]
public class AdminPage : PageModel
{
    public void OnGet()
    {
        
    }
}