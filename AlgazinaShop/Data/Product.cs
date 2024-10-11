using System;
using System.Collections.Generic;

namespace AlgazinaShop.Data;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public int BrandId { get; set; }

    public string Model { get; set; } = null!;

    public int Price { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public float? CropFactor { get; set; }

    public string? FullFrame { get; set; }

    public string? Lens { get; set; }

    public int? FocalLength { get; set; }

    public string? TypeOfFocalLength { get; set; }

    public int? ViewingAngle { get; set; }

    public float? DiagonalDisplay { get; set; }

    public int? MaxNumberOfFrames { get; set; }

    public string? WaterResistance { get; set; }

    public float? NumberOfMegapixels { get; set; }

    public string? Bayonet { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
