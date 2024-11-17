using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;


namespace DoMinhTriet_KTraFE.Models.ViewModel
{
    public class HomeProductVM
    {
        //tiêu chí để search theo tên , mô tả sp
        //hoặc loại sản phẩm 
        public string SearchTerm { get; set; }

        //Các thuộc tính hỗ trợ phân trang 
        public int PageNumner { get; set; } //Trang hiện tại 
        public int PageSize { get; set; } = 4; //Số sản phẩm mỗi trang

        //danh sách sản phẩm nổi bật 
        public List<Product> FeaturedProducts { get; set; }

        //danh sách sản phẩm học tập
        public List<Product> StudyProducts { get; set; }

        //danh sách sản phẩm game steam
        public List<Product> SteamProducts { get; set; }

        //danh sách sản phẩm giải trí
        public List<Product> EntertainmentProducts { get; set; }

        //danh sách sản phẩm làm việc
        public List<Product> WorkProducts { get; set; }

        //danh sách sản phẩm walllet
        public List<Product> WalletProducts { get; set; }

        //danh sách sản phẩm spotify
        public List<Product> SpotifyProducts { get; set; }

        //Danh sách sản phẩm mới đã phân trang 
        public List<Product> NewProducts { get; set; }
    }
}