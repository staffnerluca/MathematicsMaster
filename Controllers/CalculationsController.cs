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

        PdfDocument document = new PdfDocument();
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        PrimarySchoolTasks tasks = new PrimarySchoolTasks();
        //edit page

        document = tasks.MultiplicationDocument;

        return document;

        //PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();

        //#region MAYBE DELETE
        ////new Calc
        ////type tells you which sheet to create
        ////create it
        ////send it back to the user to download itIFontResolver and assign to "GlobalFontSettings.FontResolver" to use fonts."


        ////switch (type)
        ////{
        ////    case "Multiplication":
        ////        primarySchoolTasks.MultiplicationDocument(gfx, document);
        ////        break;
        ////    case "Addition":
        ////        primarySchoolTasks.AdditionDocument(gfx, document);
        ////        break;
        ////    case "Division":
        ////        primarySchoolTasks.DivisonDocument(gfx, document);
        ////        break;
        ////    case "Subtraction":
        ////        primarySchoolTasks.SubtractionDocument(gfx, document);
        ////        break;
        ////    case "Addition Under":
        ////        primarySchoolTasks.AdditionUnderDocument(gfx, document);
        ////        break;
        ////    case "Division with Rest":
        ////        primarySchoolTasks.DivisionWithRestDocument(gfx, document);
        ////        break;
        ////    case "Subtraction Under":
        ////        primarySchoolTasks.SubtractionUnderDocument(gfx, document);
        ////        break;
        ////    case "Division Under":
        ////        primarySchoolTasks.DivisionUnderDocument(gfx, document);
        ////        break;
        ////}
        //#endregion

        //primarySchoolTasks.MultiplicationDocument(gfx, document);
        //var stream = new FileStream(@"C:\Users\Documents\calculation.pdf", FileMode.Open); //diese Datei gibt es nicht
        ////return Ok("hello");
        //return File(stream, "api/pdf", "C:\\Users\\Documents\\calculation.pdf"); //PDF as response Message  //Datei gibt es nicht, also PDF datei
        //////https://stackoverflow.com/questions/40486431/return-pdf-to-the-browser-using-asp-net-core
    }
}
      
