using System.Collections.Generic;
using System.Threading.Tasks;
using Ostore.DB.Models;
using Ostore.DB.Models.Reports;
using Ostore.Repository;

namespace Ostore
{
    public interface IReportRepository
    {
        ValueTask<RequestResult<List<ProductInStore>>> GetBestseller();
        ValueTask<RequestResult<List<CountProductInCategory>>> GetCategoryWithFiveAndMore();
        ValueTask<RequestResult<List<OrderInfo>>> GetMoneyForPeriod(DateOrder date);
        ValueTask<RequestResult<List<MoneyInCity>>> GetMoneyInCity();
        ValueTask<RequestResult<List<Product>>> GetProductWithoutOrder();
        ValueTask<RequestResult<List<ProductInStore>>> GetProductStockOnly();
        ValueTask<RequestResult<List<Product>>> GetSoldOutProduct();
    }
}