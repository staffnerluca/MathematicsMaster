﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;

namespace MathMaster.Models;

public partial class FinishedTask
{
    public FinishedTask(int TaskID, int UserID, float Percent) 
    {

    }

    public int TaskID { get; set; }

    public int UserID { get; set; }

    public float Percent { get; set; }
}