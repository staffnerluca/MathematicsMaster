using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Net;
using PdfSharp.Fonts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Web;
using System.Drawing;

namespace MathMaster.Controllers;

[Route("[controller]")]
public class CalculationController : ControllerBase
{

    private readonly ILogger<CalculationController> _logger;

    public CalculationController(ILogger<CalculationController> logger)
    {
        _logger = logger;
    }

    public static Random r = new Random();
    public static long typeInt = r.NextInt64(8);
    public static string pathNow = Directory.GetCurrentDirectory();

    [HttpGet]
    public IActionResult Get(string type)
    {
        
      
        string pdfCreatedPath = Path.Combine(pathNow, "PDFCreated");
        //don't understand because the frontend starts the download not you #ls
        //string path = @"C:\Downloads\PDFCreated"; //there also Users\luker ... path otherwise if this does not work
        if (!Directory.Exists(pdfCreatedPath))
        {
            GlobalFontSettings.FontResolver = new MyFontResolver();
            Directory.CreateDirectory(pdfCreatedPath);
        }

        //should look something like this, at least works on my machine
        string fontDir = "Font";
        string fontPath = Path.Combine(pathNow, fontDir);
        if (!Directory.Exists(fontPath))
        {
            Directory.CreateDirectory(fontPath);
        }
        string  sansDir = "open-sans";
        string openSansPath = Path.Combine(pathNow, fontDir, sansDir);
        if (!Directory.Exists(openSansPath))
        {
            Directory.CreateDirectory(openSansPath);
        }

        string ttfFile = "OpenSans - Regular.ttf";
        string regularTtfPath = Path.Combine(openSansPath, ttfFile);
        if (!Directory.Exists(regularTtfPath))
        {
            install();
            installv2();
            installv3();
            installv4();
            installv5();
            installv6();
            installv7();
            installv8();
            installv9();
            installv10();
        }

        PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();
        
        PdfPage page = new PdfPage();
        PdfDocument document = new PdfDocument();
        document.AddPage(page);
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont xFont = new XFont("OpenSans", 12);
        XFont headline = new XFont("OpenSans", 24);

        switch (type)
        {
            case "Multiplication":
                primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);
                break;
            case "Addition":
                primarySchoolTasks.AdditionDocument(gfx, xFont, document, headline);
                break;
            case "Division":
                primarySchoolTasks.DivisonDocument(gfx, xFont, document, headline);
                break;
            case "Subtraction":
                primarySchoolTasks.SubtractionDocument(gfx, xFont, document, headline);
                break;
            case "Addition Under":
                primarySchoolTasks.AdditionUnderDocument(gfx, xFont, document, headline);
                break;
            case "Division with Rest":
                primarySchoolTasks.DivisionWithRestDocument(gfx, xFont, document, headline);
                break;
            case "Subtraction Under":
                primarySchoolTasks.SubtractionUnderDocument(gfx, xFont, document, headline);
                break;
            case "Division Under":
                primarySchoolTasks.DivisionUnderDocument(gfx, xFont, document, headline);
                break;
        }
        //var stream = new FileStream(@"C:\Documents\calculation.pdf", FileMode.Open);
        //primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);

        primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);

        //you need to return the pdf here
        return Ok("hello");
        //return File(stream, "api/pdf", "C:\\Documents\\calculation.pdf"); //PDF as response Message 
        ////https://stackoverflow.com/questions/40486431/return-pdf-to-the-browser-using-asp-net-core
    }

    #region downloads
    public static void install()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.regular.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Regular.ttf";
        //string myLocalFilePath = "C:\\Users\\luker\\source\\repos\\HAK-KB\\2024-swp-4it-staffnerlresch\\Fonts\\open-sans\\OpenSans-Regular.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv2()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Italic.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv3()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.light.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Light.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv4()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.light-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-LightItalic.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv5()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.semibold.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Semibold.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv6()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.semibold-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-SemiboldItalic.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv7()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.bold.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Bold.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv8()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.bold-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-BoldItalic.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv9()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.extrabold.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-ExtraBold.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }

    public static void installv10()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.extrabold-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-ExtraBoldItalic.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }
    #endregion
}