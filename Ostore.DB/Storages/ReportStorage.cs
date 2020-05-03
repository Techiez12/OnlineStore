using Dapper;
using Microsoft.Extensions.Options;
using Ostore.Core.ConfigurationOptions;
using Ostore.DB.Models;
using Ostore.DB.Models.Reports;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ostore.DB.Storages
{
    public class ReportStorage : IReportStorage
    {
        private readonly IDbConnection connection;

        public ReportStorage(IOptions<StorageOptions> storageOptions)
        {
            connection = new SqlConnection(storageOptions.Value.DBConnectionString);
        }

        internal static class SpName
        {
            public const string GetMoneyInCity = "Report_GetMoneyInCity";
            public const string GetBestseller = "Report_GetBestseller";
            public const string GetProductStockOnly= "Report_GetProductStockOnly";
            public const string GetCategoryWithFiveAndMore = "Report_GetCategoryWithFiveAndMore";
            public const string GetMoneyForPeriod = "Report_GetMoneyForPeriod";
            public const string GetProductWithoutOrder = "Report_GetProductWithoutOrder";
            public const string GetMoneyInsideAndAbroad = "Report_GetMoneyInsideAndAbroad";
            public const string GetSoldOutProduct = "Report_GetSoldOutProduct";
        }

        public async ValueTask<List<MoneyInCity>> GetMoneyInCity()
        {
            try
            {
                var result = await connection.QueryAsync<MoneyInCity>(
                    SpName.GetMoneyInCity,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<ProductInStore>> GetBestseller()
        {
            try
            {
                var result = await connection.QueryAsync<City, Store, ProductInStore, ProductInStore>(
                    SpName.GetBestseller,
                    (city, store, bsproduct) =>
                    {
                        ProductInStore newProduct = bsproduct;
                        newProduct.Store = store;
                        store.City = city;
                        return newProduct;
                    },
                    null,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<OrderInfo>> GetMoneyForPeriod(DateOrder date)
        {
            try
            {
                var result = await connection.QueryAsync<City, Store, Product, OrderInfo, OrderInfo>(
                    SpName.GetMoneyForPeriod,
                    (city, store, product, orderinfo) =>
                    {
                        OrderInfo newOrderInfo = orderinfo;
                        orderinfo.Store = store;
                        store.City = city;
                        newOrderInfo.Product = product;
                        return newOrderInfo;
                    },
                    new { date.StartDate, date.EndDate },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<ProductInStore>> GetProductStockOnly()
        {
            try
            {
                var result = await connection.QueryAsync<ProductInStore, City, Store, ProductInStore>(
                    SpName.GetProductStockOnly,
                    (bsproduct, city, store) =>
                    {
                        ProductInStore newProduct = bsproduct;
                        newProduct.Store = store;
                        store.City = city;
                        return newProduct;
                    },
                    null,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<CountProductInCategory>> GetCategoryWithFiveAndMore()
        {
            try
            {
                var result = await connection.QueryAsync<CountProductInCategory>(
                    SpName.GetCategoryWithFiveAndMore,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetProductWithoutOrder()
        {
            try
            {
                var result = await connection.QueryAsync<Product>(
                    SpName.GetProductWithoutOrder,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public async ValueTask<List<Product>> GetSoldOutProduct()
        {
            try
            {
                var result = await connection.QueryAsync<Product>(
                    SpName.GetSoldOutProduct,
                    null,
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}
