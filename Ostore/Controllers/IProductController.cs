using Microsoft.AspNetCore.Mvc;
using Ostore.API.Models.InputModels;
using Ostore.API.Models.OutputModels;
using Ostore.DB.Models;
using System.Threading.Tasks;

namespace Ostore.API.Controllers
{
    public interface IProductController
    {
        ValueTask<ActionResult<Order>> DeleteProduct(int productId);
        ValueTask<ActionResult<ProductOutputModel>> GetProductById(int productId);
        ValueTask<ActionResult<ProductOutputModel>> InsertOrUpdateProduct(ProductInputModel productInputModel);
    }
}