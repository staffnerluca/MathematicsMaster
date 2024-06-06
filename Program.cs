using MathMaster.ClassesOfTheProject;
using MathMaster.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Linq;

namespace MathMaster;

    class Program
    {
        public static SqlConnection conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; integrated security = true;");
        public static SqlCommand cmmd = new SqlCommand("", conn);

        public static void Main(string[] args)
        {
        string db = "MathMaster";

        if (CheckIfDatabaseExists(conn, db) == false)
        {
            CreateDatabase(conn, cmmd, db);
            CreateTables(conn, cmmd, db);
            ExampleTasks();
            Console.WriteLine("works");
        }

        else
        {
            ExampleTasks();
            Console.WriteLine("works");
        }

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }


    public static void CreateDatabase(SqlConnection conn, SqlCommand cmmd, string databasen)
    {
        try
        {
            //here I create my database whit the create statement
            cmmd.CommandText = "CREATE DATABASE " + databasen;
            cmmd.ExecuteNonQuery();
        }
        catch
        {
            Console.WriteLine("Wir wissen leider nicht was falsch gelaufen ist. Bitte machen Sie das was Sie gerade gemacht haben nicht mehr!");
        }
    }

    public static void CreateTables(SqlConnection conn, SqlCommand cmmd, string databasen)
    {
        try
        {
            //here I create all of my tables, this makes my programm lag a bit, because there are a lot of Insert statements
            //and a lot of knowledge includements (includings) aswell. With the Create statement I create all of my tables and
            //then I just Insert the whole data. 
            conn.Close();
            conn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Integrated Security = true; Database = " + databasen;
            conn.Open();

            cmmd = new SqlCommand("", conn);
            cmmd.CommandText = "CREATE TABLE Conti([Id] INT NOT NULL PRIMARY KEY IDENTITY, [Name] NVARCHAR(100))";
            cmmd.ExecuteNonQuery();
        }
        catch
        {
            Console.Write("Wir wissen leider nicht was falsch gelaufen ist. Bitte machen Sie das was Sie gerade gemacht haben nicht mehr!");
        }
    }


    public static bool CheckIfDatabaseExists(SqlConnection conn, string db)
        {
            //here I can check if a database exists, with the select command, if the value is null I know that it doesn't. Here I select
            //the id/names of the databases and look for my name if the value is not null it the programm knows that it exists, if there is null
            //it doesn't exist
            conn.Close();
            SqlCommand comm = new SqlCommand($"SELECT db_id('{db}')", conn);
            conn.Open();
            return comm.ExecuteScalar() != DBNull.Value; 
        }

        public static void ExampleTasks()
        {
            int nr = 1;
            string name = "Algebra: Lineare Gleichungen";
            string sector = "Algebra";
            int difficulty = 1;
            int points = 10;
            bool drawing = false;
            string question = "Löse die Gleichung 2x + 3 = 11.";
            string answer = "x = 4";
            string source = "ChatGPT";
            int group = 1;
            string imagePath = "";
            Models.Task task1 = new Models.Task(nr, name, sector, difficulty, points, drawing, question, answer, source, group, imagePath);

            Models.Task task2 = new Models.Task();
            task2.nr = 2;
            task2.name = "Geometrie: Flächenberechnung";
            task2.sector = "Geometrie";
            task2.difficulty = 1;
            task2.points = 10;
            task2.drawing = false;
            task2.question = "Berechne die Fläche eines Rechtecks mit einer Länge von 7 cm und einer Breite von 5 cm.";
            task2.answer = "35 cm²";
            task2.source = "ChatGPT";
            task2.group = 1;
            task2.imagePath = "";

            Models.Task task3 = new Models.Task();
            task3.nr = 3;
            task3.name = "Analysis: Ableitungen";
            task3.sector = "Analysis";
            task3.difficulty = 2;
            task3.points = 20;
            task3.drawing = false;
            task3.question = "Bestimme die Ableitung der Funktion f(x) = 3x² + 2x + 1.";
            task3.answer = "f′(x) = 6x + 2";
            task3.source = "ChatGPT";
            task3.group = 1;
            task3.imagePath = "";

            Models.Task task4 = new Models.Task();
            task4.nr = 4;
            task4.name = "Stochastik: Wahrscheinlichkeit";
            task4.sector = "Stochastik";
            task4.difficulty = 2;
            task4.points = 20;
            task4.drawing = false;
            task4.question = "In einer Urne befinden sich 3 rote und 7 blaue Kugeln. Wie groß ist die Wahrscheinlichkeit, eine rote Kugel zu ziehen?";
            task4.answer = "0,3 oder 30%";
            task4.source = "ChatGPT";
            task4.group = 1;
            task4.imagePath = "";

            Models.Task task5 = new Models.Task();
            task5.nr = 5;
            task5.name = "Lineare Algebra: Matrizen";
            task5.sector = "Lineare Algebra";
            task5.difficulty = 3;
            task5.points = 30;
            task5.drawing = false;
            task5.question = "Berechne die Determinante der Matrix (12)(3​4​).";
            task5.answer = "-2";
            task5.source = "ChatGPT";
            task5.group = 1;
            task5.imagePath = "";

            Models.Task task6 = new Models.Task();
            task6.nr = 6;
            task6.name = "Trigonometrie: Winkelfunktionen";
            task6.sector = "Trigonometrie";
            task6.difficulty = 1;
            task6.points = 10;
            task6.drawing = false;
            task6.question = "Berechne sin⁡(30∘)";
            task6.answer = "0,5";
            task6.source = "ChatGPT";
            task6.group = 1;
            task6.imagePath = "";

            Models.Task task7 = new Models.Task();
            task7.nr = 7;
            task7.name = "Zahlentheorie: Primzahlen";
            task7.sector = "Zahlentheorie";
            task7.difficulty = 1;
            task7.points = 10;
            task7.drawing = false;
            task7.question = "Ist 29 eine Primzahl?";
            task7.answer = "Ja, 29 ist eine Primzahl";
            task7.source = "ChatGPT";
            task7.group = 1;
            task7.imagePath = "";

            Models.Task task8 = new Models.Task();
            task8.nr = 8;
            task8.name = "Integralrechnung: Bestimmtes Integral";
            task8.sector = "Integralrechnung";
            task8.difficulty = 2;
            task8.points = 20;
            task8.drawing = false;
            task8.question = "Berechne das bestimmte Integral 0-2∫(3x) dx.";
            task8.answer = "6";
            task8.source = "ChatGPT";
            task8.group = 1;
            task8.imagePath = "";

            Models.Task task9 = new Models.Task();
            task9.nr = 9;
            task9.name = "Diskrete Mathematik: Kombinatorik";
            task9.sector = "Diskrete Mathematik";
            task9.difficulty = 4;
            task9.points = 40;
            task9.drawing = false;
            task9.question = "Wie viele Möglichkeiten gibt es, 3 aus 5 Objekten auszuwählen?";
            task9.answer = "10 (Kombinationen: (5 3))";
            task9.source = "ChatGPT";
            task9.group = 1;
            task9.imagePath = "";

            Models.Task task10 = new Models.Task();
            task10.nr = 10;
            task10.name = "Finanzmathematik: Zinsrechnung";
            task10.sector = "Finanzmathematik";
            task10.difficulty = 2;
            task10.points = 20;
            task10.drawing = false;
            task10.question = "Wie hoch ist der Endbetrag nach 2 Jahren bei einem Startkapital von 1000 Euro und einem jährlichen Zinssatz von 5%?";
            task10.answer = "1102,50 Euro - Zinseszins muss angewendet werden!";
            task10.source = "ChatGPT";
            task10.group = 1;
            task10.imagePath = "";

         //Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        //context.Tasks.Add(task1.nr, task1.name, task1.sector, task1.difficulty, task1.points, task1.drawing, task1.question, task1.answer, task1.source, task1.group, task1.imagePath);    
        //context.Tasks.AddRange(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10);
        //context.Add(new Models.Task{nr = 1, name = "Erisa", sector = "A", difficulty = 120, points = 1234, drawing = false, question = "ewedewwe", answer = "dsf", group = 0, imagePath = "ddede"});     
        //context.Add(task10);        
        //context.SaveChanges();


        using(var context = new lresch_MathMasterContext())
        {
            var task = new Models.Task()
            {
                nr = 12,
                name = "Gates",
                sector = "d",
                difficulty = 4,
                points = 20,
                drawing = false,
                question = "3d",
                answer = "12",
                source = "12",
                group = 1,
                imagePath = "12"
            };
            context.Tasks.Add(task);

            // or
            // context.Add<Student>(std);

            context.SaveChanges();
            Console.Write("Task ist drinnen");
        }
    }

        public static void ExampleUsers()
        {
            Models.User user1 = new Models.User();
            user1.id = 1;
            user1.username = "lily_sanchez";
            user1.E_Mail = "lily-sanchez@gmail.com";
            user1.points = 202;
            user1.usertype = "T";
            user1.lastLogin = DateTime.Now;
            user1.lastLogout = DateTime.Now; 
            user1.darkmode = true;
            user1.birthDate = DateTime.Now;

            Models.User user2 = new Models.User();
            user2.id = 2;
            user2.username = "erisa_piel";
            user2.E_Mail = "erias-piel@gmail.com";
            user2.points = 2012;
            user2.usertype = "S";
            user2.lastLogin = DateTime.Now;
            user2.lastLogout = DateTime.Now;
            user2.darkmode = true;
            user2.birthDate = DateTime.Now;

            Models.User user3 = new Models.User();
            user3.id = 3;
            user3.username = "gina_resch";
            user3.E_Mail = "gina-resch@gmail.com";
            user3.points = 1230;
            user3.usertype = "S";
            user3.lastLogin = DateTime.Now;
            user3.lastLogout = DateTime.Now;
            user3.darkmode = false;
            user3.birthDate = DateTime.Now;

            Models.User user4 = new Models.User();
            user4.id = 4;
            user4.username = "manuel_murizo";
            user4.E_Mail = "manuel-murizo@gmail.com";
            user4.points = 2120;
            user4.usertype = "S";
            user4.lastLogin = DateTime.Now;
            user4.lastLogout = DateTime.Now;
            user4.darkmode = true;
            user4.birthDate = DateTime.Now;

            Models.User user5 = new Models.User();
            user5.id = 5;
            user5.username = "mia_reyes";
            user5.E_Mail = "mia-reyes@gmail.com";
            user5.points = 3212;
            user5.usertype = "T";
            user5.lastLogin = DateTime.Now;
            user5.lastLogout = DateTime.Now;
            user5.darkmode = true;
            user5.birthDate = DateTime.Now;

            Models.User user6 = new Models.User();
            user6.id = 6;
            user6.username = "carlo_schmidt";
            user6.E_Mail = "carlo-schmidt@gmail.com";
            user6.points = 202;
            user6.usertype = "T";
            user6.lastLogin = DateTime.Now;
            user6.lastLogout = DateTime.Now;
            user6.darkmode = true;
            user6.birthDate = DateTime.Now;

            Models.User user7 = new Models.User();
            user7.id = 7;
            user7.username = "guenther_steger";
            user7.E_Mail = "guenther-steger@gmail.com";
            user7.points = 4000;
            user7.usertype = "S";
            user7.lastLogin = DateTime.Now;
            user7.lastLogout = DateTime.Now;
            user7.darkmode = true;
            user7.birthDate = DateTime.Now;

            Models.User user8 = new Models.User();
            user8.id = 8;
            user8.username = "chris_foidl";
            user8.E_Mail = "chris-foidl@gmail.com";
            user8.points = 2211;
            user8.usertype = "S";
            user8.lastLogin = DateTime.Now;
            user8.lastLogout = DateTime.Now;
            user8.darkmode = false;
            user8.birthDate = DateTime.Now;

            Models.User user9 = new Models.User();
            user9.id = 9;
            user9.username = "juan_martinez";
            user9.E_Mail = "juan-martinez@gmail.com";
            user9.points = 302;
            user9.usertype = "S";
            user9.lastLogin = DateTime.Now;
            user9.lastLogout = DateTime.Now;
            user9.darkmode = true;
            user9.birthDate = DateTime.Now;
    
            Models.User user10 = new Models.User();
            user10.id = 10;
            user10.username = "sina_bergmann";
            user10.E_Mail = "sina-bergmann@gmail.com";
            user10.points = 122;
            user10.usertype = "T";
            user10.lastLogin = DateTime.Now;
            user10.lastLogout = DateTime.Now;
            user10.darkmode = true;
            user10.birthDate = DateTime.Now;

        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            context.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10);
            context.SaveChanges();
    }    
}
