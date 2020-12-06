﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice_MVC.Model
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}