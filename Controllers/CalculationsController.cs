using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Net;
using PdfSharp.Fonts;
     
namespace MathMaster.Controllers;

[Route("[controller]")]
public class CalculationController : ControllerBase 
{

    private readonly ILogger<CalculationController> _logger;

    public CalculationController(ILogger<CalculationController> logger)
    {
        _logger = logger;
    }


    //    "Was möchten Sie machen?\n" + "1-Multiplikation\n"
    //+ "2-Addition\n" + "3-Division\n" + "4-Addition with numbers under each other\n" + "5-Subtraction\n"
    //+ "6-Division with rest\n" + "7-Subtraction with numbers under each other\n" + "8-Division with numbers under each other\n";


    [HttpGet] //
    public IActionResult Get(string type)
    {
        PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();

        XFont xFont;
        XFont headline;
        PdfDocument document = new PdfDocument();
        PdfPage page = new PdfPage(document);
        XGraphics gfx = XGraphics.FromPdfPage(page);

        using (gfx)
        {
            // Create an XFont object for Arial font with size 12
            xFont = new XFont("Arial", 20);
            headline = new XFont("Arial", 32);
        }

        //new Calc
        //type tells you which sheet to create
        //create it
        //send it back to the user to download it
        //IFontResolver and assign to "GlobalFontSettings.FontResolver" to use fonts."

        //GlobalFontSettings.FontResolver = FontResolver;



        //switch (type)
        //{
        //    case "Multiplication":
        //        primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);
        //        break;
        //    case "Addition":
        //        primarySchoolTasks.AdditionDocument(gfx, xFont, document, headline);
        //        break;
        //    case "Division":
        //        primarySchoolTasks.DivisonDocument(gfx, xFont, document, headline);
        //        break;
        //    case "Subtraction":
        //        primarySchoolTasks.SubtractionDocument(gfx, xFont, document, headline);
        //        break;
        //    case "Addition Under":
        //        primarySchoolTasks.AdditionUnderDocument(gfx, xFont, document, headline);
        //        break;
        //    case "Division with Rest":
        //        primarySchoolTasks.DivisionWithRestDocument(gfx, xFont, document, headline);
        //        break;
        //    case "Subtraction Under":
        //        primarySchoolTasks.SubtractionUnderDocument(gfx, xFont, document, headline);
        //        break;
        //    case "Division Under":
        //        primarySchoolTasks.DivisionUnderDocument(gfx, xFont, document, headline);
        //        break;
        //}
        //var stream = new FileStream(@"C:\Documents\calculation.pdf", FileMode.Open);


        primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);
        return Ok("hello");
        //return File(stream, "api/pdf", "C:\\Documents\\calculation.pdf"); //PDF as response Message 
        ////https://stackoverflow.com/questions/40486431/return-pdf-to-the-browser-using-asp-net-core
    }
}
      
