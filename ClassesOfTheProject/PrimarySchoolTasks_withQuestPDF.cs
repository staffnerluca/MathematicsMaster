using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using QuestPDF.Helpers;
using System.Drawing;
using System.Globalization;
using System.Data.Common;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace MathMaster
{
    public class PrimarySchoolTasks_withQuestPDF
    {
        public string type;
        public PrimarySchoolTasks_withQuestPDF(string type)
        {
            this.type = type;
        }

        public List<string> CreateElementsForPDF(string type)
        {
            List<string> calcs = new List<string> { };
            Random r = new Random();
            int i = 0;
            while (i < 45)
            {
                int num1 = r.Next(1, 10);
                int num2 = r.Next(1, 10);
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

        public MemoryStream GenerateToMemoryStream(string type)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            MemoryStream stream = new MemoryStream();

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Header().AlignCenter().Text("Multiplikationsaufgaben")
                    .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .Row(row =>
                        {
                            List<string> calcs = CreateElementsForPDF(type);
                            row.Spacing(3);
                            row.RelativeItem(2).AlignCenter().Text(ro =>
                            {
                                foreach (string c in calcs)
                                {
                                    Console.WriteLine(c);
                                    ro.Line("" + c);
                                }
                            });
                            row.RelativeItem(1).AlignCenter().Text(ro =>
                            {
                                calcs.Clear();
                                List<string> d = CreateElementsForPDF(type);
                                foreach (string c in d)
                                {
                                    Console.WriteLine(c);
                                    ro.Line("" + c);
                                }
                            });
                            row.RelativeItem(1).AlignCenter().Text(ro =>
                            {
                                calcs.Clear();
                                List<string> d = CreateElementsForPDF(type);
                                foreach (string c in d)
                                {
                                    Console.WriteLine(c);
                                    ro.Line("" + c);
                                }
                            });
                            row.RelativeItem(2).AlignCenter().Text(ro =>
                            {
                                calcs.Clear();
                                List<string> d = CreateElementsForPDF(type);
                                foreach (string c in d)
                                {
                                    Console.WriteLine(c);
                                    ro.Line("" + c);
                                }
                            });
                        });
                });
            }).GeneratePdf(stream);//stream
            return stream;
        }
    }
}