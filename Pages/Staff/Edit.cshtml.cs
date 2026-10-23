using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using rz.Data;
using rz.Models;

namespace rz.Pages.Staff;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Models.Staff Staff { get; set; } = default!;

    // 1. HTTP GET: Load existing record by primary key route parameter
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

    // 2. HTTP POST: Apply validated changes to SQLite database
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Inform EF Core that this entity already exists and its values have changed
        _context.Attach(Staff).State = EntityState.Modified;

        try
        {
            // Execute SQL UPDATE against SQLite
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // Verify if the record was deleted by another user concurrently
            if (!_context.Staff.Any(e => e.StaffId == Staff.StaffId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        // Before: return RedirectToPage("/Staff/Details", new { id = Staff.StaffId });
TempData["SuccessMessage"] = $"Staff record for '{Staff.FirstName} {Staff.LastName}' was successfully updated.";
return RedirectToPage("/Staff/Index");

        // Redirect to the updated Details view using the primary key route parameter
        return RedirectToPage("/Staff/Details", new { id = Staff.StaffId });
    }
}