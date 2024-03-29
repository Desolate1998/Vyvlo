﻿namespace Domain.Common.ProductCategories;

public class CategoriesWithStats
{
    public long ProductCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int TotalStock { get; set; }
    public int TotalProducts { get; set; }
}
