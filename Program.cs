using MathMaster.ClassesOfTheProject;
using MathMaster.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.DirectoryServices;
using System.Linq;
using Microsoft.AspNetCore.Hosting.Server;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MathMaster.Controllers;
using Mysqlx.Crud;
using MathMaster.ClassesOfTheProject.DeleteMeSoonIfNotNeededAnymore;

namespace MathMaster;

    class Program
    {
        public static void Main(string[] args)
        {
        //ExampleUsers();
        //    ExampleTasks();
        //    Console.WriteLine("works");
        //I let this in, that you can see, that I did some things. Also I did need to do that once, so that we have example tasks

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

        public static void ExampleTasks()
        {
        //Example Tasks from ChatGPT
            Models.Task task1 = new Models.Task();    
            task1.nr = 14;
            task1.name = "Algebra: Lineare Gleichungen";
            task1.sector = "A";
            task1.difficulty = 1;
            task1.points = 10;
            task1.drawing = false;
            task1.question = "Löse die Gleichung 2x + 3 = 11.";
            task1.answer = "x = 4";
            task1.source = "ChatGPT";
            task1.group = 1;
            task1.imagePath = "";

            Models.Task task2 = new Models.Task();
            task2.nr = 22;
            task2.name = "Geometrie: Flächenberechnung";
            task2.sector = "G";
            task2.difficulty = 1;
            task2.points = 10;
            task2.drawing = false;
            task2.question = "Berechne die Fläche eines Rechtecks mit einer Länge von 7 cm und einer Breite von 5 cm.";
            task2.answer = "35 cm²";
            task2.source = "ChatGPT";
            task2.group = 1;
            task2.imagePath = "";

            Models.Task task3 = new Models.Task();
            task3.nr = 32;
            task3.name = "Analysis: Ableitungen";
            task3.sector = "A";
            task3.difficulty = 2;
            task3.points = 20;
            task3.drawing = false;
            task3.question = "Bestimme die Ableitung der Funktion f(x) = 3x² + 2x + 1.";
            task3.answer = "f′(x) = 6x + 2";
            task3.source = "ChatGPT";
            task3.group = 1;
            task3.imagePath = "";

            Models.Task task4 = new Models.Task();
            task4.nr = 24;
            task4.name = "Stochastik: Wahrscheinlichkeit";
            task4.sector = "S";
            task4.difficulty = 2;
            task4.points = 20;
            task4.drawing = false;
            task4.question = "In einer Urne befinden sich 3 rote und 7 blaue Kugeln. Wie groß ist die Wahrscheinlichkeit, eine rote Kugel zu ziehen?";
            task4.answer = "0,3 oder 30%";
            task4.source = "ChatGPT";
            task4.group = 1;
            task4.imagePath = "";

            Models.Task task5 = new Models.Task();
            task5.nr = 53;
            task5.name = "Lineare Algebra: Matrizen";
            task5.sector = "A";
            task5.difficulty = 3;
            task5.points = 30;
            task5.drawing = false;
            task5.question = "Berechne die Determinante der Matrix (12)(3​4​).";
            task5.answer = "-2";
            task5.source = "ChatGPT";
            task5.group = 1;
            task5.imagePath = "";

            Models.Task task6 = new Models.Task();
            task6.nr = 26;
            task6.name = "Trigonometrie: Winkelfunktionen";
            task6.sector = "G";
            task6.difficulty = 1;
            task6.points = 10;
            task6.drawing = false;
            task6.question = "Berechne sin⁡(30∘)";
            task6.answer = "0,5";
            task6.source = "ChatGPT";
            task6.group = 1;
            task6.imagePath = "";

            Models.Task task7 = new Models.Task();
            task7.nr = 74;
            task7.name = "Zahlentheorie: Primzahlen";
            task7.sector = "A";
            task7.difficulty = 1;
            task7.points = 10;
            task7.drawing = false;
            task7.question = "Ist 29 eine Primzahl?";
            task7.answer = "Ja, 29 ist eine Primzahl";
            task7.source = "ChatGPT";
            task7.group = 1;
            task7.imagePath = "";

            Models.Task task8 = new Models.Task();
            task8.nr = 81;
            task8.name = "Integralrechnung: Bestimmtes Integral";
            task8.sector = "A";
            task8.difficulty = 2;
            task8.points = 20;
            task8.drawing = false;
            task8.question = "Berechne das bestimmte Integral 0-2∫(3x) dx.";
            task8.answer = "6";
            task8.source = "ChatGPT";
            task8.group = 1;
            task8.imagePath = "";

            Models.Task task9 = new Models.Task();
            task9.nr = 92;
            task9.name = "Diskrete Mathematik: Kombinatorik";
            task9.sector = "A";
            task9.difficulty = 4;
            task9.points = 40;
            task9.drawing = false;
            task9.question = "Wie viele Möglichkeiten gibt es, 3 aus 5 Objekten auszuwählen?";
            task9.answer = "10 (Kombinationen: (5 3))";
            task9.source = "ChatGPT";
            task9.group = 1;
            task9.imagePath = "";

            Models.Task task10 = new Models.Task();
            task10.nr = 120;
            task10.name = "Finanzmathematik: Zinsrechnung";
            task10.sector = "A";
            task10.difficulty = 2;
            task10.points = 20;
            task10.drawing = false;
            task10.question = "Wie hoch ist der Endbetrag nach 2 Jahren bei einem Startkapital von 1000 Euro und einem jährlichen Zinssatz von 5%?";
            task10.answer = "1102,50 Euro - Zinseszins muss angewendet werden!";
            task10.source = "ChatGPT";
            task10.group = 1;
            task10.imagePath = "";

        Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
        context.Tasks.AddRange(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10);
        context.SaveChanges();
    }

        public static void ExampleUsers()
        {
        //Example Users, also created by ChatGPT
            HashPasswordForUse hashPasswordForUse = new HashPasswordForUse();

            Models.User user1 = new Models.User();
            user1.id = 1;     
            user1.username = "lily_sanchez";
            user1.E_Mail = "lily-sanchez@gmail.com";
            user1.points = 202;
            user1.usertype = "T";
            user1.lastLogin = "12.12.2023";
            user1.lastLogout = "12.12.2023"; 
            user1.birthDate = "12.12.2004";      
            string password1 = "234pkflöe,fä";
            string hashedpw1 = hashPasswordForUse.HashedPW(password1);
            user1.password = hashedpw1;
            user1.group = 1;

            Models.User user2 = new Models.User();
            user2.id = 2;
            user2.username = "erisa_piel";
            user2.E_Mail = "erias-piel@gmail.com";
            user2.points = 2012;
            user2.usertype = "S";
            user2.lastLogin = "01.02.2024";
            user2.lastLogout = "01.02.2024";
            user2.birthDate = "01.12.1956";
            string password2 = "3jnork3pö34är34";
            string hashedpw2 = hashPasswordForUse.HashedPW(password2);
            user2.password = hashedpw2;
            user2.group = 1;

        Models.User user3 = new Models.User();
            user3.id = 3;
            user3.username = "gina_resch";
            user3.E_Mail = "gina-resch@gmail.com";
            user3.points = 1230;
            user3.usertype = "S";
            user3.lastLogin = "12.06.2024";
            user3.lastLogout = "12.06.2023";
            user3.birthDate = "13.12.2000";
            string password3 = "234äf+edfre";
            string hashedpw3 = hashPasswordForUse.HashedPW(password3);
            user3.password = hashedpw3;
            user3.group = 1;

        Models.User user4 = new Models.User();
            user4.id = 4;
            user4.username = "manuel_murizo";
            user4.E_Mail = "manuel-murizo@gmail.com";
            user4.points = 2120;
            user4.usertype = "S";
            user4.lastLogin = "12.12.2023";
            user4.lastLogout = "12.12.2023";
            user4.birthDate = "12.12.1987";
            string password4 = "234rlf,eclfeöd#f";
            string hashedpw4 = hashPasswordForUse.HashedPW(password4);
            user4.password = hashedpw4;
            user4.group = 1;

        Models.User user5 = new Models.User();
            user5.id = 5;
            user5.username = "mia_reyes";
            user5.E_Mail = "mia-reyes@gmail.com";
            user5.points = 3212;
            user5.usertype = "T";
            user5.lastLogin = "09.03.2024";
            user5.lastLogout = "12.04.2024";
            user5.birthDate = "12.12.2023";
            string password5 = "ewöf+ö3+rüö34d#efeece";
            string hashedpw5 = hashPasswordForUse.HashedPW(password5);
            user5.password = hashedpw5;
            user5.group = 1;

        Models.User user6 = new Models.User();
            user6.id = 6;
            user6.username = "carlo_schmidt";
            user6.E_Mail = "carlo-schmidt@gmail.com";
            user6.points = 202;
            user6.usertype = "T";
            user6.lastLogin = "12.04.2023";
            user6.lastLogout = "12.04.2023";
            user6.birthDate = "31.11.1999";
            string password6 = "234l2ü34l+";
            string hashedpw6 = hashPasswordForUse.HashedPW(password6);
            user6.password = hashedpw6;
            user6.group = 1;

        Models.User user7 = new Models.User();
            user7.id = 7;
            user7.username = "guenther_steger";
            user7.E_Mail = "guenther-steger@gmail.com";
            user7.points = 4000;
            user7.usertype = "S";
            user7.lastLogin = "13.03.2024";
            user7.lastLogout = "13.03.2024";
            user7.birthDate = "15.08.1987";
            string password7 = "24k+234";
            string hashedpw7 = hashPasswordForUse.HashedPW(password7);
            user7.password = hashedpw7;
            user7.group = 1;

        Models.User user8 = new Models.User();
            user8.id = 8;
            user8.username = "chris_foidl";
            user8.E_Mail = "chris-foidl@gmail.com";
            user8.points = 2211;
            user8.usertype = "S";
            user8.lastLogin = "24.04.2024";
            user8.lastLogout = "24.04.2024";
            user8.birthDate = "04.06.1967";
            string password8 = "234##24+23423";
            string hashedpw8 = hashPasswordForUse.HashedPW(password8);
            user8.password = hashedpw8;
            user8.group = 1;

        Models.User user9 = new Models.User();
            user9.id = 9;
            user9.username = "juan_martinez";
            user9.E_Mail = "juan-martinez@gmail.com";
            user9.points = 302;
            user9.usertype = "S";
            user9.lastLogin = "12.12.2023";
            user9.lastLogout = "12.12.2023";
            user9.birthDate = "12.12.2016";
            string password9 = "23490ifclpeüd!";
            string hashedpw9 = hashPasswordForUse.HashedPW(password9);
            user9.password = hashedpw9;
            user9.group = 1;

        Models.User user10 = new Models.User();
            user10.id = 10;
            user10.username = "sina_bergmann";
            user10.E_Mail = "sina-bergmann@gmail.com";
            user10.points = 122;
            user10.usertype = "T";
            user10.lastLogin = "24.07.2023";
            user10.lastLogout = "24.07.2023";
            user10.birthDate = "25.07.1987";
            string password10 = "320941dksof";
            string hashedpw10 = hashPasswordForUse.HashedPW(password10);
            user10.password = hashedpw10;
            user10.group = 1;

            Models.lresch_MathMasterContext context = new Models.lresch_MathMasterContext();
            context.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10);
            context.SaveChanges();
        }    
}