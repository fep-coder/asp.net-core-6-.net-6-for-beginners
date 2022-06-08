namespace Core.Models.ViewModels
{
        public static class ViewModelFactory
        {
                public static ProductViewModel Details(Product product)
                {
                        return new ProductViewModel
                        {
                                Product = product,
                                Action = "Details",
                                ReadOnly = true,
                                Theme = "info",
                                ShowAction = false,
                                Categories = new List<Category> { product.Category }
                        };
                }

                public static ProductViewModel Create(Product product, IEnumerable<Category> categories)
                {
                        return new ProductViewModel
                        {
                                Product = product,
                                Categories = categories
                        };
                }

                public static ProductViewModel Edit(Product product, IEnumerable<Category> categories)
                {
                        return new ProductViewModel
                        {
                                Product = product,
                                Categories = categories,
                                Theme = "warning",
                                Action = "Edit"
                        };
                }

                public static ProductViewModel Delete(Product product, IEnumerable<Category> categories)
                {
                        return new ProductViewModel
                        {
                                Product = product,
                                Categories = categories,
                                Theme = "danger",
                                Action = "Delete",
                                ReadOnly = true
                        };
                }
        }
}
