using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SubBoard.Application.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
