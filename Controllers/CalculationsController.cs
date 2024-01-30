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
using MathMaster.ClassesOfTheProject;

namespace MathMaster.Controllers;

[Route("[controller]")]
public class CalculationController : ControllerBase
{

    private readonly ILogger <CalculationController> _logger; //to login somewhere, single method instead of more

    public CalculationController(ILogger<CalculationController> logger)
    {
        _logger = logger;
    }

    public static Random r = new Random();
    public static long typeInt = r.NextInt64(8);
    public static string pathNow = Directory.GetCurrentDirectory(); //get current path, where you at

    [HttpGet]
    public IActionResult Get(string type) //IActionResult because it has to do an action. Return of multiple types of data
    {
        string pdfCreatedPath = Path.Combine(pathNow, "PDFCreated"); //here we combine two paths
        //don't understand because the frontend starts the download not you #ls
        //looking if path already exists, otherwise path is created       
        if (!Directory.Exists(pdfCreatedPath))
        {
            Directory.CreateDirectory(pdfCreatedPath);
        }

        //should look something like this, at least works on my machine #ls
        string fontDir = "Font";
        string fontPath = Path.Combine(pathNow, fontDir); //also combining the paths there
        //looking if path already exists, otherwise it will get created
        if (!Directory.Exists(fontPath))
        {
            Directory.CreateDirectory(fontPath);
        }

        string  sansDir = "open-sans";
        string openSansPath = Path.Combine(pathNow, fontDir, sansDir); //combining the paths
        //looking if path exists, otherwise creating it
        if (!Directory.Exists(openSansPath))
        {
            Directory.CreateDirectory(openSansPath);
        }

        string ttfFile = "OpenSans - Regular.ttf";
        string regularTtfPath = Path.Combine(openSansPath, ttfFile); //combining the paths aswell 
        //looking if the path does already exist, otherwise it is getting created plus all pictures are getting "installed" <-- downloaded automaticly            
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

        if (PdfSharp.Fonts.GlobalFontSettings.FontResolver is null)
        {
            GlobalFontSettings.FontResolver = new MyFontResolver();
        }
        //problem with IFontResolver hopefully solved

        #region Variables 
        PrimarySchoolTasks primarySchoolTasks = new PrimarySchoolTasks();
        //GlobalFontSettings.FontResolver = new MyFontResolver();
        PdfPage page = new PdfPage();
        PdfDocument document = new PdfDocument();
        document.AddPage(page);
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont xFont = new XFont("OpenSans", 12);
        XFont headline = new XFont("OpenSans", 24);
        //here my variables, because I need to put XFont here otherwise won't work because of IFontResolver
        #endregion

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
        //with the switch I am looking what the user does want to do, then I am directing him to the wished method. 
        
        primarySchoolTasks.MultiplicationDocument(gfx, xFont, document, headline);
        //you need to return the pdf here
        return Ok("hello");
    }

    //In the region downloads I am automaticly downloading the font files, beacause I need them for the IFontResolver, otherwise surprisingly my font won't work!
    #region Downloads
    public static void install()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.regular.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Regular.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv2()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Italic.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv3()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.light.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Light.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        } 
    }

    public static void installv4()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.light-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-LightItalic.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv5()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.semibold.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Semibold.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv6()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.semibold-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-SemiboldItalic.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv7()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.bold.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-Bold.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv8()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.bold-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-BoldItalic.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv9()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.extrabold.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-ExtraBold.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }

    public static void installv10()
    {
        // A web URL with a file response
        string myWebUrlFile = "https://www.1001fonts.com/download/font/open-sans.extrabold-italic.ttf";
        // Local path where the file will be saved
        string myLocalFilePath = pathNow + "\\Font\\open-sans\\OpenSans-ExtraBoldItalic.ttf";

        //a using with a WebClient (an Entry Point for the Web)
        using (var client = new WebClient())
        {
            client.DownloadFile(myWebUrlFile, myLocalFilePath); //just downloading the file here and putting it in the path I want it to have
        }
    }
    #endregion
}