namespace AlgazinaShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Brend { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set;}
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

        public ProductModel()
        {

        }    

        public ProductModel(int id, string category, string brend, string model, int price, string description, string image,
            float? cropfactor, string? fullframe, string? lens, int? focallength, string? type, int? viewingangle, float? diagonaldisplay,
            int? maxnumberofframes, string? waterresistance, float? numberofmegapixels, string? bayonet)
        {
            Id = id;
            Category = category;
            Brend = brend;
            Model = model;
            Price = price;
            Description = description;
            Image = image;
            CropFactor = cropfactor;  
            FullFrame = fullframe;
            Lens = lens;
            FocalLength = focallength;
            TypeOfFocalLength = type;
            ViewingAngle = viewingangle;
            DiagonalDisplay = diagonaldisplay;
            MaxNumberOfFrames = maxnumberofframes;
            WaterResistance = waterresistance;
            NumberOfMegapixels = numberofmegapixels;
            Bayonet = bayonet;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Категория: " + Category + " Бренд: " + Brend + " Модель: " + Model + " Цена: " + Price + " Описание: " + Description + " Изображение: " + Image;
        }
    }
}
