using Ostore.DB.Models;
using System.Threading.Tasks;

namespace Ostore.Repository
{
    public interface IProductRepository
    {
        ValueTask<RequestResult<Product>> ProductDelete(int id);
        ValueTask<RequestResult<Product>> ProductGetById(int productId);
        ValueTask<RequestResult<Product>> ProductInsertOrUpdate(Product dataModel);
    }
}