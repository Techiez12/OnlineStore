using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ostore.API.Models.InputModels;
using Ostore.API.Models.OutputModels;

namespace Ostore.API.Controllers
{
    public interface IReportController
    {
        ValueTask<ActionResult<ProductInStoreOutputModel>> GetBestSellingProduct();
        ValueTask<ActionResult<CountProductInCategoryOutputModel>> GetCategoryWithFiveAndMoreProduct();
        ValueTask<ActionResult<OrderInfoOutputModel>> GetInfoAboutOrdersByDate(OrderDateInputModel model);
        ValueTask<ActionResult<List<MoneyInCityOutputModel>>> GetMoneyInEachCity();
        ValueTask<ActionResult<ProductInfoOutputModel>> GetNoOrderedProducts();
        ValueTask<ActionResult<List<ProductInStoreOutputModel>>> GetProductsInWarehouseAndAbsentInMoscowAndSpb();
        ValueTask<ActionResult<object>> GetSalesAmountInsideAndOutsideRF();
        ValueTask<ActionResult<ProductInfoOutputModel>> GetSoldOutProduct();
    }
}