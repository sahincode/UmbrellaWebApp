﻿using Umbrella.Web.Models.Catalog;

namespace Umbrella.Web.Services
{
	public interface ICatalogService
	{
		[Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
		Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 2);
		[Get("/catalog-service/products/{id}")]
		Task<GetProductByCategoryResponse>GetProductByCategory(Guid id);
		[Get("/catalog-service/products/category/{category}")]
		Task<GetProductByIdResponse> GetProductById(string category);
	}
}
