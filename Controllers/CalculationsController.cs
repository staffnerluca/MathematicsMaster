using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace MathMaster.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculationController : ControllerBase
{
    [HttpPost]
    [Route ("api/pdf")]
    public HttpResponseMessage GetPdf()
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
        return document; //PDF as response Message
    }
}
