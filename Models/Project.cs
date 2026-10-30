using System.ComponentModel.DataAnnotations;

namespace Software_Modelling_Technologies.Models;

public class Project
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    [Display(Name = "Project title")]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required, StringLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Required, StringLength(300)]
    [Display(Name = "Technology stack")]
    public string TechnologyStack { get; set; } = string.Empty;

    [StringLength(50)]
    public string Status { get; set; } = "Planned";

    [DataType(DataType.Date)]
    [Display(Name = "Start date")]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "End date")]
    public DateTime? EndDate { get; set; }

    [StringLength(500)]
    [Display(Name = "Repository URL")]
    [Url]
    public string? RepositoryUrl { get; set; }

    [Display(Name = "Created on")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Last updated")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
