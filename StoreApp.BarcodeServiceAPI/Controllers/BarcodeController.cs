using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.BarcodeServiceAPI.DTOS;
using StoreApp.BarcodeServiceAPI.Repository.Abstract;

namespace StoreApp.BarcodeServiceAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BarcodeController : ControllerBase
{
    private readonly IBarcodeRepository _barcodeRepository;

    public BarcodeController(IBarcodeRepository barcodeRepository)
    {
        _barcodeRepository = barcodeRepository;
    }

    [HttpPost("AddBarcode")]
    public async Task<IActionResult> GetBarcode(ProductItemDTO dto)
    {
        var code = await _barcodeRepository.AddBarcodeAsync(dto);
        return Ok(new {Data = code});
    }
}
