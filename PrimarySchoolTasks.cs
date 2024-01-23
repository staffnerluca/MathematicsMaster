﻿using System.Reflection.Metadata;
using System.Xml.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace MathMaster
{
    public class PrimarySchoolTasks
    {
        #region Variables
        private static Random rand;

        private static List<string> division = new List<string>(); //That would be a global list now 
        private static List<string> multiplication = new List<string>();
        private static List<string> addition = new List<string>();
        private static List<string> additionUnder = new List<string>();
        private static List<string> subtraction = new List<string>();
        private static List<string> divisionWithRest = new List<string>();
        private static List<string> subtractionUnder = new List<string>();
        private static List<string> divisionUnder = new List<string>();

        PdfDocument document;
        PdfPage page;
        XGraphics gfx;
        XFont xFont;
        #endregion

        public PrimarySchoolTasks()
        {

        }

        static void Main(string[] args)
        {

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

        public void DivisonDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            division.Clear();
            CreatingDivisionList();

            gfx.DrawString("Divisionsaufgaben", headline, XBrushes.Black, new XRect
               (0, 0, 600, 120), XStringFormats.Center);

            int x = 150;
            int y = 70;
            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + division[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    division.RemoveAt(0);
                    y += 20;
                }
                x += 150;
                y = 70;
            }

            document.Save("C:\\Users\\Documents\\calculation.pdf");
        }

        public void MultiplicationDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
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

            document.Save("C:\\Users\\Documents\\calculation.pdf");
        }

        public void AdditionDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
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

            document.Save("C:\\Users\\Documents\\calculation.pdf");
        }

        public void AdditionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
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

            document.Save("C:\\Users\\Documents\\calculation.pdf");
        }

        public void SubtractionDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
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

            document.Save("C:\\Users\\Documents\\calculation.pdf");
        }

        public void DivisionWithRestDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
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

            document.Save("C:\\Users\\Documents\\calculation.pdf");
        } //one row under that the students can type in there stuff

        public void SubtractionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
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

            document.Save("C:\\Users\\Documents\\calculation.pdf");
        }

        public void DivisionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
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

            document.Save("C:\\Users\\Documents\\calculation.pdf");
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
                    fnumber = rand.Next(0, 1000);
                    snumber = rand.Next(0, 1000);
                }
                while (fnumber - snumber * (-1) <= 999);

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

                string calc = "";

                if (fnumber < 100)
                    calc = " ";

                divisionUnder.Add(" " + calc + fnumber + ":" + calc + snumber + "=______");
                divisionUnder.Add("");
                divisionUnder.Add("");
                divisionUnder.Add("");
            }
        }
    }
}