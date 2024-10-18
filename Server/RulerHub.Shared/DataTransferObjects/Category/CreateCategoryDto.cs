using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulerHub.Shared.DataTransferObjects.Category;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "The name can't be empty")]
    [MinLength(3, ErrorMessage = "The category name must be under 18 and over 3 characters")]
    [MaxLength(18, ErrorMessage = "The category name must be under 18 and over 3 characters")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
