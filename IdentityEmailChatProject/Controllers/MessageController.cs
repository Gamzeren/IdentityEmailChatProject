using System.Security.Claims;
using IdentityEmailChatProject.Context;
using IdentityEmailChatProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Protocol.Core.Types;

namespace IdentityEmailChatProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Inbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var email = values.Email;

            string email1 = User.FindFirst(ClaimTypes.Email)?.Value;

            var gelenMesajSayisi = _context.Messages
            .Where(m => m.ReceiverEmail == email1)
            .Count();
            ViewBag.a = gelenMesajSayisi;

            ViewBag.v1 = values.Name + " " + values.Surname;
            var value=_context.Messages.Where(x=>x.ReceiverEmail==values.Email).ToList();
            return View(value);
        }

        public async Task<IActionResult> SendBox(string Search)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string emailValue = values.Email;
            ViewBag.email=values.Email;
            ViewBag.nameSurname = values.Name + " " + values.Surname;
            var sendMessageList=_context.Messages.Where(x=>x.SenderEmail==emailValue).ToList();
            ViewBag.SearchTerm = Search;
            var sentEmail = _context.Messages.Where(x => x.SenderEmail == emailValue && x.IsRead == true);
            if (!string.IsNullOrEmpty(Search))
            {
                string term=Search.ToLower();
                sentEmail = sentEmail.Where(x => x.Subject.ToLower().Contains(term) || x.ReceiverEmail.ToLower().Contains(term) || x.MessageDetail.ToLower().Contains(term));
            }
            return View(sendMessageList);
            return View(sentEmail.ToList());
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  CreateMessage(Message message)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string SenderEmail = values.Email;


            message.SenderEmail = SenderEmail;
            message.IsRead = false;
            message.SendDate= DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();
            TempData["success"] = "Mesajınız gönderildi";
            return RedirectToAction("SendBox");
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.senderImage = values.ProfileImageUrl;
            var value= _context.Messages.FirstOrDefault(x=>x.MessageId==id);
            return View(value);
        }
    }
}
