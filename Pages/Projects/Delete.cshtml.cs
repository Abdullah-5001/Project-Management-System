using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Software_Modelling_Technologies.Data;
using Software_Modelling_Technologies.Models;

namespace Software_Modelling_Technologies.Pages.Projects;

public class DeleteModel(ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public Project Project { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        if (project is null)
            return NotFound();

        Project = project;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var project = await context.Projects.FindAsync(Project.Id);
        if (project is null)
            return NotFound();

        context.Projects.Remove(project);
        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
