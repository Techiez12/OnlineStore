﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ostore.API.Models.InputModels;
using Ostore.API.Models.OutputModels;
using Ostore.DB.Models;
using Ostore.Repository;

namespace Ostore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet("{productId}")]
        public async ValueTask<ActionResult<ProductOutputModel>> GetProductById(int productId)
        {
            if (productId < 1) return BadRequest("ProductId can not be less than one.");
            var result = await _productRepository.ProductGetById(productId);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Product not found"); }
                return Ok(_mapper.Map<ProductOutputModel>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);

        }

        [HttpPost]
        public async ValueTask<ActionResult<ProductOutputModel>> InsertOrUpdateProduct(ProductInputModel productInputModel)
        {
            if (productInputModel.Id < 1) return BadRequest("ProductId can not be less than one.");
            var result = await _productRepository.ProductInsertOrUpdate(_mapper.Map<Product>(productInputModel));
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return Problem($"Added lead not found", statusCode: 520); }
                return Ok(_mapper.Map<ProductOutputModel>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        [HttpDelete("{orderId}")]
        public async ValueTask<ActionResult<Order>> DeleteProduct(int productId)
        {
            if (productId < 1) return BadRequest("ProductId can not be less than one.");
            var result = await _productRepository.ProductDelete(productId);
            if (result.IsOkay) { return Ok(); }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }
    }
}
