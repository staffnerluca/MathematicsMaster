using System.Reflection.Metadata;
using System;
using System.Numerics;

namespace testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            string menu = 
                "Was möchten Sie machen?\n" + "1-Multiplikation\n"
                + "2-Addition\n" + "3-Division\n" + "4-Subtraction\n" + "5-Division with remainder\n"
                + "6-Addition and subtraction\n" + "7-change measure\n" + "8-Addition three digits\n" 
                + "9-Addition with numbers under each other\n" + "10-Division with a result larger than ten\n"
                + "11-the same with remainder\n";

            Console.WriteLine(menu);
            string answa = Console.ReadLine();

            switch(answa)
            {
                case "1":
             
                    string mult = Multiplication(rand);
                    Console.WriteLine(mult);
                    break;

                case "2":

                    string add = Addition(rand);
                    Console.WriteLine(add);
                    break;
       

                case "3":

                    string div = Division(rand);
                    Console.WriteLine(div);
                    break;


                case "4":
                    string subt = Subtraction(rand);
                    Console.WriteLine(subt);
                    break;

                case "5":

                 
                    break;

            }

            string addu = AdditionUnder(rand);
            Console.WriteLine(addu);



            string divr = DivisionRemain(rand);
            Console.WriteLine(divr);

            string subu = SubtractionUnder(rand);
            Console.WriteLine(subu);

            string divu = DivisionUnder(rand);
            Console.WriteLine(divu);

            string divuwr = DivisionUnderWithRemain(rand);
            Console.WriteLine(divuwr);
        }

        public static string Multiplication(Random rand)
        {
            int firstnumber = rand.Next(1, 10);
            int secondnumber = rand.Next(1, 10);

            string result = "" + firstnumber + " * " + secondnumber + "= _____";

            return result;
        }

        public static string Division(Random rand) 
        {
            string r; 
            while (true) 
            {
                int firstnumber = rand.Next(1, 100);
                //30 : 3 = ; 39 : 13
                int secondnumber = rand.Next(1, 10);

                if (firstnumber % secondnumber == 0 && firstnumber / secondnumber <= 10) //modolo 3/2=1 Remainder 1, it tells you how many remainder's there are left
                {
                    r = "" + firstnumber + ": " + secondnumber + "=__________";
                    return r;
                }
            }      
        }

        public static string Addition(Random rand)
        {
            string r;
            while (true)
            {
                int firstnumber = rand.Next(0, 10);
                //30 : 3 = ; 39 : 13
                int secondnumber = rand.Next(0, 10);

                if(firstnumber + secondnumber <= 100)
                {
                    r = "" + firstnumber + " + " + secondnumber + " =____________";
                    return r;
                }
            }
        }

        public static string AdditionUnder(Random rand)
        {
            while (true)
            {
                int firstnumber = rand.Next(0, 1000);
                //30 : 3 = ; 39 : 13
                int secondnumber = rand.Next(0, 1000);

                if (firstnumber + secondnumber < 999)
                {
                    string r = "  " + firstnumber + "\n" + "+ " + secondnumber + "\n" + "_______________";
                
                    return r;             
                }
            }
        }

        public static string Subtraction(Random rand)
        {
            int firstnumber = rand.Next(0, 100);
            //30 : 3 = ; 39 : 13
            int secondnumber = rand.Next(0, 100);

            if (firstnumber > secondnumber)
            {
                string r = "" + firstnumber + " - " + secondnumber + " = ____________";
                return r;
            }
            else
            {
                string r = "" + secondnumber + " - " + firstnumber + " = ____________";
                return r; 
            }
        }

        public static string DivisionRemain(Random rand)
        {

            int firstnumber = rand.Next(0, 100);
            int secondnumber = rand.Next(0, 100);

            if (firstnumber > secondnumber)
            {
                string r = "" + firstnumber + " : " + secondnumber + " = ____________";
                return r;
            }
            else
            {
                string r = "" + secondnumber + " : " + firstnumber + " = ____________";
                return r;
            }
        }

        public static string SubtractionUnder(Random rand)
        {
            while (true)
            {
                int firstnumber = rand.Next(0, 1000);
                //30 : 3 = ; 39 : 13
                int secondnumber = rand.Next(-1000, 0);

                if (firstnumber - secondnumber*(-1) >=-999)
                {
                    string r = "  " + firstnumber + "\n" + " " + secondnumber + "\n" + "_______________";

                    return r;
                }
            }
        }

        public static string DivisionUnder(Random rand)
        {
            while (true)
            {
                int firstnumber = rand.Next(0, 1000);
                int secondnumber = rand.Next(2, 10);

                if (firstnumber % secondnumber == 0)
                {
                    string r = " " + firstnumber + ": " + secondnumber + "_______________" + "\n" + "______________" + "\n" + "______________" + "\n" + "______________";

                    return r;
                }
            }
        }

        public static string DivisionUnderWithRemain(Random rand)
        {
            while (true)
            {
                int firstnumber = rand.Next(0, 1000);
                int secondnumber = rand.Next(2, 10);

                if (firstnumber % secondnumber == 0)
                {
                    string r = " " + firstnumber + ": " + secondnumber + "_______________" + "\n" + "______________" + "\n" + "______________" + "\n" + "______________";

                    return r;
                }
            }
        }


    }
}
