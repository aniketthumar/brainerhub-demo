using BrainerHubDemoModel.CustomModels;
using BrainerHubDemoModel.DbEntities;
using BrainerHubDemoModel.RequestModel;
using BrainerHubDemoModel.ResponseModel;
using Connectedcow.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainerHubDemoService.BrainerHubDemoRepository.Interface
{
    public interface IProductRepository
    {
        Task<ProductResponseModel> CreateProduct(ProductRequestModel model, List<string> fileName);

        Task<ProductResponseModel> UpdateProduct(ProductUpdateRequestModel model,int productId, List<string> fileName);

        Task<List<Product>> List(SearchRequestModel model);

        Task Delete(int productId);

    }
}
