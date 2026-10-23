using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages;

public class IndexModel : PageModel
{
    public string LabTitle { get; set; } = "Lab 3: CRUD Operations in Razor Pages";
    public string ModuleName { get; set; } = "Web Application Development";

    public void OnGet()
    {
        // Executes when user navigates to / or /Index
    }
}
