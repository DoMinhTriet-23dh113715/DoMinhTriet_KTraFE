using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Net;
using DoMinhTriet_KTraFE.Models;
using DoMinhTriet_KTraFE.Models.ViewModel;

namespace DoMinhTriet_KTraFE.Controllers
{
    public class HomeController : Controller
    {
        private MyStore1Entities db = new MyStore1Entities();

        // GET: Admin/Products

        public ActionResult Index(string searchTerm, int? page)
        {
            //var products = db.Products.Include(p => p.Category);
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Tìm  kiếm sản phẩm dựa trên từ khóa
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where(p =>
                           p.ProductName.Contains(searchTerm) ||
                           p.ProductDescription.Contains(searchTerm) ||
                           p.Category.CategoryName.Contains(searchTerm));
            }
            //Đoạn code liên quan tới phân trang 
            //Lấy số trang hiện tại (mặc định là trang 1 nếu không có giá trị)
            int pageNumber = page ?? 1;
            int pageSize = 6; //Số sản phẩm mỗi trang 

            //Lấy top 10 sản phẩm bán chạy nhất 
            model.FeaturedProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();

            //Lấy sản phẩm danh mục "Học tập"
            model.StudyProducts = products.Where(p => p.Category.CategoryName == "Học tập").ToList();

            //Lấy sản phẩm danh mục "Steam"
            model.SteamProducts = products.Where(p => p.Category.CategoryName == "Steam").ToList();

            //Lấy sản phẩm danh mục "Giải trí"
            model.EntertainmentProducts = products.Where(p => p.Category.CategoryName == "Giải trí").ToList();

            //Lấy sản phẩm danh mục "Làm việc"
            model.WorkProducts = products.Where(p => p.Category.CategoryName == "Làm việc").ToList();

            //Lấy sản phẩm danh mục "Wallet"
            model.WalletProducts = products.Where(p => p.Category.CategoryName == "Wallet").ToList();

            //Lấy sản phẩm danh mục "Spotify"
            model.SpotifyProducts = products.Where(p => p.Category.CategoryName == "Spotify").ToList();

            //Lấy 20 sản phẩm bán ế nhất và phân trang 
            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToList();

            return View(model);
        }


        //GET: Home/ProductDetails/5
        public ActionResult ProductDetails(int? id, int? quantity, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }

            //Lấy tất cả các sản phẩm cùng danh mục 
            var products = db.Products.Where(p => p.CategoryID == pro.CategoryID && p.ProductID != pro.ProductID).AsQueryable();

            ProductDetailsVM model = new ProductDetailsVM();

            //Đoạn code liên quan tới phân trang
            //Lấy số trang hiện tại(mặc địn là trang 1 nếu không có giá trị )
            int pageNumber = page ?? 1;
            int pageSize = model.PageSize;
            model.product = pro;
            model.RelatedProducts = products.OrderBy(p => p.ProductID).Take(8).ToList();
            model.TopProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(8).ToPagedList(pageNumber, pageSize);

            if (quantity.HasValue)
            {
                model.quantity = quantity.Value;
                model.estimatedValue = quantity.Value * model.product.ProductPrice;
            }
            else
            {
                model.estimatedValue = model.quantity * model.product.ProductPrice;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateQuantity(ProductDetailsVM model, int id, int quantity)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            // Cập nhật giá trị tạm tính trong model
            //ProductDetailsVM model = new ProductDetailsVM
            //{
            //    product = product,
            //    quantity = quantity,
            //    estimatedValue = quantity * product.ProductPrice
            //};
            model.product = product;
            model.quantity = quantity;
            model.estimatedValue = quantity * model.product.ProductPrice;
            return RedirectToAction("ProductDetails");

        }

        public ActionResult AddressDelivery()
        {
            return View();
        }
        public ActionResult ShoppingCarts()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Pay()
        {

            return View();
        }

        public ActionResult Tuyendung()
        {

            return View();
        }
        public ActionResult FeaturedDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy top 10 sản phẩm bán chạy nhất 
            model.FeaturedProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();
            return View(model);
        }
        public ActionResult EntertainmentDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy sản phẩm danh mục "Giải trí"
            model.EntertainmentProducts = products.Where(p => p.Category.CategoryName == "Giải trí").ToList();

            return View(model);
        }
        public ActionResult NewDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy 20 sản phẩm bán ế nhất và phân trang 
            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToList();

            return View(model);
        }
        public ActionResult SteamDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy sản phẩm danh mục "Steam"
            model.SteamProducts = products.Where(p => p.Category.CategoryName == "Steam").ToList();
            return View(model);
        }
        public ActionResult WalletDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy sản phẩm danh mục "Wallet"
            model.WalletProducts = products.Where(p => p.Category.CategoryName == "Wallet").ToList();
            return View(model);
        }
        public ActionResult SpotifyDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy sản phẩm danh mục "Spotify"
            model.SpotifyProducts = products.Where(p => p.Category.CategoryName == "Spotify").ToList();
            return View(model);
        }


        public ActionResult StudyDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy sản phẩm danh mục "Học tập"
            model.StudyProducts = products.Where(p => p.Category.CategoryName == "Học tập").ToList();
            return View(model);
        }

        public ActionResult WorkDetail()
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            //Lấy sản phẩm danh mục "Làm việc"
            model.WorkProducts = products.Where(p => p.Category.CategoryName == "Làm việc").ToList();
            return View(model);
        }
    }
}