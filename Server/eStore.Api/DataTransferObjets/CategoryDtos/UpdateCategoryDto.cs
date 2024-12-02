﻿using eStore.Api.Entities;

namespace eStore.Api.DataTransferObjets.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
