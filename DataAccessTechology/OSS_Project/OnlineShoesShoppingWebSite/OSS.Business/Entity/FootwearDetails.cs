﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace OSS.Business.Entity
{
    public class FootwearDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pic { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Manufacturers Manufacturer { get; set; }
    }
}