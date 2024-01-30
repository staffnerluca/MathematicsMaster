using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace MathMaster.ClassesOfTheProject
{
    public class PrimarySchoolTasks
    {
        #region Variables 
        private static Random rand = new Random();
        //one list only
        private static List<string> division = new List<string>();
        private static List<string> multiplication = new List<string>();
        private static List<string> addition = new List<string>();
        private static List<string> additionUnder = new List<string>();
        private static List<string> subtraction = new List<string>();
        private static List<string> divisionWithRest = new List<string>();
        private static List<string> subtractionUnder = new List<string>();
        private static List<string> divisionUnder = new List<string>();
        public static string pathNow = Directory.GetCurrentDirectory(); //getting the current path the user is on
        #endregion

        public PrimarySchoolTasks()
        {

        }

        public static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //NugetPackage Registerment
        }

        public void DivisonDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            division.Clear();
            CreatingDivisionList();

            gfx.DrawString("Divisionsaufgaben", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            int x = 150; //here were it starts at the sheet
            int y = 70; //here too

            for (int i = 1; i <= 3; i++)
            {
                for (int m = 1; m <= 100 / 3; m++)
                {
                    gfx.DrawString("" + division[0], xFont, XBrushes.Black, new XRect //covers hole page
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    division.RemoveAt(0);
                    //just formating and then have to remove object because otherwise there will always be the same number there
                    y += 20;
                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        }

        public void MultiplicationDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            multiplication.Clear();
            CreatingMultiplicationList();

            gfx.DrawString("Multiplikationsaufgabe", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            //here were it starts at the sheet
            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + multiplication[0], xFont, XBrushes.Black, new XRect //covers hole page
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    multiplication.RemoveAt(0);
                    //just formating and then have to remove object because otherwise there will always be the same number there
                    y += 20;
                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        }

        public void AdditionDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            addition.Clear();
            CreatingAdditionList();

            gfx.DrawString("Additionsaufgaben", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            //here were it starts at the sheet
            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + addition[0], xFont, XBrushes.Black, new XRect //covers hole page
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    addition.RemoveAt(0);
                    //just formating and then have to remove object because otherwise there will always be the same number there
                    y += 20;
                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        }

        public void AdditionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            additionUnder.Clear();
            CreatingAdditionUnderList();

            gfx.DrawString("Additionsaufgaben untereinander", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            //here were it starts at the sheet
            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 32; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + additionUnder[0], xFont, XBrushes.Black, new XRect //covers hole page
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    additionUnder.RemoveAt(0);
                    //just formating and then have to remove object because otherwise there will always be the same number there
                    y += 20;
                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        }

        public void SubtractionDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            subtraction.Clear();
            CreatingSubtractionList();

            gfx.DrawString("Subtraktionsaufgaben", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            //here were it starts at the sheet
            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 100 / 3; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + subtraction[0], xFont, XBrushes.Black, new XRect //covers hole page
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    subtraction.RemoveAt(0);
                    //just formating and then have to remove object because otherwise there will always be the same number there
                    y += 20;
                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        }

        public void DivisionWithRestDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            divisionWithRest.Clear();
            CreatingDivisionWithRemainList();

            gfx.DrawString("Divisionsaufgaben mit Rest", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            //here were it starts at the sheet
            int x = 100;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m < 17; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + divisionWithRest[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.BottomLeft); //(x, y, x, y)
                    y += 20;
                    gfx.DrawString("R: ", xFont, XBrushes.Black, new XRect //covers hole page
                        (x, y, 0, 100), XStringFormats.BottomLeft); //(x, y, x, y)
                    //those two lines are just for the formating too 
                    y += 20;
                    divisionWithRest.RemoveAt(0);

                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        } //one row under that the students can type in there stuff

        public void SubtractionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            subtractionUnder.Clear();
            CreatingSubtractionUnderList();

            gfx.DrawString("Subtraktion untereinander", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format

            //here were it starts at the sheet
            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 32; m++) //DivisionStatement[index];
                {
                    gfx.DrawString("" + subtractionUnder[0], xFont, XBrushes.Black, new XRect //covers hole page
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    subtractionUnder.RemoveAt(0);
                    //just formating and then have to remove object because otherwise there will always be the same number there
                    y += 20;
                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        }

        public void DivisionUnderDocument(XGraphics gfx, XFont xFont, PdfDocument document, XFont headline)
        {
            //Just incase that nothing is in the list, clearing the list therefore, then creating it
            divisionUnder.Clear();
            CreatingDivisionUnderList();

            gfx.DrawString("Division untereinander", headline, XBrushes.Black, new XRect //covers hole page
               (0, 0, 600, 120), XStringFormats.Center); //just the headline, with a specific format 

            //here were it starts at the sheet
            int x = 150;
            int y = 70;

            for (int i = 1; i <= 3; i++) //1 because of multiplication
            {
                for (int m = 1; m <= 36; m++) //DivisionStatement[index];
                {
                    gfx.DrawString(divisionUnder[0], xFont, XBrushes.Black, new XRect
                        (x, y, 0, 100), XStringFormats.Center); //(x, y, x, y)
                    divisionUnder.RemoveAt(0);
                    //just formating and then have to remove object because otherwise there will always be the same number there
                    y += 20;
                }
                x += 150; //new row
                y = 70;
            }

            document.Save(pathNow + "\\PDFCreated\\calculation.pdf");
        }

        public static void CreatingDivisionList()
        {
            for (int i = 0; i < 100; i++) //creating a hundred statments for the document
            {
                int fnumber; int snumber;
                do
                {
                    fnumber = rand.Next(1, 100);
                    snumber = rand.Next(1, 10);
                }
                while (fnumber % snumber != 0);
                //no decimal number shall come out

                string calc = "";
                if (fnumber < 10)
                    calc = " ";
                //just for the better look at the pdf

                division.Add(calc + fnumber + " / " + snumber + "= _____");
                //normal division
            }
        }

        public static void CreatingMultiplicationList()
        {
            for (int i = 0; i < 100; i++) //creating a hundred statments for the document
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(1, 10); //just creating a number which is between those 2 assigned numbers
                    snumber = rand.Next(1, 10); //just creating a number which is between those 2 assigned numbers
                }
                while (i > 100);
                //here we just looking, that not more than 100 statements are created 

                string calc = "";
                if (fnumber < 10)
                    calc = " ";
                //just for the better look at the pdf

                multiplication.Add(calc + fnumber + " * " + snumber + "= _____");
                //normal multiplication line
            }
        }

        public static void CreatingAdditionList()
        {
            for (int i = 0; i < 100; i++) //creating a hundred statments for the document
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(1, 100); //just creating a number which is between those 2 assigned numbers
                    snumber = rand.Next(1, 100); //just creating a number which is between those 2 assigned numbers
                }
                while (fnumber + snumber <= 100);

                string calc = "";
                if (fnumber < 10)
                    calc = " ";
                //just for the better look at the pdf

                addition.Add(calc + fnumber + " + " + snumber + "= _____");
                //just normal addition, adding 2 numbers
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
            for (int i = 0; i < 32; i++) // creating 32 statements, because otherwise it won't work 
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(1, 1000); //just creating a number which is between those 2 assigned numbers
                    snumber = rand.Next(1, 1000); //just creating a number which is between those 2 assigned numbers
                }
                while (fnumber + snumber <= 999);
                //here I am just looking that the result is not more then 1000, because we don't want this

                string calc = "";
                if (fnumber < 100)
                    calc = " ";
                //just for the better look at the pdf

                additionUnder.Add(" " + calc + fnumber);
                additionUnder.Add("+" + calc + snumber);
                additionUnder.Add("______");
                additionUnder.Add("");
                //have to do this otherwise pdf won't work perfectly as I want
            }
        }

        public static void CreatingSubtractionList()
        {
            for (int i = 0; i < 100; i++) //creating a hundred statments for the document
            {
                int fnumber; int snumber;

                int firstnumber = rand.Next(0, 100); //just creating a number which is between those 2 assigned numbers
                int secondnumber = rand.Next(0, 100); //just creating a number which is between those 2 assigned numbers
                string r;

                string calc = "";
                if (firstnumber < 10)
                    calc = " ";
                //just for the better look at the pdf

                string calcv2 = "";
                if (secondnumber < 10)
                    calcv2 = "  ";
                //just for the better look at the pdf

                if (firstnumber > secondnumber)
                {
                    r = calc + firstnumber + calc + " - " + calc + calcv2 + secondnumber + " = _____";
                }
                else
                {
                    r = calcv2 + secondnumber + " - " + calc + firstnumber + " = _____";
                }
                //here its looking what the bigger number is, beacause we don't want a minus number as a result

                subtraction.Add(calc + r);
            }
        }

        public static void CreatingDivisionWithRemainList()
        {
            for (int i = 0; i <= 100; i++) //creating a hundred statments for the document
            {
                int fnumber; int snumber;

                int firstnumber = rand.Next(1, 100); //just creating a number which is between those 2 assigned numbers
                int secondnumber = rand.Next(1, 100); //just creating a number which is between those 2 assigned numbers
                string r;

                string calc = "";
                if (firstnumber < 10)
                    calc = "";
                //just for the better look at the pdf

                string calcv2 = "";
                if (secondnumber < 10)
                    calcv2 = " ";
                //just for the better look at the pdf

                if (firstnumber > secondnumber)
                {
                    r = calc + firstnumber + calc + " : " + calc + calcv2 + secondnumber + " = ___";
                }
                else
                {
                    r = calcv2 + secondnumber + " : " + calc + firstnumber + " = ___";
                }
                //here I just have 2 varients either the first or the second number is bigger or like that dividing through number 2 does create 0 rest

                divisionWithRest.Add(calc + r);
            }
        }

        public static void CreatingSubtractionUnderList()
        {
            for (int i = 0; i < 32; i++) //creating 32 statements, otherwise it won't work
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(0, 1000); //just creating a number which is between those 2 assigned numbers
                    snumber = rand.Next(0, 1000); //just creating a number which is between those 2 assigned numbers
                }
                while (fnumber - snumber * -1 <= 999);
                //here it is that the numbers are smaller than 1000

                string calc = "";
                if (fnumber < 100)
                    calc = " ";
                //just for the better look at the pdf

                subtractionUnder.Add(" " + calc + fnumber);
                subtractionUnder.Add("-" + calc + snumber);
                subtractionUnder.Add("______");
                subtractionUnder.Add("");
                //have to format it like that otherwise it doesn't work
            }
        }

        public static void CreatingDivisionUnderList()
        {
            for (int i = 0; i < 36; i++) //it won't work otherwise, if we do for example create 50 statements
            {
                int fnumber; int snumber;

                do
                {
                    fnumber = rand.Next(0, 1000); //just creating a number which is between those 2 assigned numbers
                    snumber = rand.Next(2, 10); //just creating a number which is between those 2 assigned numbers
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
    }
}