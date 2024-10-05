using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.ProductService.DTOS;
using StoreApp.ProductService.Entities;
using StoreApp.ProductService.Repository.Abstract;
using StoreApp.ProductService.Services.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreApp.ProductService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductExtensionService _extensionService;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductController(IProductExtensionService extensionService, IProductRepository productRepository, IMapper mapper)
    {
        _extensionService = extensionService;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    // GET: api/<ProductController>
    [HttpGet]
    public  async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var result = await _productRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<ProductDTO>>(result);
        return dtos;
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<ProductDTO> Post([FromBody] ProductDTO productDTO)
    {
        var item = _mapper.Map<Product>(productDTO);
        await _productRepository.AddProductAsync(item);
        var dto = _mapper.Map<ProductDTO>(item);
        return dto;
    }

    [HttpGet("Image/{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
        var result = await _extensionService.GetProductImageAsync(id);
        return Ok(result);
    }

}
