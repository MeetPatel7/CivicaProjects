﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FD.Business.Entity
{
    public partial class Categories
    {
        public Categories()
        {
            FootwearDetails = new HashSet<FootwearDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Pic { get; set; }

        public virtual ICollection<FootwearDetails> FootwearDetails { get; set; }
    }
}