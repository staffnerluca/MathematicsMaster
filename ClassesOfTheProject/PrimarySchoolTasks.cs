using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using QuestPDF.Helpers;
using System.Drawing;
using System.Globalization;
using System.Data.Common;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.ConstrainedExecution;

namespace MathMaster
{
    public class PrimarySchoolTasks
    {
        public string type;
        public PrimarySchoolTasks(string type)
        {
            this.type = type;
        }

        public List<string> CreateElementsForPDF()
        {
                List<string> calcs = new List<string> { };
                Random r = new Random();
                int i = 0;
                while (i < 45)
                {
                    int num1 = r.Next(1, 10);
                    int num2 = r.Next(1, 10);
                    //types: m = Multiplication, a = addition, d = division, s = subtraction
                    if (type == "m")
                    {
                        calcs.Add(num1 + " * " + num2 + " = _____");
                    }

                    if (type == "d")
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            int fnumber; int snumber;
                            do
                            {
                                fnumber = r.Next(1, 10);
                                snumber = r.Next(1, 10);
                            }
                            while (fnumber % snumber != 0);

                            calcs.Add(fnumber + " / " + snumber + "= _____");
                        }
                    }

                    if (type == "a")
                    {
                        calcs.Add(num1.ToString() + "+" + num2.ToString() + "= _____");
                    }

                    if (type == "s")
                    {
                        calcs.Add(num1.ToString() + "-" + num2.ToString() + "= _____");
                    }
                    i++;
                }
                return calcs;           
        }

        public MemoryStream GenerateToMemoryStream()
        {
            //choose free license
            QuestPDF.Settings.License = LicenseType.Community;
            MemoryStream stream = new MemoryStream();

            //create pdf documen 
            Document.Create(container =>
            {
                //specifies the first page of the component
                container.Page(page =>
                {
                    string heading = "";
                    if (type == "a")
                        heading = "Addition";
                    else if (type == "s")
                        heading = "Subtraction";
                    else if (type == "m")
                        heading = "Multiplication";
                    else if (type == "d")
                        heading = "Division";
                    page.Size(PageSizes.A4);
                    page.Header().AlignCenter().Text(heading)
                    .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .Row(row =>
                        {
                            List<string> calcs = CreateElementsForPDF();
                            row.Spacing(3);
                            //needed to align the rows relative to each other
                            int relItemType = 2;
                            for(int i = 0; i <= 3; i++)
                            {
                                if(i == 1 || i == 2)
                                {
                                    relItemType = 1;
                                }
                                else
                                {
                                    relItemType = 2;
                                }
                                row.RelativeItem(relItemType).AlignCenter().Text(ro =>
                                {
                                    foreach (string c in calcs)
                                    {
                                        ro.Line(c);
                                    }
                                });
                            }
                        });
                });
            }).GeneratePdf(stream);
            return stream;
        }
    }
}