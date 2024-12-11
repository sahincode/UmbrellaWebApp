using Umbrella.Web.Models.Catalog;

namespace Umbrella.Web.ViewModels
{
	public class HomeIndexViewModel
	{
		public List<ProductModel> Products { get; set; } = new();
	}
}
