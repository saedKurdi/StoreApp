using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.SearchServiceAPI.DTOS;
using StoreApp.SearchServiceAPI.Repository.Abstract;
using StoreApp.SearchServiceAPI.Services.Abstract;

namespace StoreApp.SearchServiceAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchRepository _searchRepository;
    private readonly IProductService _productService;

    public SearchController(ISearchRepository searchRepository, IProductService productService)
    {
        _searchRepository = searchRepository;
        _productService = productService;
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        var item = await _searchRepository.GetAsync(code);
        if(item == null)
        {
            return NotFound();
        }
        var dto = new BarcodeDTO
        {
            Code = item.Code,
            ProductName = item.ProductName,
            TotalPrice = item.TotalPrice,
            Volume = item.Volume,
            Id = item.Id,
        };
        var productId = item.ProductId;
        dto.ImageUrl = await _productService.GetProductImagePathAsync(productId);
        return Ok(dto);
    }
}
