using Ostore.DB.Models;
using Ostore.DB.Models.Reports;
using Ostore.DB.Storages;
using Ostore.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ostore
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportStorage _reportStorage;

        public ReportRepository(IReportStorage reportStorage)
        {
            _reportStorage = reportStorage;
        }

        public async ValueTask<RequestResult<List<MoneyInCity>>> GetMoneyInCity()
        {
            var result = new RequestResult<List<MoneyInCity>>();
            try
            {
                result.RequestData = await _reportStorage.GetMoneyInCity();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<ProductInStore>>> GetBestseller()
        {
            var result = new RequestResult<List<ProductInStore>>();
            try
            {
                result.RequestData = await _reportStorage.GetBestseller();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<ProductInStore>>> GetProductStockOnly()
        {
            var result = new RequestResult<List<ProductInStore>>();
            try
            {
                result.RequestData = await _reportStorage.GetProductStockOnly();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<CountProductInCategory>>> GetCategoryWithFiveAndMore()
        {
            var result = new RequestResult<List<CountProductInCategory>>();
            try
            {
                result.RequestData = await _reportStorage.GetCategoryWithFiveAndMore();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<OrderInfo>>> GetMoneyForPeriod(DateOrder date)
        {
            var result = new RequestResult<List<OrderInfo>>();
            try
            {
                result.RequestData = await _reportStorage.GetMoneyForPeriod(date);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetProductWithoutOrder()
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _reportStorage.GetProductWithoutOrder();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Product>>> GetSoldOutProduct()
        {
            var result = new RequestResult<List<Product>>();
            try
            {
                result.RequestData = await _reportStorage.GetSoldOutProduct();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
    }
}
