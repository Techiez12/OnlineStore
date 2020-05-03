using Microsoft.AspNetCore.Mvc;
using Ostore.DB.Models;
using System.Threading.Tasks;

namespace Ostore.API.Controllers
{
    public interface IOrderController
    {
        ValueTask<ActionResult<Order>> AddOrder(object leadInputModel);
        ValueTask<ActionResult<Order>> GetOrderById(int orderId);
    }
}