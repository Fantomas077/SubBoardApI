using System;
using System.Collections.Generic;
using System.Text;

namespace SubBoard.Application.Dtos.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
