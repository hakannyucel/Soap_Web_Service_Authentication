﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Tbl_Admin
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

public partial class V_Saatler
{
    public int Id { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Kordon { get; set; }
    public string Renk { get; set; }
    public Nullable<int> Stok { get; set; }
    public Nullable<decimal> Fiyat { get; set; }
}
