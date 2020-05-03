using System.Collections.Generic;
using System.Threading.Tasks;
using Ostore.DB.Models;
using Ostore.DB.Models.Reports;

namespace Ostore.DB.Storages
{
    public interface IReportStorage
    {
        ValueTask<List<ProductInStore>> GetBestseller();
        ValueTask<List<CountProductInCategory>> GetCategoryWithFiveAndMore();
        ValueTask<List<OrderInfo>> GetMoneyForPeriod(DateOrder date);
        ValueTask<List<MoneyInCity>> GetMoneyInCity();
        ValueTask<List<Product>> GetProductWithoutOrder();
        ValueTask<List<ProductInStore>> GetProductStockOnly();
        ValueTask<List<Product>> GetSoldOutProduct();
    }
}