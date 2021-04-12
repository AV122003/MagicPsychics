using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagicalPsychics.Models;  

namespace MagicalPsychics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TestPsyhics testPsyhic;

            if (Session["TestPsyhic"] == null)
            {
                List<Psychic> psychics = new List<Psychic>
                {
                    new Psychic("Пух", @"~/Content\Images\puh.jpg"),
                    new Psychic("Пятачок", @"~/Content\Images\pig.jpg"),
                    new Psychic("Ослик", @"~/Content\Images\ia.jpg"),
                    new Psychic("Сова", @"~/Content\Images\owl.jpg")
                };
                testPsyhic = new TestPsyhics(2, psychics, new User("Юрий", @"~/Content\Images\uly.jpg"));
                Session["TestPsyhic"] = testPsyhic;
            }
            else
            {
                testPsyhic = (TestPsyhics)Session["TestPsyhic"];
            }
            
            return View(MapTestPsyhic(testPsyhic)) ;
        }
        
        public ActionResult PartialPsyhic()
        {
            return PartialView(MapTestPsyhic((TestPsyhics)Session["TestPsyhic"]));
        }
        public ActionResult PartialPuzzleHistory()
        {
            return PartialView(MapTestPsyhic((TestPsyhics)Session["TestPsyhic"]));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartialPuzzle(int puzzle)
        {
            TestPsyhics testPsyhic = (TestPsyhics)Session["TestPsyhic"];
            
            if (testPsyhic.PuzzleWait)
                testPsyhic.GuessMake();
            else
                testPsyhic.GuessCheck(puzzle);

            Session["testPsyhic"] = testPsyhic;
            return PartialView(MapTestPsyhic(testPsyhic));
        }
        private ViewTestPsyhic MapTestPsyhic(TestPsyhics testPsyhic)
        {
            if (testPsyhic != null)
                return new ViewTestPsyhic()
                {
                    WaitPuzzle = testPsyhic.PuzzleWait,
                    PsychicList = testPsyhic.PsychicList,
                    User = testPsyhic.User
                };
            else
                return null;
        }
        public ActionResult GuessSuccessNumber()
        {
            TestPsyhics testPsyhic = (TestPsyhics)Session["TestPsyhic"];
            return Json(testPsyhic.GuessSuccessNumber.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}