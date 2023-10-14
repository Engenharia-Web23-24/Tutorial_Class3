using Aula03_EWPL1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula03_EWPL1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _he;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment he)
        {
            _logger = logger;
            _he = he;
        }

        public IActionResult Index()
        {
            DocFiles files =   new DocFiles();

            List<FileViewModel> myList = files.GetFiles(_he);

            ViewBag.quantosFicheiros = myList.Count;
            //ViewData["quantosFicheiros"] = myList.Count;
            ViewBag.quantosBytes = myList.Sum(x=>x.Size);
            //ViewData["quantosBytes"] = myList.Sum(x => x.Size);

            return View(myList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Upload() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile Name)
        {
            if(ModelState.IsValid)
            {
                string destination = Path.Combine(_he.ContentRootPath,
                     "wwwroot/Documents", Path.GetFileName( Name.FileName)
                    );

                FileStream fs = new FileStream(destination, FileMode.Create);
                Name.CopyTo(fs);
                fs.Close();

                //return RedirectToAction("Index");
                return RedirectToAction(nameof(Index));
            }
           
            return View();
        }

        public ActionResult Download(string id)
        {
            string pathFile = Path.Combine(_he.ContentRootPath, "wwwroot/Documents/", id);
            byte[] fileBytes =  System.IO.File.ReadAllBytes(pathFile);

            return File(fileBytes, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}