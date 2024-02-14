using System.Drawing;
using System.Drawing.Text;
using System.Reflection.Metadata;
using System.Resources;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace MathMaster
{
    public class PrimarySchoolTasks
    {
        #region Variables
        public static Random rand = new Random();

        //one list only later 
        private static List<string> calculationsList = new List<string>();

        private static List<string> division = new List<string>(); //That would be a global list now 
        private static List<string> multiplication = new List<string>();
        private static List<string> addition = new List<string>();
        private static List<string> additionUnder = new List<string>();
        private static List<string> subtraction = new List<string>();
        private static List<string> divisionWithRest = new List<string>();
        private static List<string> subtractionUnder = new List<string>();
        private static List<string> divisionUnder = new List<string>();

      
        private static XFont xFont = new XFont("OpenSans", 12);
        private static XFont headline = new XFont("OpenSans", 12);

        public static PdfDocument document = new PdfDocument();
        public static PdfPage page = document.AddPage();
        public static XGraphics gfx = XGraphics.FromPdfPage(page);
        #endregion

        //FrontEnd Gunther has to pass along calculationSign the User chose, dont bother with that

        #region optimization
        public PdfDocument CreateDocument(string calculationSign)
        {
            //Create Calculations
            List<string> calculationsList = CreateCalculationsList(calculationSign);

            //x and y points of the startpoint (upper left corner) of the actual writeable surface
            int x = 150;
            int y = 70;

            //2 loops to create 3 columns in total with calculations
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 33; j++)
                {
                    gfx.DrawString("" + calculationsList[0], xFont, XBrushes.Black, new XRect(x, y, 0, 100), XStringFormats.Center);
                    calculationsList.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }
            return document;
        }

        public List<string> CreateCalculationsList(string calculationSign)
        {
            //Setup params
            int firstNumber = -2, secondNumber = -1;
            Random rng = new Random();
            string firstOffSet = "", secondOffSet = "";
            List<string> toReturn = new List<string>();
            int firstMax = 100;
            int secondMax = 100;
            bool goodForDivison = false;

            //a total of 100 calculations should be created
            //Neither number should be 0
            //firstNumber should be equal to or bigger than secondNumber
            //Add Offset for 1 digit Numbers
            for (int i = 0; i < 100; i++)
                {
                    while (firstNumber < secondNumber && goodForDivison)
                    {
                        if (calculationSign == "*")
                        {
                            firstMax = 10;
                            secondMax = 10;
                        }
                        if (calculationSign == "/")
                            secondMax = 10;
                        firstNumber = rng.Next(1, firstMax);
                        secondNumber = rng.Next(1, secondMax);
                    }

                    if (firstNumber % secondNumber == 0 || calculationSign != "/")
                    {
                        goodForDivison = true;
                    }
                    if (firstNumber < 10)
                        firstOffSet = " ";
                    if (secondNumber < 10)
                        secondOffSet = " ";

                    toReturn.Add(firstOffSet + firstNumber + " " + calculationSign + " " + secondOffSet + secondNumber + " = _____");
                }
            return toReturn;
        }

        //Allgemeine Regeln:
        //Erste Zahl größer als Zweite
        //Zweite nicht Null - ez rand.Next(1, xx);

        //#region DELETE maybe?
        //public static void CreateCalculationsList(char calculationSign)
        //{
        //    if (calculationsList.Count != 0)
        //        calculationsList.Clear();

        //    int firstNumber = -2, secondNumber = -1;
        //    string toAdd = string.Empty, offSetOne = "", offSetTwo = "";


        //    for (int i = 0; i < 100; i++)
        //    {
        //        while (firstNumber < secondNumber)
        //        {
        //            firstNumber = rand.Next(1, 100);
        //            secondNumber = rand.Next(1, 100);
        //        }

        //        if (firstNumber < 10)
        //            offSetOne = " ";

        //        if (secondNumber < 10)
        //            offSetTwo = " ";

        //        subtraction.Add(offSetOne + firstNumber + " " + calculationSign + " " + offSetTwo + secondNumber + " = _____");

        //    }
        //}
        //#endregion

        //TODO: DELETE IF NOT NEEDED
        ////Set max first and second Number in Case we want different limits
        //switch (calculationSign)
        //{
        //    case '+':
        //        firstNumber = rand.Next(1, 100);
        //        secondNumber = rand.Next(1, 100);
        //        break;
        //    case '-':
        //        firstNumber = rand.Next(1, 100);
        //        secondNumber = rand.Next(1, 100);
        //        break;
        //    case '*':
        //        firstNumber = rand.Next(1, 100);
        //        secondNumber = rand.Next(1, 100);
        //        break;
        //    case '/':
        //        firstNumber = rand.Next(1, 100);
        //        secondNumber = rand.Next(1, 100);
        //        break;
        //}
        #endregion

        //#region Not Needed?
        public PdfDocument DivisonDocument() //instead of GFX and XFont
        {
            //Just incase that nothing is in the list, clearing the list therefore
            division.Clear();
            CreatingDivisionList();

            gfx.DrawString("Divisionsaufgaben", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            int x = 150; //here were it starts at the sheet
            int y = 70; //here too
            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) 
                {
                    gfx.DrawString("" + division[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    division.RemoveAt(0); //have to remove it after used, since otherwise doubled amounts
                    y += 20;
                }
                x += 150;
                y = 70;
            }
            return document;
        }

        public PdfDocument MultiplicationDocument()
        {
            GlobalFontSettings.FontResolver = new MyFontResolver();
            multiplication.Clear();
            CreatingMultiplicationList();

            gfx.DrawString("Multiplikationsaufgabe", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + multiplication[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    multiplication.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }
            return document;
        }

        public PdfDocument AdditionDocument()
        {
            addition.Clear();
            CreatingAdditionList();

            gfx.DrawString("Additionsaufgaben", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + addition[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    addition.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }
            return document;
            //document.Save("C:\\Users\\Documents\\PDF.pdf");
        }

        public PdfDocument AdditionUnderDocument(XGraphics gfx, PdfDocument document)
        {
            additionUnder.Clear();
            CreatingAdditionUnderList();

            gfx.DrawString("Additionsaufgaben untereinander", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150; //150
            int y = 70; //10

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 32; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + additionUnder[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    additionUnder.RemoveAt(0);
                    y += 20;
                }
                x += 150; //150
                y = 70; //10
            }
            return document;
        }

        public PdfDocument SubtractionDocument(XGraphics gfx, PdfDocument document)
        {
            subtraction.Clear();
            CreatingSubtractionList();

            gfx.DrawString("Subtraktionsaufgaben", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + subtraction[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    subtraction.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }
            return document;
        }

        public PdfDocument DivisionWithRestDocument(XGraphics gfx, PdfDocument document)
        {
            divisionWithRest.Clear();
            CreatingDivisionWithRemainList();

            gfx.DrawString("Divisionsaufgaben mit Rest", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 100;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m < 17; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + divisionWithRest[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.BottomLeft); //(x, y, x, y)
                    y += 20;
                    gfx.DrawString("R: ", xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.BottomLeft); //(x, y, x, y)
                    y += 20;
                    divisionWithRest.RemoveAt(0);

                }
                x += 150;
                y = 70;
            }
            return document;
        } //one row under that the students can type in there stuff

        public PdfDocument SubtractionUnderDocument(XGraphics gfx, PdfDocument document)
        {
            subtractionUnder.Clear();
            CreatingSubtractionUnderList();

            gfx.DrawString("Subtraktion untereinander", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 32; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + subtractionUnder[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    subtractionUnder.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }
            return document;
        }

        public PdfDocument DivisionUnderDocument(XGraphics gfx, PdfDocument document)
        {
            divisionUnder.Clear();
            CreatingDivisionUnderList();

            gfx.DrawString("Division untereinander", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 36; m++) //DivisionStatement[index];
                {
                    gfx.DrawString(divisionUnder[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    divisionUnder.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }
            return document;
        }
        //#endregion

        //#region NotNeeded ?
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

                division.Add(calc + fnumber + " / " + snumber + "= _____");
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

                multiplication.Add(calc + fnumber + " * " + snumber + "= _____");
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

                addition.Add(calc + fnumber + " + " + snumber + "= _____");
            }
        }


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

                additionUnder.Add(" " + calc + fnumber);
                additionUnder.Add("+" + calc + snumber);
                additionUnder.Add("______");
                additionUnder.Add("");
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

                subtraction.Add(calc + r);
            }
        }

       

        public static void CreatingDivisionWithRemainList()
        {
            for (int i = 0; i <= 100; i++)
            {
                int fnumber; int snumber;

                int firstnumber = rand.Next(1, 100);
                int secondnumber = rand.Next(1, 100);
                string r;

                string calc = "";
                if (firstnumber < 10)
                    calc = "";

                string calcv2 = "";

                if (secondnumber < 10)
                    calcv2 = " ";


                if (firstnumber > secondnumber)
                {
                    r = calc + firstnumber + calc + " : " + calc + calcv2 + secondnumber + " = ___";
                }
                else
                {
                    r = calcv2 + secondnumber + " : " + calc + firstnumber + " = ___";
                }

                divisionWithRest.Add(calc + r);
            }
        }

        public static void CreatingSubtractionUnderList()
        {
            for (int i = 0; i < 32; i++)
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(0, 100);
                    snumber = rand.Next(0, 100);
                }
                while (fnumber - snumber * (-1) <= 999);
                //here it is that the numbers are smaller than 1000

                string calc = "";

                if (fnumber < 100)
                    calc = " ";

                subtractionUnder.Add(" " + calc + fnumber);
                subtractionUnder.Add("-" + calc + snumber);
                subtractionUnder.Add("______");
                subtractionUnder.Add("");
            }
        }

        public static void CreatingDivisionUnderList()
        {
            for (int i = 0; i < 36; i++)
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(0, 1000);
                    snumber = rand.Next(2, 10);
                }
                while (fnumber % snumber == 0);
                //7 % 3 = 1 because 2*3=6 and 1 rest
                //6 % 3 = 0 because 2 * 3 = 6 0 rest
                //this condition does make it so that always numbers are taken, were 0 rest will be coming out

                string calc = "";

                if (fnumber < 100)
                    calc = " ";
                //just for the better look at the pdf

                divisionUnder.Add(" " + calc + fnumber + ":" + calc + snumber + "=______");
                divisionUnder.Add("");
                divisionUnder.Add("");
                divisionUnder.Add("");
                //I have to do this, because I can't correctly format it otherwise
            }
        }
        //#endregion
    }
}