using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.ImageServiceAPI.DTOS;
using StoreApp.ImageServiceAPI.Services.Abstractl;

namespace StoreApp.ImageServiceAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IPhotoService _photoService;

    public ImageController(IPhotoService photoService)
    {
        _photoService = photoService;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var file = Request.Form.Files.GetFile("file");
        if (file != null && file.Length > 0)
        {
            string result = await _photoService.UploadImageAsync(new PhotoCreationDTO { FormFile = file});
            return Ok(result);
        }
        return BadRequest();
    }
}
