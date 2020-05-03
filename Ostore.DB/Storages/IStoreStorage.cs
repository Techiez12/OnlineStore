using Ostore.DB.Models;
using System.Threading.Tasks;

namespace Ostore.DB.Storages
{
    public interface IStoreStorage
    {
        ValueTask<City> CityInsert(City model);
    }
}