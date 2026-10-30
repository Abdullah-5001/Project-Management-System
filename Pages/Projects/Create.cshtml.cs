using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Software_Modelling_Technologies.Data;
using Software_Modelling_Technologies.Models;

namespace Software_Modelling_Technologies.Pages.Projects;

public class CreateModel(ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public Project Project { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        Project.CreatedAt = Project.UpdatedAt = DateTime.UtcNow;
        context.Projects.Add(Project);
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
