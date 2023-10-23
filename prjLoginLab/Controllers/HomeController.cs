using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using prjLoginLab.Models;

namespace prjLoginLab.Controllers
{
    public class HomeController : Controller
    {
        private EmpDbContext _context;

        public HomeController(EmpDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.TEmployees.ToList();
            return View(employees);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TEmployee employee) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.TEmployees.Add(employee);
                    _context.SaveChanges();
                    TempData["sucess"]= "員工紀錄新增成功";
                    return RedirectToAction("Index");
                    
                }
                catch (Exception ex)
                {
                     TempData["Error"] = "員工編號重複";
                }
            }
            return View(employee);            
        }

        public IActionResult Delete(string id) 
        {
            var employee = _context.TEmployees.FirstOrDefault(m => m.FId == id);
            _context.Remove(employee);
            _context.SaveChanges();
            TempData["sucess"] = "員工紀錄刪除成功";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id) 
        {
            TEmployee employee = _context.TEmployees.FirstOrDefault(m => m.FId == id);
  
            return View(employee);

        }
        [HttpPost]
        public IActionResult Edit(TEmployee employee) 
        {
            if (ModelState.IsValid)
                
            {
                try
                {

                    var temp = _context.TEmployees.Find(employee.FId);
                    temp.FPwd = employee.FPwd;
                    temp.FRole = employee.FRole;
                    temp.FName = employee.FName;
                    temp.FGender = employee.FGender;
                    temp.FMail = employee.FMail;
                    temp.FEployeeDate = employee.FEployeeDate;
                    TempData["sucess"] = "員工紀錄編輯成功";
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }catch (Exception ex)
                { 
                    TempData["Error"] ="無法修改個人資料內容，請再確認資料"; 
                }
                
            }
            return View( employee);
            
        }
    }
}
