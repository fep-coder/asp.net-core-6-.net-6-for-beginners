namespace Core.Models.ViewModels
{
        public class ProductViewModel
        {
                public Product Product { get; set; }
                public string Action { get; set; } = "Create";
                public bool ReadOnly { get; set; } = false;
                public string Theme { get; set; } = "primary";
                public bool ShowAction { get; set; } = true;
                public IEnumerable<Category> Categories { get; set; }
        }
}
