using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace MathMaster.Controllers;

[Route("[controller]")]
public class CalculationController : ControllerBase 
{

    private readonly ILogger<CalculationController> _logger;

    public CalculationController(ILogger<CalculationController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get(string type)
    {
        PrimarySchoolTasks primarySchoolTasks_WithQuestPDF = new PrimarySchoolTasks(type);
        //MemoryStream generates the file only in the RAM
        MemoryStream stream = primarySchoolTasks_WithQuestPDF.GenerateToMemoryStream();
        //set the Stream to the start
        stream.Seek(0, SeekOrigin.Begin);
        //returns the stream and tells the frontend the type of the file is pdf and the name is calculations.pdf
        return File(stream, "application/pdf", "calculations.pdf");
    }
}