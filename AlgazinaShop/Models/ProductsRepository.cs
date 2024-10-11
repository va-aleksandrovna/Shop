using AlgazinaShop.Data;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace AlgazinaShop.Models
{
    public class ProductsRepository
    {
        public List<ProductModel> GetList()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (AlgazinaShopContext bd = new AlgazinaShopContext())
            {
                products = bd.Products.Include(i => i.Category).Include(i => i.Brand).Select(List => new ProductModel()
                {
                    Id = List.Id,
                    Category = List.Category.Name,
                    Brend = List.Brand.Name,
                    Model = List.Model,
                    Price = List.Price,
                    Description = List.Description,
                    Image = List.Image,
                    CropFactor = List.CropFactor,
                    FullFrame = List.FullFrame,
                    Lens = List.Lens,
                    FocalLength = List.FocalLength,
                    TypeOfFocalLength = List.TypeOfFocalLength,
                    ViewingAngle = List.ViewingAngle,
                    DiagonalDisplay = List.DiagonalDisplay,
                    MaxNumberOfFrames = List.MaxNumberOfFrames,
                    WaterResistance = List.WaterResistance,
                    NumberOfMegapixels = List.NumberOfMegapixels,
                    Bayonet = List.Bayonet
                }).ToList();
            }
            return products;
        }

        public List<ProductModel> GetAll(string search = null, string sort = null, string category = null, string brend = null, 
            int minprice = 0, int maxprice = 2999999, float? cropfactor = 0, string fullframe = null, string lens = null,
            string bayonet = null, string type = null, int minfocus = 3, int maxfocus = 601, double minmp = 11, double maxmp = 62,
            double minangle = 0, double maxangle = 181, string water = null, double mindiagonal = 0, double maxdiagonal = 10,
            int frame = 0)
        {
            List<ProductModel> products = new List<ProductModel>();
            using (AlgazinaShopContext bd = new AlgazinaShopContext())
            {
                var productsQuery = bd.Products.Include(i => i.Category).Include(i => i.Brand).Select(List => new ProductModel()
                {
                    Id = List.Id,
                    Category = List.Category.Name,
                    Brend = List.Brand.Name,
                    Model = List.Model,
                    Price = List.Price,
                    Description = List.Description,
                    Image = List.Image,
                    CropFactor = List.CropFactor,
                    FullFrame = List.FullFrame,
                    Lens = List.Lens,
                    FocalLength = List.FocalLength,
                    TypeOfFocalLength = List.TypeOfFocalLength,
                    ViewingAngle = List.ViewingAngle,
                    DiagonalDisplay = List.DiagonalDisplay,
                    MaxNumberOfFrames = List.MaxNumberOfFrames,
                    WaterResistance = List.WaterResistance,
                    NumberOfMegapixels = List.NumberOfMegapixels,
                    Bayonet = List.Bayonet
                });

                if (!String.IsNullOrWhiteSpace(search))
                {
                    productsQuery = productsQuery.Where(s => s.Category.ToUpper().Contains(search.ToUpper())
                                           || s.Model.ToUpper().Contains(search.ToUpper()) || s.Brend.ToUpper().Contains(search.ToUpper()));
                }

                if (!String.IsNullOrWhiteSpace(sort))
                {
                    switch (sort)
                    {
                        case "name":
                            {
                                productsQuery = productsQuery.OrderBy(s => s.Brend).ThenBy(s => s.Model);
                                break;
                            }
                        case "namedesc":
                            {
                                productsQuery = productsQuery.OrderByDescending(s => s.Brend).ThenByDescending(s => s.Model);
                                break;
                            }
                        case "price":
                            {
                                productsQuery = productsQuery.OrderBy(s => s.Price);
                                break;
                            }
                        case "pricedesc":
                            {
                                productsQuery = productsQuery.OrderByDescending(s => s.Price);
                                break;
                            }
                    }
                }

                if (!String.IsNullOrWhiteSpace(category))
                {
                    switch (category)
                    {
                        case "photo":
                            {
                                productsQuery = productsQuery.Where(p => p.Category.Contains("Фотоаппарат"));
                                break;
                            }
                        case "obectiv":
                            {
                                productsQuery = productsQuery.Where(p => p.Category == "Объектив");
                                break;
                            }
                        case "action":
                            {
                                productsQuery = productsQuery.Where(p => p.Category == "Экшн-камера");
                                break;
                            }
                    }
                }

                if (!String.IsNullOrWhiteSpace(brend))
                {
                    productsQuery = productsQuery.Where(s => s.Brend == brend);
                }

                if (minprice!=100)
                {
                    productsQuery = productsQuery.Where(s => s.Price >= minprice);
                }

                if (maxprice != 2999999)
                {
                    productsQuery = productsQuery.Where(s => s.Price <= maxprice);
                }

                if (cropfactor!=0)
                {
                    productsQuery = productsQuery.Where(s => s.CropFactor == cropfactor);
                }

                if (!String.IsNullOrWhiteSpace(fullframe))
                {
                    productsQuery = productsQuery.Where(s => s.FullFrame == fullframe);
                }

                if (!String.IsNullOrWhiteSpace(lens))
                {
                    productsQuery = productsQuery.Where(s => s.Lens == lens);
                }

                if (!String.IsNullOrWhiteSpace(bayonet))
                {
                    productsQuery = productsQuery.Where(s => s.Bayonet == bayonet);
                }

                if (minmp != 11)
                {
                    productsQuery = productsQuery.Where(s => s.NumberOfMegapixels >= minmp);
                }

                if (maxmp != 62)
                {
                    productsQuery = productsQuery.Where(s => s.NumberOfMegapixels <= maxmp);
                }

                if (!String.IsNullOrWhiteSpace(type))
                {
                    productsQuery = productsQuery.Where(s => s.TypeOfFocalLength == type);
                }

                if (minfocus != 3)
                {
                    productsQuery = productsQuery.Where(s => s.FocalLength >= minfocus);
                }

                if (maxfocus != 601)
                {
                    productsQuery = productsQuery.Where(s => s.FocalLength <= maxfocus);
                }

                if (minangle != 0)
                {
                    productsQuery = productsQuery.Where(s => s.ViewingAngle >= minangle);
                }

                if (maxangle != 181)
                {
                    productsQuery = productsQuery.Where(s => s.ViewingAngle <= maxangle);
                }

                if (!String.IsNullOrWhiteSpace(water))
                {
                    productsQuery = productsQuery.Where(s => s.WaterResistance == water);
                }

                if (mindiagonal != 0)
                {
                    productsQuery = productsQuery.Where(s => s.DiagonalDisplay >= mindiagonal);
                }

                if (maxdiagonal != 10)
                {
                    productsQuery = productsQuery.Where(s => s.DiagonalDisplay <= maxdiagonal);
                }

                if (frame != 0)
                {
                    productsQuery = productsQuery.Where(s => s.MaxNumberOfFrames == frame);
                }

                products = productsQuery.ToList();
            }
            return products;
        }

        public ProductModel GetById(int id)
        {
            List<ProductModel> products = GetList();

            var product = products.Find(p => p.Id == id);
            return product;
        }

        //public List<string> GetBrend()
        //{
        //    List<ProductModel> products = GetList();

        //    return products.Select(item => item.Brend).Distinct().ToList();
        //}

        //public List<float?> GetCropfactor()
        //{
        //    List<ProductModel> products = GetList();

        //    return products.Select(item => item.CropFactor).Distinct().ToList();
        //}

        //public List<string> GetBayonet()
        //{
        //    List<ProductModel> products = GetList();

        //    return products.Select(item => item.Bayonet).Distinct().ToList();
        //}
    }
}
