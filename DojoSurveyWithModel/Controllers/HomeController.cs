using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;
namespace DojoSurveyWithModel.Controllers;     //be sure to use your own project's namespace!
    public class HomeController : Controller   //inheritance
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("Survey")]
        public IActionResult Submit(Survey result )
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Result",result);
            }
            else{
                return View("Index");

            }
            
        }
        

        [HttpGet]
        [Route("Result")]

        public IActionResult Result(Survey result)
        {
            return View("Result",result);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }