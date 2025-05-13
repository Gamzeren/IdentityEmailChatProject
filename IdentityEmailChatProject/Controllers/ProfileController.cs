using IdentityEmailChatProject.Context;
using IdentityEmailChatProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityEmailChatProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> ProfileDetail()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ProfilePicture = values.ProfileImageUrl;
            ViewBag.name = values.Name;
            ViewBag.surname=values.Surname;
            ViewBag.email=values.Email;
            ViewBag.username = values.UserName;
            ViewBag.recipientEmailAddressCount=_context.Messages.Where(x=>x.ReceiverEmail==values.Email).Count();
            ViewBag.senderEmailAddressCount=_context.Messages.Where(x=>x.SenderEmail==values.Email).Count();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser updatedUser, string profileImageUrl, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Surname = updatedUser.Surname;
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;

            if (!string.IsNullOrEmpty(profileImageUrl))
            {
                user.ProfileImageUrl = profileImageUrl;
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                var hasPassword = await _userManager.HasPasswordAsync(user);
                if (hasPassword)
                {
                    var removeResult = await _userManager.RemovePasswordAsync(user);
                    if (!removeResult.Succeeded)
                    {
                        foreach (var error in removeResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View("Profile", user);
                    }
                }

                var addResult = await _userManager.AddPasswordAsync(user, newPassword);
                if (!addResult.Succeeded)
                {
                    foreach (var error in addResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View("Profile", user);
                }
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Profil başarıyla güncellendi!";
                return RedirectToAction("UserLogin", "Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Profile", user);
            }
        }

    }
}
