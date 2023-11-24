using System.Data.SqlTypes;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculationController : ControllerBase
{
    private readonly ILogger<CalculationController> _logger;

    public CalculationController(ILogger<CalculationController> logger)
    {
        _logger = logger;
    }


    [HttpPost]
    public void Post(int type)
    {
       //new Calc
       //type tells yoiu which sheet to create
       //create it
       //send it back to the user to download it
       switch (type)
        {
            
        }
    }
}
