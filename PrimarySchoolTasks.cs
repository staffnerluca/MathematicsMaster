using System.Reflection.Metadata;
using System.Xml.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace MathMaster { 
    public class PrimarySchoolTasks
    {
        #region Variables
        private static Random rand;

        private static List<string> DivisionStatements;
        private static List<string> MultiplicationStatements;
        private static List<string> AdditionStatements;
        private static List<string> AdditionUnderStatements;
        private static List<string> SubtractionStatements;
        private static List<string> DivisionWithRestStatements;
        private static List<string> SubtractionUnderStatements
            ;
        private static List<string> DivisionUnderStatements;
        PdfDocument document;
        PdfPage page;
        XGraphics gfx;
        XFont xFont;
        #endregion

        static void Main(string[] args)
        {
            DivisionStatements = new List<string>();
            MultiplicationStatements = new List<string>();
            AdditionStatements = new List<string>();
            AdditionUnderStatements = new List<string>();
            SubtractionStatements = new List<string>();
            DivisionWithRestStatements = new List<string>();
            SubtractionUnderStatements = new List<string>();
            DivisionUnderStatements = new List<string>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //NugetPackage Registerment

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont xFont = new XFont("Arial", 20);
            XFont headline = new XFont("Arial", 32);
            rand = new Random();

            string menu =
            "Was möchten Sie machen?\n" + "1-Multiplikation\n"
            + "2-Addition\n" + "3-Division\n" + "4-Addition with numbers under each other\n" + "5-Subtraction\n"
            + "6-Division with rest\n" + "7-Subtraction with numbers under each other\n" + "8-Division with numbers under each other\n";

            Console.WriteLine(menu);
            string answa = Console.ReadLine();

            switch (answa)
            {
                case "1":
                    MultiplicationDocument(gfx, xFont, document, headline);
                    break;

                case "2":
                    AdditionDocument(gfx, xFont, document, headline);
                    break;

                case "3":
                    DivisonDocument(gfx, xFont, document, headline);
                    break;

                case "4":
                    AdditionUnderDocument(gfx, xFont, document, headline);
                    break;

                case "5":
                    SubtractionDocument(gfx, xFont, document, headline);
                    break;

                case "6":
                    DivisionWithRestDocument(gfx, xFont, document);
                    break;

                case "7":
                    SubtractionUnderDocument(gfx, xFont, document, headline);
                    break;

                case "8":
                    DivisionUnderDocument(gfx, xFont, document);
                    break;
            }

            //Console
            //               .ReadLine()
            //                       .ToLower();
            //Console.ReadLine().ToLower(); //This is the Same in both ways
        }
        //DRY := Don't repeat yourself
        /* public static void DocumentCreation()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //NugetPackage Registerment

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont xFont = new XFont("Arial", 20);
        }*/

        public static void DivisonDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            DivisionStatements.Clear();
            CreatingDivisionList();

            gfx.DrawString("Divisionsaufgaben", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;
            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + DivisionStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    DivisionStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\DivisionForPrimaryStudents.pdf");
        }

        public static void MultiplicationDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            MultiplicationStatements.Clear();
            CreatingMultiplicationList();

            gfx.DrawString("Multiplikationsaufgabe", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + MultiplicationStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    MultiplicationStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\MultiplicationForPrimaryStudents.pdf");
        }

        public static void AdditionDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            AdditionStatements.Clear();
            CreatingAdditionList();

            gfx.DrawString("Additionsaufgaben", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + AdditionStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    AdditionStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\AdditionForPrimaryStudents.pdf");
        }

        public static void AdditionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            AdditionUnderStatements.Clear();
            CreatingAdditionUnderList();

            gfx.DrawString("Additionsaufgaben untereinander", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150; //150
            int y = 70; //10

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 32; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + AdditionUnderStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    AdditionUnderStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150; //150
                y = 70; //10
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\AdditionUnderForPrimaryStudents.pdf");
            Console.WriteLine("Done");
        }

        public static void SubtractionDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            SubtractionStatements.Clear();
            CreatingSubtractionList();

            gfx.DrawString("Subtraktionsaufgaben", headline, XBrushes.Black, new XRect
               (0, 0, 600, 40), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + SubtractionStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    SubtractionStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\SubtractionForPrimaryStudents.pdf");
        }

        public static void DivisionWithRestDocument(XGraphics gfx, XFont xFont, PdfDocument document)
        {
            DivisionWithRestStatements.Clear();
            CreatingDivisionWithRemainList();

            gfx.DrawString("Divisionsaufgaben mit Rest", xFont, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + DivisionWithRestStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    DivisionWithRestStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\DivisionWithRestTasksForPrimaryStudents.pdf");
        } //one row under that the students can type in there stuff

        public static void SubtractionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            SubtractionUnderStatements.Clear();
            CreatingSubtractionUnderList();

            gfx.DrawString("Subtraktion untereinander", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 32; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + SubtractionUnderStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    SubtractionUnderStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\SubtractionUnderTasksForPrimaryStudents.pdf");
            Console.WriteLine("Done");
        }

        public static void DivisionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document)
        {
            DivisionUnderStatements.Clear();
            CreatingDivisionUnderList();

            gfx.DrawString("Division untereinander", xFont, XBrushes.Black, new XRect
               (0, 0, 600, 40), XStringFormats.Center);

            int x = 150;
            int y = 10;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 16; m++) //DivisionStatement[index];
                {
                    gfx.DrawString(DivisionUnderStatements[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    DivisionUnderStatements.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 10;
            }

            document.Save("C:\\Users\\lukas.resch\\Documents\\DivisionUnderTasksForPrimaryStudents.pdf");
            Console.WriteLine("Done");
        }

        public static void CreatingDivisionList()
        {
            for (int i = 0; i < 100; i++)
            {
                int fnumber; int snumber;
                do
                {
                    fnumber = rand.Next(1, 100);
                    snumber = rand.Next(1, 10);
                }
                while (fnumber % snumber != 0);

                string calc = "";

                if (fnumber < 10)
                    calc = " ";

                DivisionStatements.Add(calc + fnumber + " / " + snumber + "= _____");
            }
        }

        public static void CreatingMultiplicationList()
        {
            for (int i = 0; i < 100; i++)
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(1, 10);
                    snumber = rand.Next(1, 10);
                }
                while (i > 100);

                string calc = "";

                if (fnumber < 10)
                    calc = " ";

                MultiplicationStatements.Add(calc + fnumber + " * " + snumber + "= _____");
            }
        }

        public static void CreatingAdditionList()
        {
            for (int i = 0; i < 100; i++)
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(1, 100);
                    snumber = rand.Next(1, 100);
                }
                while (fnumber + snumber <= 100);

                string calc = "";

                if (fnumber < 10)
                    calc = " ";

                AdditionStatements.Add(calc + fnumber + " + " + snumber + "= _____");
            }
        }

        /// <summary>
        ///   123
        /// + 232
        /// ------
        ///   355
        ///   
        /// So it shall like that on the sheet of paper, because if its in a straight line, the primary kids will not be able to calculate it that well 
        /// </summary>
        public static void CreatingAdditionUnderList()
        {
            for (int i = 0; i < 32; i++) // i < 24 works 
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(1, 1000);
                    snumber = rand.Next(1, 1000);
                }
                while (fnumber + snumber <= 999);

                string calc = "";

                if (fnumber < 100)
                    calc = " ";

                AdditionUnderStatements.Add(" " + calc + fnumber);
                AdditionUnderStatements.Add("+" + calc + snumber);
                AdditionUnderStatements.Add("______");
                AdditionUnderStatements.Add("");
            }
        }

        public static void CreatingSubtractionList()
        {
            for (int i = 0; i < 100; i++)
            {
                int fnumber; int snumber;

                int firstnumber = rand.Next(0, 100);
                int secondnumber = rand.Next(0, 100);
                string r;

                string calc = "";

                if (firstnumber < 10)
                    calc = " ";

                string calcv2 = "";

                if (secondnumber < 10)
                    calcv2 = "  ";


                if (firstnumber > secondnumber)
                {
                    r = calc + firstnumber + calc + " - " + calc + calcv2 + secondnumber + " = _____";
                }
                else
                {
                    r = calcv2 + secondnumber + " - " + calc + firstnumber + " = _____";
                }

                SubtractionStatements.Add(calc + r);
            }
        }

        public static void CreatingDivisionWithRemainList()
        {
            for (int i = 0; i < 100; i++)
            {
                int fnumber; int snumber;

                int firstnumber = rand.Next(0, 100);
                int secondnumber = rand.Next(0, 100);
                string r;

                string calc = "";
                if (firstnumber < 10)
                    calc = "";

                string calcv2 = "";

                if (secondnumber < 10)
                    calcv2 = " ";


                if (firstnumber > secondnumber)
                {
                    r = calc + firstnumber + " : " + calcv2 + secondnumber + " = _____";
                }
                else
                {
                    r = calcv2 + secondnumber + " : " + calc + firstnumber + " = _____";
                }

                DivisionWithRestStatements.Add(r);
            }
        }

        public static void CreatingSubtractionUnderList()
        {
            for (int i = 0; i < 32; i++)
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(0, 1000);
                    snumber = rand.Next(0, 1000);
                }
                while (fnumber - snumber * (-1) <= 999);

                string calc = "";

                if (fnumber < 100)
                    calc = " ";

                SubtractionUnderStatements.Add(" " + calc + fnumber);
                SubtractionUnderStatements.Add("-" + calc + snumber);
                SubtractionUnderStatements.Add("______");
                SubtractionUnderStatements.Add("");
            }
        }

        public static void CreatingDivisionUnderList()
        {
            for (int i = 0; i < 16; i++)
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(0, 1000);
                    snumber = rand.Next(2, 10);
                }
                while (fnumber % snumber == 0);

                string calc = "";

                if (fnumber < 100)
                    calc = " ";

                DivisionUnderStatements.Add(" " + calc + fnumber + ":" + calc + snumber + "=______");
                DivisionUnderStatements.Add("______");
                DivisionUnderStatements.Add("______");
                DivisionUnderStatements.Add("______");
                DivisionUnderStatements.Add("");
            }
        }
    }
}