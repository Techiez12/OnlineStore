using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ostore.API.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreStorage _storeStorage;

        public StoreController(IStoreStorage storeStorage)
        {
            _storeStorage = storeStorage;
        }
    }
}
