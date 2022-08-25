using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;     //be sure to use your own project's namespace!
    public class HomeController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("/submit")]
        public IActionResult Submit(string Name,string Dojo, string Language, string Comment)
        {
            return RedirectToAction("Result",new { Name = Name, Dojo = Dojo, Language = Language, Comment = Comment});
        }

        [HttpGet]
        [Route("/Result")]

        public ViewResult Result(string Name, string Dojo,string Language,string Comment)
        {
            ViewBag.Aparna = Name;
            ViewBag.Dojo = Dojo;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;
            return View("Result");
        }
        
    }
