using IdentityCraft.Data;
using IdentityCraft.Models;
using IdentityCraft.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;
using System.Linq;

namespace IdentityCraft.Controllers
{
    public class HomeController : Controller
    {
         ApplicationDbContext _context;
        IWebHostEnvironment _hostingEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            var reviews = _context.Reviews.ToList();

            // إنشاء الـ ViewModel وإرسال البيانات إلى الـ View
            var viewModel = new HomeIndexViewModel
            {
                Products = products,
                Reviews = reviews
            };

            return View(viewModel); // إرجاع الـ ViewModel إلى الـ View
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.success = "Record has been inserted";
            }
            return View();
        }
        public IActionResult Image()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Image(ProductViewsModel product1)
        {
            string FileName = "";
            if (product1.Photo != null)
            {
                string UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                FileName = Guid.NewGuid().ToString() + "_" + product1.Photo.FileName;
                string FilePath = Path.Combine(UploadFolder, FileName);
                product1.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));

            }
            Product p = new Product
            {
                Name = product1.Name,
                Description = product1.Description,
                Image = FileName
            };
            _context.Products.Add(p);
            _context.SaveChanges();
            ModelState.Clear();
            ViewBag.success = "Record Add";
            return View();
        }
        public IActionResult Service()
        {
            var products = _context.Products.Take(10).ToList();  // استخدام تقنيات مثل Take للحد من البيانات
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Review()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Review(ReviewViewsModel review)
        {
            // التحقق من أن التقييم ليس صفرًا
            if (review.Rating == 0)
            {
                ModelState.AddModelError("Rating", "التقييم يجب أن يكون بين 1 و 5.");
                return View(review); // العودة إلى نفس الصفحة مع الرسالة
            }

            string fileName = "";

            // التحقق من تحميل صورة
            if (review.Photo != null)
            {
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(review.Photo.FileName);
                string filePath = Path.Combine(uploadFolder, fileName);

                // حفظ الصورة في المسار المحدد
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    review.Photo.CopyTo(fileStream);
                }
            }

            // إضافة المراجعة مع التقييم والصورة
            Review newReview = new Review
            {
                Name = review.Name,
                Description = review.Description,
                Rating = review.Rating,
                Image = fileName
            };

            // إضافة المراجعة إلى قاعدة البيانات
            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            // إعادة تعيين حالة النموذج مع عرض رسالة النجاح
            ModelState.Clear();
            ViewBag.success = "تم إضافة المراجعة بنجاح";

            // عرض الصفحة بدون بيانات الإدخال بعد الحفظ
            return View(new ReviewViewsModel());
        }

    }
}
