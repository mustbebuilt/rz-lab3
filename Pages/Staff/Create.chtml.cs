using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rz.Data;
using rz.Models;

namespace rz.Pages.Staff;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    // 1. Inject ApplicationDbContext via Dependency Injection
    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    // 2. [BindProperty] binds form inputs from HTTP POST directly into this object
    [BindProperty]
    public Models.Staff Staff { get; set; } = new();

    // 3. HTTP GET: Serves the empty form view
    public IActionResult OnGet()
    {
        // Provide sensible defaults for new staff records
        Staff = new Models.Staff
        {
            StartDate = DateTime.Today.ToString("yyyy-MM-dd"),
            IsActive = 1
        };

        return Page();
    }

    // 4. HTTP POST: Handles form submission, validation, and database insertion
    public async Task<IActionResult> OnPostAsync()
    {
        // Guard against invalid submissions
        if (!ModelState.IsValid)
        {
            // Re-display form with user-entered values and validation errors
            return Page();
        }

        // Add the entity to the EF Core change tracker (EntityState.Added)
        _context.Staff.Add(Staff);

        // Commit transaction and execute SQL INSERT against SQLite
        await _context.SaveChangesAsync();

        // Follow the Post-Redirect-Get (PRG) pattern
        return RedirectToPage("/Staff/Index");
    }
}