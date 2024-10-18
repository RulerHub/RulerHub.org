using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulerHub.Shared.DataTransferObjects.Item;

public class CreateItemDto
{
    [Required(ErrorMessage = "This camp is necessary")]
    public string Code { get; set; } = string.Empty;
    [Required(ErrorMessage = "This camp is necessary")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "This camp is necessary")]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "This camp is necessary")]
    public decimal Price { get; set; }
}
