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


    //    "Was möchten Sie machen?\n" + "1-Multiplikation\n"
    //+ "2-Addition\n" + "3-Division\n" + "4-Addition with numbers under each other\n" + "5-Subtraction\n"
    //+ "6-Division with rest\n" + "7-Subtraction with numbers under each other\n" + "8-Division with numbers under each other\n";

    [HttpGet]
    public IActionResult Get(string type)
    {
        Random r = new Random();
        long typeInt = r.NextInt64(8);
        string pathNow = Directory.GetCurrentDirectory();
        string pdfCreatedPath = Path.Combine(pathNow, "PDFCreated");
        //don't understand because the frontend starts the download not you #ls
        //string path = @"C:\Downloads\PDFCreated"; //there also Users\luker ... path otherwise if this does not work
        if (!Directory.Exists(pdfCreatedPath))
        {
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
    
        //Directory.CreateDirectory(@"C:\Users\luker\source\repos\HAK-KB\2024-swp-4it-staffnerlresch\PDFCreated");
        //Directory.CreateDirectory(@"C:\Users\luker\source\repos\HAK-KB\2024-swp-4it-staffnerlresch\Fonts23");
        //Directory.CreateDirectory(@"C:\Users\luker\source\repos\HAK-KB\2024-swp-4it-staffnerlresch\Fonts23\open-sans");
        // Create a new PDF document
        //new Calc
        //type tells you which sheet to create
        //create it
        //send it back to the user to download it
        //IFontResolver and assign to "GlobalFontSettings.FontResolver" to use fonts."

        PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();
        
        XFont xFont;
        XFont headline;
        PdfPage page = new PdfPage();
        PdfDocument document = new PdfDocument();
        document.AddPage(page);
        XGraphics gfx = XGraphics.FromPdfPage(page);

        switch (type)
        {
            case "Multiplication":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);
                break;
            case "Addition":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.AdditionDocument(gfx, xFont, document, headline);
                break;
            case "Division":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.DivisonDocument(gfx, xFont, document, headline);
                break;
            case "Subtraction":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.SubtractionDocument(gfx, xFont, document, headline);
                break;
            case "Addition Under":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.AdditionUnderDocument(gfx, xFont, document, headline);
                break;
            case "Division with Rest":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.DivisionWithRestDocument(gfx, xFont, document, headline);
                break;
            case "Subtraction Under":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.SubtractionUnderDocument(gfx, xFont, document, headline);
                break;
            case "Division Under":
                GlobalFontSettings.FontResolver = new MyFontResolver();
                xFont = new XFont("OpenSans", 12);
                headline = new XFont("OpenSans", 24);
                primarySchoolTasks.DivisionUnderDocument(gfx, xFont, document, headline);
                break;
        }
        //var stream = new FileStream(@"C:\Documents\calculation.pdf", FileMode.Open);
        //primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);
        GlobalFontSettings.FontResolver = new MyFontResolver(); 
        xFont = new XFont("OpenSans", 12);
        headline = new XFont("OpenSans", 24);
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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-Regular.ttf";
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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-Italic.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-Light.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-LightItalic.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-Semibold.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-SemiboldItalic.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-Bold.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-BoldItalic.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-ExtraBold.ttf";

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
        string myLocalFilePath = "C:\\Documents\\Fonts\\open-sans\\OpenSans-ExtraBoldItalic.ttf";

        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath);
        }
    }
    #endregion
}