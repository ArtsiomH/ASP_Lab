﻿using _60331_Glotov.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _60331_Glotov.Models
{
    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}