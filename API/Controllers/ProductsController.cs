using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using API.Dtos;
using AutoMapper;
using API.Errors;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo = productsRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductToReturnDto>>> GetProducts()
        {
            var products = await _productsRepo.ListAllAsync();

            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {

            var product = await _productsRepo.GetByIdAsync(id);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<ProductToReturnDto>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}
