using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Software_Modelling_Technologies.Data;
using Software_Modelling_Technologies.Models;

namespace Software_Modelling_Technologies.Pages.Projects;

public class IndexModel(ApplicationDbContext context) : PageModel
{
    public IList<Project> Projects { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Projects = await context.Projects
            .AsNoTracking()
            .OrderByDescending(project => project.UpdatedAt)
            .ToListAsync();
    }
}
