using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulerHub.Shared.DataTransferObjects.Category;
// Update category
public class UpdateCategoryDto
{
    [Required(ErrorMessage = "The name can't be empty")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
