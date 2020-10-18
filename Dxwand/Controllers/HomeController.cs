using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dxwand.Models;
using Dxwand.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace Dxwand.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult SaveMessageInDatabase(MessageViewModel messageViewModel)
        {
            var result = false;
            try
            {
                if (!messageViewModel.Message.IsNullOrWhiteSpace() && !messageViewModel.Language.IsNullOrWhiteSpace())
                {
                    var modal = new ChatMessage();
                    modal.Language = messageViewModel.Language;
                    modal.Message = messageViewModel.Message;
                    modal.ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    modal.RecivedDate = DateTime.Now;
                    _context.ChatMessage.Add(modal);
                    var characters = messageViewModel.Message.Split(' ');
                    foreach (var ch in characters)
                    {
                        if (ch.IsNullOrWhiteSpace())
                        {
                            continue;
                        }
                        var MessageDetail = _context.MessageDetails.Where(c => c.Word == ch).SingleOrDefault();
                        if (MessageDetail !=null)
                        {
                            MessageDetail.Count = MessageDetail.Count + 1;
                            _context.SaveChanges();
                        }
                        else
                        {
                            var messageDetail = new MessageDetails();
                            messageDetail.Word = ch;
                            messageDetail.Count = 1;
                            _context.MessageDetails.Add(messageDetail);
                            _context.SaveChanges();
                        }

                    }

                    result = true;


                }
              
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}