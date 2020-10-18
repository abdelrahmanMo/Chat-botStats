using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dxwand.Models;
using Dxwand.Models.ViewModels;

namespace Dxwand.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMessageDetails( )
        {

            var result = _context.MessageDetails.Where(m => m.Count > 1).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetUserGender()
        {
            List<GenderCountViewModel> result =new List<GenderCountViewModel>();

            var count = _context.Users.Where(u=>u.GenderId==1).ToList().Count();
            var model = new GenderCountViewModel
            {
                Name = "Male",
                Count = count
            };
            result.Add(model);
            var countFemale = _context.Users.Where(u => u.GenderId == 2).ToList().Count();
            var modelFemale = new GenderCountViewModel
            {
                Name = "Female",
                Count = countFemale
            };
            result.Add(modelFemale);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserlanguage()
        {
            List<LanguageViewModel> result = new List<LanguageViewModel>();
             result = _context.ChatMessage.GroupBy(m=>m.Language).Select(a => new LanguageViewModel
             {
                 Language = a.Key.ToString(),
                 Count = a.Count()
             }).ToList();
            
        
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserAge()
        {
            List<AgeViewModel> result = new List<AgeViewModel>();
            result = _context.Users.GroupBy(m => m.DateOfBirth.Year).Select(a => new AgeViewModel
            {
                Name = a.Key.ToString(),
                Count = a.Count()
            }).ToList();


            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}