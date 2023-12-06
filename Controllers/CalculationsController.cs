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

            //    "Was m�chten Sie machen?\n" + "1-Multiplikation\n"
            //+ "2-Addition\n" + "3-Division\n" + "4-Addition with numbers under each other\n" + "5-Subtraction\n"
            //+ "6-Division with rest\n" + "7-Subtraction with numbers under each other\n" + "8-Division with numbers under each other\n";

    [HttpPost]
    public void Post(int type)
    {
        PdfDocument document = new PdfDocument();
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont xFont = new XFont("Arial", 20);
        XFont headline = new XFont("Arial", 32);

        PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();
        //new Calc
        //type tells yoiu which sheet to create
        //create it
        //send it back to the user to download it
        switch (type)
        {
            case "Multiplication":
                primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);
            case "Addition":
                primarySchoolTasks.AdditionDocument(gfx, xFont, document, headline);
            case "Division":
                primarySchoolTasks.DivisonDocument(gfx, xFont, document, headline);
            case "Subtraction":
                primarySchoolTasks.SubtractionDocument(gfx, xFont, document, headline);
            case "Addition Under":
                primarySchoolTasks.AdditionUnderDocument(gfx, xFont, document, headline);
            case "Division with Rest":
                primarySchoolTasks.DivisionWithRestDocument(gfx, xFont, document, headline);
            case "Subtraction Under":
                primarySchoolTasks.SubtractionUnderDocument(gfx, xFont, document, headline);
            case "Division Under":
                primarySchoolTasks.DivisionUnderDocument(gfx, xFont, document, headline); 
      

        }
    }
}