using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    public IActionResult Get(){
        Dictionary<string, string> d = new Dictionary<string, string>{
            {"test", "test1234"}
        };
        return Ok(d);
    }
}
