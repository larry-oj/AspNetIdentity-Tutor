using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetIdentity_Tutor.Pages;

[Authorize]
public class Chat : PageModel
{
    public void OnGet()
    {
        
    }
}