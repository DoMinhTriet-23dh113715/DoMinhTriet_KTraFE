using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using DoMinhTriet_KTraFE.Models;
using PagedList.Mvc;

namespace DoMinhTriet_KTraFE.Models.ViewModel
{
    public class ProductDetailsVM
    {
        public Product product { get; set; }
        public int quantity { get; set; } = 1;

        //Tính giá trị tạm thời 
        public decimal estimatedValue { get; set; }



        //Tính giá trị tạm thời
        //public decimal estimatedValue => quantity * Product.ProductPrice;

        //Các thuộc tính hỗ trợ phân trang 
        public int PageNumner { get; set; } //Trang hiện tại 
        public int PageSize { get; set; } = 10; //Số sản phẩm mỗi trang

        //danh sách 8 sản phẩm cùng danh mục
        public List<Product> RelatedProducts { get; set; }

        //danh sách 8 sản phẩm bán chạy nhất cùng danh mục
        public PagedList.IPagedList<Product> TopProducts { get; set; }
    }
}