using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.LogService.Services.Abstract;

namespace StoreApp.LogService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LogController : ControllerBase
{
    private readonly ILogService _logService;

    public LogController(ILogService logService)
    {
        _logService = logService;
    }

    [HttpGet("{message}")]
    public  IActionResult Log(string message)
    {
        _logService.LogInfoToTxtFile(message);
        return Ok(message);
    }
}
