using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using rz.Data;
using rz.Models;

namespace rz.Pages.Staff;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Models.Staff Staff { get; set; } = default!;

    // 1. HTTP GET: Load record for confirmation display
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var staff = await _context.Staff.FindAsync(id);

        if (staff == null)
        {
            return NotFound();
        }

        Staff = staff;
        return Page();
    }

    // 2. HTTP POST: Execute deletion upon confirmed submission
    public async Task<IActionResult> OnPostAsync(int id)
    {
        // Locate the record in the database
        var staff = await _context.Staff.FindAsync(id);

        if (staff != null)
        {
            // Mark entity state as EntityState.Deleted
            _context.Staff.Remove(staff);

            // Execute SQL DELETE against SQLite
            await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Staff member '{staff.FirstName} {staff.LastName}' was permanently deleted.";
        }

        // Post-Redirect-Get back to the directory
        return RedirectToPage("/Staff/Index");
    }
}