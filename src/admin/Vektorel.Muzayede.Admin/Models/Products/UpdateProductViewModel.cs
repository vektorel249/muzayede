﻿namespace Vektorel.Muzayede.Admin.Models.Products;

public class UpdateProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid? BoardId { get; set; }
}