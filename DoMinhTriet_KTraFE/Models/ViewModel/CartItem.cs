﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoMinhTriet_KTraFE.Models.ViewModel
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductImage { get; set; }
        //tổng sản phẩm cho mối sản phẩm 
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}