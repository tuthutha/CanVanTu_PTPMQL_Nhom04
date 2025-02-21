using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
namespace DemoMVC.Controllers
{
    public class BMIController : Controller
    {
        public IActionResult Index()
        {
            return View(new BMIModel());
        }

        [HttpPost]
        public IActionResult Index(double weight, double height)
        {
            if (height > 10)
            {
                height /= 100;
            }

            if (weight <= 0 || height <= 0)
            {
                ViewBag.Result = "Lỗi: Cân nặng và chiều cao phải lớn hơn 0.";
                return View();
            }

            double bmi = weight / (height * height);

            string category;
            if (bmi < 18.5) category = "Gầy";
            else if (bmi < 25) category = "Bình thường";
            else if (bmi < 30) category = "Thừa cân";
            else category = "Béo phì";

            ViewBag.Result = $"Kết quả BMI: {bmi:F2} - {category}";
            return View();
        }
    }
}