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
    
    public static string pathNow = Directory.GetCurrentDirectory();

    [HttpGet]
    public IActionResult Get(string calculationSign)
    {
        ////Create the necessary Files to being able to actually return a PDF Document at some point
        //PdfDocument document = new PdfDocument();
        //XFont headline = new XFont("Arial", 32); //Prolly not working
        //PdfPage page = document.AddPage();
        //XGraphics gfx = XGraphics.FromPdfPage(page); //Prolly not working
        //XFont xFont = new XFont("Arial", 20); //Prolly not working

        PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();

        MemoryStream stream = new MemoryStream(primarySchoolTasks.CreateDocument());
        var stream = new FileStream(pathNow + "\\calculation.pdf", FileMode.Open); //diese Datei gibt es nicht
        return new FileStreamResult(stream, "application/pdf");

        //edit page
        //document = tasks.CreateDocument(calculationSign);
        //return document;

        //PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();

        //#region MAYBE DELETE
        ////new Calc
        ////type tells you which sheet to create
        ////create it
        ////send it back to the user to download itIFontResolver and assign to "GlobalFontSettings.FontResolver" to use fonts."

        //switch (calculationSign)
        //{
        //    case "Multiplication":
        //        primarySchoolTasks.CreateDocument(calculationSign);
        //        break;
            //case "Addition":
            //    primarySchoolTasks.AdditionDocument(gfx, document);
            //    break;
            //case "Division":
            //    primarySchoolTasks.DivisonDocument(gfx, document);
            //    break;
            //case "Subtraction":
            //    primarySchoolTasks.SubtractionDocument(gfx, document);
            //    break;
            //case "AdditionUnder":
            //    primarySchoolTasks.AdditionUnderDocument(gfx, document);
            //    break;
            //case "DivisionWithRemainder":
            //    primarySchoolTasks.DivisionWithRestDocument(gfx, document);
            //    break;
            //case "SubtractionsUnder":
            //    primarySchoolTasks.SubtractionUnderDocument(gfx, document);
            //    break;
            //case "DivisionUnder":
            //    primarySchoolTasks.DivisionUnderDocument(gfx, document);
            //    break;
        }
        //return document;
        //return File(stream, "application/pdf", "FileDownloadName.ext");
        //#endregion

        //primarySchoolTasks.MultiplicationDocument(gfx, document);
        //var stream = new FileStream(pathNow + "\\calculation.pdf", FileMode.Open); //diese Datei gibt es nicht
        //return File(stream, "api/pdf", pathNow + "\\calculation.pdf"); //PDF as response Message  //Datei gibt es nicht, also PDF datei
        //////https://stackoverflow.com/questions/40486431/return-pdf-to-the-browser-using-asp-net-core
    }
}
      
