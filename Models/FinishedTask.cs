﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MathMaster.Models;

public partial class FinishedTask
{
    public FinishedTask(int nr, string name, string sector, int difficulty, int points, bool drawing, string question, string answer, string source, int group, string image) 
    {

    }

    public int TaskID { get; set; }

    public int UserID { get; set; }

    public float Percent { get; set; }
}