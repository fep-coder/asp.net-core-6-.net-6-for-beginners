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
        }
}
