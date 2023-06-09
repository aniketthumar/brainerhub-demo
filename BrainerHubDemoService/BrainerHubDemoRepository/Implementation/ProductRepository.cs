using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoService.BrainerHubDemoRepository.Interface;
using Connectedcow.Model.ResponseModel;
using BrainerHubDemoModel.DbEntities;
using BrainerHubDemoModel.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BrainerHubDemoModel.CustomModels;
using PagedList;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Implementation
{
    public class ProductRepository : IProductRepository
    {

        #region Initialization
        BrainerHubContex _brainerHubContex;

        public ProductRepository(BrainerHubContex brainerHubContex)
        {
            _brainerHubContex = brainerHubContex;
        }
        #endregion

        #region List
        public async Task<List<Product>> List(SearchRequestModel model)
        {
            List<Product> products = new List<Product>();

            if (!string.IsNullOrWhiteSpace(model.SearchText))
            {
                products = _brainerHubContex.Products.Where(s => s.Name.Contains(model.SearchText)
                               || s.Description.Contains(model.SearchText) || s.Price.Equals(model.SearchText) || s.Quantity.Equals(model.SearchText)).Include(x => x.ProductImages).ToPagedList(model.Page, model.PageSize).ToList();
            }
            else
            {
                products = _brainerHubContex.Products.Include(x => x.ProductImages).ToPagedList(model.Page, model.PageSize).ToList();
            }

            return products;
        }
        #endregion

        #region Create Product
        public async Task<ProductResponseModel> CreateProduct(ProductRequestModel model, List<string> fileName)
        {
            var product = await _brainerHubContex.Products.SingleOrDefaultAsync(x => x.Name == model.name);
            if (product != null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status401Unauthorized, "Product Already Exists.");
            }
            product = new Product();
            product.Name = model.name;
            product.Description = model.description;
            product.Price = model.price;
            product.Quantity = model.quantity;
            product.StatusId = 1;

            if (fileName != null && fileName.Count > 0)
            {
                List<ProductImage> productImages = new List<ProductImage>();
                foreach (var item in fileName)
                {
                    ProductImage images = new ProductImage();

                    images.ImageUrl = item;
                    images.StatusId = 1;
                    productImages.Add(images);
                }
                product.ProductImages = productImages;
            }

            await _brainerHubContex.Products.AddAsync(product);
            await _brainerHubContex.SaveChangesAsync();

            return new ProductResponseModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                quantity = product.Quantity,
                price = product.Price,
            };
        }
        #endregion

        #region Update Product
        public async Task<ProductResponseModel> UpdateProduct(ProductUpdateRequestModel model, int productId, List<string> fileName)
        {
            var product = await _brainerHubContex.Products.SingleOrDefaultAsync(x => x.Name == model.name && x.ProductId != productId);
            if (product != null)
            {
                throw new HttpStatusCodeException(StatusCodes.Status401Unauthorized, "Product Already Exists.");
            }

            
            product = await _brainerHubContex.Products.SingleOrDefaultAsync(x => x.ProductId == productId);
            product.Name = model.name;
            product.Description = model.description;
            product.Price = model.price;
            product.Quantity = model.quantity;
            product.StatusId = 1;

            if (fileName != null && fileName.Count > 0)
            {
                List<ProductImage> productImages = new List<ProductImage>();
                foreach (var item in fileName)
                {
                    ProductImage images = new ProductImage();
                    images.ProductsId = productId;
                    images.ImageUrl = item;
                    images.StatusId = 1;
                    productImages.Add(images);
                }

                await _brainerHubContex.ProductImages.AddRangeAsync(productImages);
            }
            _brainerHubContex.Products.Update(product);
            if (model.DeleteImageId != null && model.DeleteImageId.Count > 0)
            {
                List<ProductImage> productImages = _brainerHubContex.ProductImages.Where(x => model.DeleteImageId.Contains(x.ProductImageId)).ToList();
                if (productImages != null && productImages.Count > 0)
                {
                    _brainerHubContex.ProductImages.RemoveRange(productImages);
                }
            }
            await _brainerHubContex.SaveChangesAsync();

            return new ProductResponseModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                quantity = product.Quantity,
                price = product.Price,
            };
        }
        #endregion

        #region Delete
        public async Task Delete(int productId)
        {
            var product = await _brainerHubContex.Products.SingleOrDefaultAsync(x => x.ProductId != productId);

            if (product != null)
            {
                _brainerHubContex.Products.RemoveRange(product);
            }
        }
        #endregion
    }
}
