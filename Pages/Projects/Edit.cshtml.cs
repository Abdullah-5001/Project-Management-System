using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Software_Modelling_Technologies.Data;
using Software_Modelling_Technologies.Models;

namespace Software_Modelling_Technologies.Pages.Projects;

public class EditModel(ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public Project Project { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var project = await context.Projects.FindAsync(id);
        if (project is null)
            return NotFound();

        Project = project;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var existingProject = await context.Projects.FindAsync(Project.Id);
        if (existingProject is null)
            return NotFound();

        existingProject.Title = Project.Title;
        existingProject.Author = Project.Author;
        existingProject.Description = Project.Description;
        existingProject.TechnologyStack = Project.TechnologyStack;
        existingProject.Status = Project.Status;
        existingProject.StartDate = Project.StartDate;
        existingProject.EndDate = Project.EndDate;
        existingProject.RepositoryUrl = Project.RepositoryUrl;
        existingProject.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
